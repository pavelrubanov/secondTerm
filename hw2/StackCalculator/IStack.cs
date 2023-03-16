using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCalculator
{
    /// <summary>
    /// Classic stack with double elements
    /// </summary>
    public interface IStack
    {
        /// <summary>
        /// Add an element to the top of the stack
        /// </summary>
        /// <param name="value"></param>
        public void Push(double value);
        /// <summary>
        /// Remove and returns an element from the top of the stack
        /// </summary>
        /// <returns></returns>
        public double Pop();
        /// <summary>
        /// Returns an element from the top of the stack
        /// </summary>
        /// <returns></returns>
        public double Top();
        /// <summary>
        /// Return true if stack contains 0 elements
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty();
    }
}
