using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ProxyPattern
{
    public interface ICar
    {
        void Drive();
    }

    public class Car : ICar
    {
        public void Drive()
        {
            WriteLine("Car is being driven");
        }
    }

    public class Driver
    {
        public Driver(int age)
        {
            Age = age;
        }

        public int Age { get; set; }


    }

    public class CarProxy : ICar
    {
        private Driver driver;
        private Car car = new Car();

        public CarProxy(Driver driver)
        {
            this.driver = driver;
        }

        public void Drive()
        {
            if (driver.Age >= 16)
                car.Drive();
            else
                WriteLine("too young");
        }
    }

    class Program
    {
        void Main(string[] args)
        {
            ICar car = new CarProxy(new Driver(22));
            car.Drive();
        }
    }
}
