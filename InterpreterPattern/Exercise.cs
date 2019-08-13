using System;
using System.Collections.Generic;

namespace Coding.Exercise
{
    public enum Type
    {
        INT, PLUS, MINUS, VAR
    }

    public class Token
    {
        public Token(Type type, string value)
        {
            Type = type;
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public Type Type { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return $"'{Value}'";
        }
    }

    public interface IElement
    {
        int Value { get; }
    }

    public class ExpressionProcessor
    {
        private List<Token> Lex(string input)
        {
            var tokens = new List<Token>();
            for (int i = 0; i < input.Length; i++)
            {
                if(input[i] == '+')
                {
                    tokens.Add(new Token(Type.PLUS, "+"));
                    continue;
                }
                if (input[i] == '-')
                {
                    tokens.Add(new Token(Type.MINUS, "-"));
                    continue;
                }
                if(char.IsDigit(input[i]))
                {
                    string value = string.Empty;

                    for (int j = i; j < input.Length; j++)
                    {
                        if (char.IsDigit(input[j]))
                        {
                            value += input[j];
                            continue;
                        }
                        else
                        {
                            i = j - 1;
                            break;
                        }
                    }
                    tokens.Add(new Token(Type.INT, value));
                    continue;
                }
                if (char.IsLetter(input[i]))
                {
                    tokens.Add(new Token(Type.VAR, input[i].ToString()));
                    continue;
                }
            }

            return tokens;
        }

        public Dictionary<char, int> Variables = new Dictionary<char, int>();

        public int Calculate(string expression)
        {
            Lex(expression);

            // todo
            return 0;
        }
    }
}
