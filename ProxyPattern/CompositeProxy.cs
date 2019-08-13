﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.CompositeProxy
{
    class Creature
    {
        public byte Age;
        public int X, Y;
    }

    class Creatures
    {
        private readonly int size;
        private byte[] age;
        private int[] x, y;

        public Creatures(int size)
        {
            this.size = size;
            age = new byte[size];
            x = new int[size];
            y = new int[size];
        }

        public struct CreatureProxy
        {
            private readonly Creatures _creatures;
            private readonly int _index;

            public CreatureProxy(Creatures creatures, int index)
            {
                _creatures = creatures;
                _index = index;
            }

            public ref byte Age => ref _creatures.age[_index];
            public ref int X => ref _creatures.x[_index];
            public ref int Y => ref _creatures.y[_index];
        }

        public IEnumerator<CreatureProxy> GetEnumerator()
        {
            for (int pos = 0; pos < size; ++pos)
                yield return new CreatureProxy(this, pos);
        }
    }

    class CompositeProxy
    {
        static void Main(string[] args)
        {
            var creatures = new Creature[100];
            foreach(var c in creatures)
            {
                c.X++;
            }

            var creatures2 = new Creatures(100);
            foreach(var c in creatures2)
            {
                c.X++;
            }
        }
    }
}
