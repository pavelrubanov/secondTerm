using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueList
{
    internal class UniqueList<T> : List<T>
    {
        public bool Contains(T value)
        {
            foreach (var elementValue in this)
            {
                if (elementValue.Equals(value))
                    return true;
            } 
            return false;
        }
        public override void Add(T value)
        {
            if (!Contains(value))
                base.Add(value);
            else
            {
                throw new ElementAlreadyExistException();
            }
        }
        public override void Change(int index, T value)
        {
            if (!Contains(value))
                base.Change(index, value);
            else
            {
                throw new ElementAlreadyExistException();
            }
        }
    }
}
