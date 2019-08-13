using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace FactoriesPattern
{
    public class Point
    {
        private double x, y;

        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }

        public static Point Origin => new Point(0, 0);
        public static Point Origin2 = new Point(0, 0); // better, instantiate once

        public static class Factory
        {
            public static Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }

            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }
        }
    }

    public class Demo
    {
        void Main(string[] args)
        {
            var point = Point.Factory.NewPolarPoint(1.0, Math.PI / 2);
            WriteLine(point);
        }
    }
}
