using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ProxyPattern
{
    public class Property<T> where T : new()
    {
        private T value;

        public T Value
        {
            get => value;
            set
            {
                if (Equals(this.value, value)) return;
                WriteLine($"Assigning value to {value}");
                this.value = value;
            }
        }

        public Property() : this(default(T))
        {

        }

        public Property(T value)
        {
            this.value = value;
        }

        public static implicit operator T(Property<T> property)
        {
            return property.value; // int n = p_int
        }

        public static implicit operator Property<T>(T value)
        {
            return new Property<T>(value); // Property<int> p = 123
        }

        public override bool Equals(object obj)
        {
            var property = obj as Property<T>;
            return property != null &&
                   EqualityComparer<T>.Default.Equals(value, property.value) &&
                   EqualityComparer<T>.Default.Equals(Value, property.Value);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }

    public class Creature
    {
        private Property<int> agility = new Property<int>();
        public int Agility
        {
            get => agility.Value;
            set => agility.Value = value;
        }
    }

    class PropertyProxy
    {
        void Main(string[] args)
        {
            var c = new Creature();
            c.Agility = 10; // c.set_Agility(10) xxxxxx
                            // c.Agility = new Property<int>(10)
            c.Agility = 10;
        }
    }
}
