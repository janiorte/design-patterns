using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DecoratorPattern
{
    public class Bird : IBird
    {
        public int Weight { get; set; }
        public void Fly()
        {
            WriteLine($"Soaring in the sky with weight {Weight}");
        }
    }

    public class Lizard : ILizard
    {
        public int Weight { get; set; }
        public void Crawl()
        {
            WriteLine($"Crawling in the dirt with weight {Weight}");
        }
    }

    public class Dragon : IBird, ILizard
    {
        private Bird bird = new Bird();
        private Lizard lizard = new Lizard();
        private int _weight;

        public void Crawl()
        {
            lizard.Crawl();
        }

        public void Fly()
        {
            bird.Fly();
        }

        public int Weight
        {
            get { return _weight; }
            set {
                _weight = value;
                bird.Weight = value;
                lizard.Weight = value;
            }
        }
    }

     class MultipleInheritance
    {
        void Main(string[] args)
        {
            var d = new Dragon();
            d.Weight = 123;
            d.Fly();
            d.Crawl();
        }
    }
}
