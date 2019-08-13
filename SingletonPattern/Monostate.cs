using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace SingletonPattern
{
    public class CEO
    {
        private static string name;
        private static int age;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
        }
    }

    static class Monostate
    {
        static void Main(string [] args)
        {
            var ceo = new CEO();
            ceo.Name = "Adam Smith";
            ceo.Age = 55;

            var ceo2 = new CEO();
            WriteLine(ceo2);
        }
    }
}
