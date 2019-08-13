using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    [DebuggerDisplay("{value*100.0f}%")]
    public struct Percentage
    {
        private readonly float value;

        internal Percentage(float value)
        {
            this.value = value;
        }

        public static float operator *(float f, Percentage p)
        {
            return f * p.value;
        }

        public static Percentage operator +(Percentage a, Percentage b)
        {
            return new Percentage(a.value + b.value);
        }

        public override string ToString()
        {
            return $"{ value * 100 }%";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Percentage))
            {
                return false;
            }

            var percentage = (Percentage)obj;
            return value == percentage.value;
        }

        public override int GetHashCode()
        {
            return -1584136870 + value.GetHashCode();
        }
    }

    public static class PercentageExtensions
    {
        public static Percentage Percent(this int value)
        {
            return new Percentage(value / 100.0f);
        }

        public static Percentage Percent(this float value)
        {
            return new Percentage(value / 100.0f);
        }
    }

    class ValueProxy
    {

        void Main(string[] args)
        {
            Console.WriteLine(
                10f * 5.Percent()
                );

            Console.WriteLine(2.Percent() + 3.Percent()
                );
        }
    }
}
