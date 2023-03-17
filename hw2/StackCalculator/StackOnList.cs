using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCalculator
{
    public class StackOnList : IStack
    {
        private List<double> array = new();
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
            var result = array[array.Count - 1];
            array.RemoveAt(array.Count - 1);
            return result;
        }

        public void Push(double value)
        {
            array.Add(value);
        }

        public double Top()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return array[array.Count - 1];
        }
    }
}
