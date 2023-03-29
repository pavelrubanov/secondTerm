using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace UniqueList
{
    /// <summary>
    /// standard doubly linked list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class List<T> : IEnumerable<T>
    {
        public class ListElement<T>
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


        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public T this[int index]
        {
            get
            {
                if(index < 0 || index >= Size)
                {
                    throw new IndexOutOfRangeException();
                }
                var currentItem = First;
                for (int i = 0; i < index; i++)
                    currentItem = currentItem.Next;
                return currentItem.Value;
            }
        }

        public virtual void Add(T value)
        {
            switch (Size)
            {
                case 0:
                    var newEl = new ListElement<T>(value, null, null);
                    First = newEl;
                    Last = newEl;
                    break;
                case 1:
                    var newEl1 = new ListElement<T>(value, null, First);
                    Last = newEl1;
                    First.Next = Last;
                    break;
                default:
                    var newEl3 = new ListElement<T>(value, null, Last);
                    Last.Next = newEl3;
                    Last = newEl3;
                    break;
            }
            Size++;
        }
        /// <summary>
        /// removes the element at this index
        /// </summary>
        /// <param name="index"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
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
        /// <summary>
        /// change value of the element at this index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
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
