using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Coding.Exercise
{
    public class Token
    {
        public int Value = 0;

        public Token(int value)
        {
            this.Value = value;
        }
    }

    public class Memento
    {
        public Memento(List<Token> tokens)
        {
            Tokens = tokens;
        }

        public List<Token> Tokens { get; }
    }

    public class TokenMachine
    {
        public List<Token> Tokens = new List<Token>();

        public Memento AddToken(int value)
        {
            return AddToken(new Token(value));
        }

        public Memento AddToken(Token token)
        {
            Tokens.Add(token);
            return new Memento(Tokens.Select(t => new Token(t.Value)).ToList());
        }

        public void Revert(Memento m)
        {
            this.Tokens = m.Tokens.Select(mm => new Token(mm.Value)).ToList();
        }
    }
}
