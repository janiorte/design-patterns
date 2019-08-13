using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class FallsIllEventArgs
    {
        public string Address;
    }

    public class Person
    {
        public void CatchACold()
        {
            FallsIll?.Invoke(this, new FallsIllEventArgs{Address = "123 London Road"});
        }

        public event EventHandler<FallsIllEventArgs> FallsIll;
    }

    class Program
    {
        void Main(string[] args)
        {
            var person = new Person();
            person.FallsIll += CallDoctor;
            person.CatchACold();
        }

        private static void CallDoctor(object sender, FallsIllEventArgs e)
        {
            Console.WriteLine($"A doctor has been called to {e.Address}");
        }
    }
}
