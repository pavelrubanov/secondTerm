using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace UniqueList
{
    internal class List<T> : IEnumerable<T>
    {
        internal class ListElement<T>
        {
            public ListElement<T>? Next { get; set; }
            public ListElement<T>? Previous { get; set; }

            public T Value { get; set; }

            public ListElement(T value, ListElement<T>? next, ListElement<T>? previous)
            {
                Value = value;
                Next = next;
                Previous = previous;
            }
        }

        public ListElement<T>? First { get; private set; }
        public ListElement<T>? Last { get; private set; }
        public int Size { get; private set; }
        public virtual void Add(T value)
        {
            Last.Next = new ListElement<T>(value, null, Last);
            Size++;
        }

        public virtual void Remove(int index)
        {
            if (index < 0 || index >= Size)
            {
                throw new IndexOutOfRangeException();
            }

            var currentItem = First;
            for (int i = 0; i < index; i++)
                currentItem = currentItem.Next;

            if (currentItem.Previous != null) 
                currentItem.Previous.Next = currentItem.Next;
            if (currentItem.Next != null)
                currentItem.Next.Previous = currentItem.Previous;
        }

        public virtual void Change(int index, T value)
        {
            
            if (index < 0 || index >= Size)
            {
                throw new IndexOutOfRangeException();
            }

            var currentItem = First;
            for (int i = 0; i < index; i++)
                currentItem = currentItem.Next;
            currentItem.Value = value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var item = First;
            while (item != null)
            {
                yield return item.Value;
                item = item.Next;
            } 
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
