using System;
using System.Collections;
using System.Collections.Generic;

namespace Lesson17.Collections
{
    public class Set<T> : ICollection<T>
    {
        private readonly LinkedList<T>[] _array;
        private readonly int _capacity;

        public Set(int capacity)
        {
            this._array = new LinkedList<T>[capacity];
            this._capacity = capacity;
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
                var index = item.GetHashCode() % this._capacity;
                var list = this._array[index] ?? new LinkedList<T>();

                list.Add(item);
                this._array[index] = list;
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
                throw new ArgumentNullException();
            }
            else
            {
                int index = item.GetHashCode() % this._capacity; // 5
                LinkedList<T> list = this._array[index]; // getting a 5th list of array

                if (list == null)
                {
                    return false;
                }

                return list.Contains(item); // if item in a 5th list
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