using System;
using System.Collections.Generic;

namespace StackTests
{
    internal class Stack
    {
        internal List<int> Items = new List<int>();

        internal void Pop()
        {
            if (Items.Count == 0)
                throw new UnderflowException();
            else
            {
                Items.RemoveAt(Items.Count - 1);
            }
        }

        internal void Push(int v)
        {
            Items.Add(v);
        }

        internal bool IsEmpty()
        {
            return Items.Count == 0;
        }

        internal class UnderflowException : Exception
        {
        }
    }
}