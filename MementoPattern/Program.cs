using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoPattern
{
    public class Memento
    {
        public Memento(int balance)
        {
            Balance = balance;
        }

        public int Balance { get; }
    }

    public class BankAccount
    {
        private int balance;
        private List<Memento> changes = new List<Memento>();
        private int current;

        public BankAccount(int balance)
        {
            this.balance = balance;
            changes.Add(new Memento(balance));
        }

        public Memento Deposit(int amount)
        {
            balance += amount;
            var m = new Memento(balance);
            changes.Add(m);
            ++current;
            return m;
        }

        public Memento Restore(Memento m)
        {
            if(m != null)
            {
                balance = m.Balance;
                changes.Add(m);
                return m;
            }

            return null;
        }

        public Memento Undo()
        {
            if(current > 0)
            {
                var m = changes[--current];
                balance = m.Balance;
                return m;
            }

            return null;
        }

        public Memento Redo()
        {
            if(current + 1 < changes.Count)
            {
                var m = changes[++current];
                balance = m.Balance;
                return m;
            }

            return null;
        }

        public override string ToString()
        {
            return $"{nameof(balance)}: {balance}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var ba = new BankAccount(100);
            var m1 = ba.Deposit(50);
            var m2 = ba.Deposit(25);
            Console.WriteLine(ba);

            ba.Undo();
            Console.WriteLine($"Undo 1: {ba}");
            ba.Undo();
            Console.WriteLine($"Undo 2: {ba}");
            ba.Redo();
            Console.WriteLine($"Redo: {ba}");
        }
    }
}
