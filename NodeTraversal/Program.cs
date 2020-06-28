﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace NodeTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var node = new Node<char>('a',
              new Node<char>('b',
                new Node<char>('c'),
                new Node<char>('d')),
              new Node<char>('e'));

            Console.WriteLine(string.Join("", node.PreOrder));
        }
    }



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
                IEnumerable<Node<T>> Traverse(Node<T> current)
                {
                    yield return current;
                    if (current.Left != null)
                    {
                        foreach (var left in Traverse(current.Left))
                            yield return left;
                    }
                    if (current.Right != null)
                    {
                        foreach (var right in Traverse(current.Right))
                            yield return right;
                    }
                }
                foreach (var node in Traverse(this))
                    yield return node.Value;
            }
        }
    }
}
