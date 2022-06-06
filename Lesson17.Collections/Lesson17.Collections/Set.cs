using System;
using System.Collections;
using System.Collections.Generic;

namespace Lesson17.Collections
{
    public class Set<T> : ICollection<T>
    {
        private LinkedList<T>[] array;
        private int capacity;

        public Set(int capacity)
        {
            this.array = new LinkedList<T>[capacity];
            this.capacity = capacity;
        }

        public IEnumerator<T> GetEnumerator()
            => throw new System.NotImplementedException();

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        public void Add(T item)
        {
            if (item == null)
            {
                Console.WriteLine("Item is null");
            }
            else
            {
                var index = item.GetHashCode() % this.capacity;
                var list = this.array[index] ?? new LinkedList<T>();

                list.Add(item);
                this.array[index] = list;
            }
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(T item)
        {
            if (item == null)
            {
                Console.WriteLine("Item is null");
            }
            else
            {
                int index = item.GetHashCode() % this.capacity;         // 5
                LinkedList<T> list = this.array[index];                 // getting a 5th list of array

                if (list == null)
                {
                    return false;
                }

                return list.Contains(item);                             // if item in a 5th list
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(T item)
            => throw new System.NotImplementedException();

        public int Count { get; }

        public bool IsReadOnly { get; }
    }
}