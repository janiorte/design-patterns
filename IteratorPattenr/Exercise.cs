using System;
using System.Collections.Generic;

namespace Coding.Exercise
{
    public class Node<T>
    {
        public T Value;
        public Node<T> Left, Right;
        public Node<T> Parent;

        public Node(T value)
        {
            Value = value;
        }

        public Node(T value, Node<T> left, Node<T> right)
        {
            Value = value;
            Left = left;
            Right = right;

            left.Parent = right.Parent = this;
        }

        public IEnumerable<T> PreOrder
        {
            get
            {
                var preorder = new List<T>();
                if(Value != null){
                    preorder.Add(Value);
                    if(Left != null) preorder.AddRange(Left.PreOrder);
                    if(Right != null) preorder.AddRange(Right.PreOrder);
                }
                return preorder;
            }
        }
    }
}
