﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern.Acyclic
{
    public interface IVisitor<TVisitable>
    {
        void Visit(TVisitable obj);
    }

    public interface IVisitor { }

    // 3 - DoubleExpression
    // (1+2) (1+(2+3)) AdditionExpression
    public abstract class Expression
    {
        public virtual void Accept(IVisitor visitor)
        {
            if (visitor is IVisitor<Expression> typed)
            {
                typed.Visit(this);
            }
        }
    }

    public class DoubleExpression : Expression
    {
        public double Value;

        public DoubleExpression(double value)
        {
            Value = value;
        }

        public override void Accept(IVisitor visitor)
        {
            if(visitor is IVisitor<DoubleExpression> typed)
            {
                typed.Visit(this);
            }
        }
    }

    public class AdditionExpression : Expression
    {
        public Expression Left, Right;

        public AdditionExpression(Expression left, Expression right)
        {
            Left = left ?? throw new ArgumentNullException(nameof(left));
            Right = right ?? throw new ArgumentNullException(nameof(right));
        }

        public override void Accept(IVisitor visitor)
        {
            if (visitor is IVisitor<AdditionExpression> typed)
            {
                typed.Visit(this);
            }
        }
    }

    public class ExpressionPrinter : IVisitor,
        IVisitor<Expression>,
        IVisitor<DoubleExpression>,
        IVisitor<AdditionExpression>
    {
        private StringBuilder sb = new StringBuilder();

        public void Visit(Expression obj)
        {
            
        }

        public void Visit(DoubleExpression obj)
        {
            sb.Append(obj.Value);
        }

        public void Visit(AdditionExpression obj)
        {
            sb.Append("(");
            obj.Left.Accept(this);
            sb.Append("+");
            obj.Right.Accept(this);
            sb.Append(")");
        }
        public override string ToString() => sb.ToString();
    }

    public class Demo
    {
        static void Main(string[] args)
        {
            var e = new AdditionExpression(
                left: new DoubleExpression(1),
                right: new AdditionExpression(
                    left: new DoubleExpression(2),
                    right: new DoubleExpression(3)));
            var ep = new ExpressionPrinter();
            ep.Visit(e);
            Console.WriteLine(ep.ToString());
        }
    }
}
