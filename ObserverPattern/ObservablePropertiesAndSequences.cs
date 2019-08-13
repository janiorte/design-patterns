using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class Market 
    {
        public BindingList<float> Prices = new BindingList<float>();
        public void AddPrice(float price)
        {
            Prices.Add(price);
        }

    }

    class ObservablePropertiesAndSequences
    {
        static void Main(string[] args)
        {
            var market = new Market();
            market.Prices.ListChanged += (sender, f) =>
            {
                if (f.ListChangedType == ListChangedType.ItemAdded)
                {
                    float price = ((BindingList<float>)sender)[f.NewIndex];
                    Console.WriteLine($"We got a price of {price}");
                }
            };
            market.AddPrice(123);
        }
    }
}
