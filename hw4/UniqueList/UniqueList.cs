using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueList
{
    /// <summary>
    /// doubly linked list with unique elements
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class UniqueList<T> : List<T>
    {

        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(T value)
        {
            foreach (var elementValue in this)
            {
                if (elementValue.Equals(value))
                    return true;
            } 
            return false;
        }

        /// <param name="value"></param>
        /// <exception cref="ElementAlreadyExistException"></exception>
        public override void Add(T value)
        {
            if (!Contains(value))
                base.Add(value);
            else
            {
                throw new ElementAlreadyExistException();
            }
        }

        /// <param name="index"></param>
        /// <param name="newValue"></param>
        /// <exception cref="ElementAlreadyExistException"></exception>
        public override void Change(int index, T newValue)
        {
            if (this[index].Equals(newValue))
                return;

            if (!Contains(newValue))
                base.Change(index, newValue);
            else
            {
                throw new ElementAlreadyExistException();
            }
        }
    }
}
