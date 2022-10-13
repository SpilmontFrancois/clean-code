using System;
using System.Collections.Generic;
using System.Linq;

namespace StackTests
{
    internal class Stack
    {
        private int Size = 0;
        public List<int> Items = new List<int>();

        public bool IsEmpty()
        {
            return Size == 0;
        }

        public void Push(int v)
        {
            AddItem(v);
        }

        public int Pop()
        {
            if (IsEmpty())
                throw new UnderflowException("Cannot Pop on empty Stack");

            return RemoveLastItem();
        }

        private void AddItem(int v)
        {
            Size++;
            Items.Add(v);
        }

        private int RemoveLastItem()
        {
            var last = Items.Last();
            Items.Remove(last);
            Size--;
            return last;
        }

        public class UnderflowException : Exception
        {
            public UnderflowException(string message) : base(message) { }
        }
    }
}