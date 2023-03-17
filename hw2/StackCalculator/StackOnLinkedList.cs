using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCalculator
{
    public class StackOnLinkedList : IStack
    {
        private LinkedList<double> array = new();
        public bool IsEmpty()
        {
            if (array.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public double Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }
            var result = array.Last.Value;
            array.RemoveLast();
            return result;
        }

        public void Push(double value)
        {
            array.AddLast(value);
        }

        public double Top()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return array.Last.Value;
        }
    }
}
