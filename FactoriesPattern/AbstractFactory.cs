using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace AbstractFactory
{
    public interface IHotDrink
    {
        void Consume();
    }

    internal class Tea: IHotDrink
    {
        public void Consume()
        {
            WriteLine("This tea is nice but I'd prefer it with milk.");
        }
    }

    internal class Coffee: IHotDrink
    {
        public void Consume()
        {
            WriteLine("This coffee is sensational!");
        }
    }

    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }

    internal class TeaFactory: IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            WriteLine($"Put in a tea bag, boil water, pour {amount} ml, add lemon, enjoy!");
            return new Tea();
        }
    }

    internal class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            WriteLine($"Grind some beans, boil water, pour {amount} ml, add cream and sugar, enjoy!");
            return new Coffee();
        }
    }

    public class HotDrinkMachine
    {
        //public enum AvailableDrink
        //{
        //    Coffee, Tea
        //}

        //private Dictionary<AvailableDrink, IHotDrinkFactory> factories = new Dictionary<AvailableDrink, IHotDrinkFactory>();

        //public HotDrinkMachine()
        //{
        //    foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
        //    {
        //        var type = "AbstractFactory." + Enum.GetName(typeof(AvailableDrink), drink) + "Factory";
        //        var factory = (IHotDrinkFactory)Activator.CreateInstance(
        //            Type.GetType(type));
        //        factories.Add(drink, factory);
        //    }
        //}

        //public IHotDrink MakeDrink(AvailableDrink drink, int amount)
        //{
        //    return factories[drink].Prepare(amount);
        //}

        private List<Tuple<string, IHotDrinkFactory>> factories = 
            new List<Tuple<string, IHotDrinkFactory>>();

        public HotDrinkMachine()
        {
            foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
            {
                if (typeof(IHotDrinkFactory).IsAssignableFrom(t) &&
                    !t.IsInterface)
                {
                    factories.Add(Tuple.Create(
                        t.Name.Replace("Factory", string.Empty),
                        (IHotDrinkFactory)Activator.CreateInstance(t)
                        ));
                }
            }
        }

        public IHotDrink MakeDrink()
        {
            WriteLine("Available drinks:");
            for (int i = 0; i < factories.Count; i++)
            {
                var tuple = factories[i];
                WriteLine($"{i}: {tuple.Item1}");
            }
            
            while(true)
            {
                string s;
                if((s = Console.ReadLine()) != null
                    && int.TryParse(s, out int i)
                    && i >= 0
                    && i < factories.Count)
                {
                    Write("Specify amount: ");
                    s = ReadLine();
                    if(s != null 
                        && int.TryParse(s, out int amount))
                    {
                        return factories[i].Item2.Prepare(amount);
                    }
                }

                WriteLine("Incorrect input, try again!");
            }
        }
    }

    class AbstractFactory
    {
        static void Main(string[] args)
        {
            var machine = new HotDrinkMachine();
            var drink = machine.MakeDrink();
            drink.Consume();
        }
    }
}
