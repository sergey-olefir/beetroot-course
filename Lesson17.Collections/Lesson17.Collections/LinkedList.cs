using System;
using System.Collections;
using System.Collections.Generic;

namespace Lesson17.Collections
{
    public class LinkedListEnumerator<T> : IEnumerator<T>
    {
        private readonly LinkedList<T> _list;
        private int _index;

        public LinkedListEnumerator(LinkedList<T> list)
        {
            this._list = list;
        }

        public bool MoveNext()
        {
            if (this._index < this._list.Count)
            {
                Current = this._list.GetByIndex(this._index++);
                return true;
            }

            return false;
        }

        public T Current { get; private set; }

        public void Reset()
        {
            this._index = 0;
        }

        object IEnumerator.Current { get; }

        public void Dispose()
        {
        }
    }

    public class LinkedList<T> : ICollection<T>
    {
        private class Node<T>
        {
            public Node(T value, Node<T> next)
            {
                this.Value = value;
                this.Next = next;
            }

            public T Value { get; }

            public Node<T> Next { get; set; }
        }

        private Node<T> _head;
        private Node<T> _tail;
        private int _count;

        public void Add(T item)
        {
            if (this._head == null)
            {
                this._head = new Node<T>(item, null);
                this._tail = this._head;
            }
            else
            {
                var newNode = new Node<T>(item, null);
                this._tail.Next = newNode;

                this._tail = newNode;
            }

            this._count++;
        }

        public IEnumerable<T> GetAll()
        {
            var item = this._head;
            while (item != null)
            {
                yield return item.Value;
                item = item.Next;
            }
        }

        public bool Contains(T item)
        {
            var pointer = this._head;
            while (pointer != null)
            {
                if (pointer.Value.Equals(item))
                {
                    return true;
                }
                pointer = pointer.Next;
            }

            return false;
        }

        public T GetByIndex(int index)
        {
            if (index < 0 || index >= this._count)
            {
                throw new IndexOutOfRangeException();
            }

            var pointer = this._head;
            for (int i = 0; i < index; i++)
            {
                pointer = pointer.Next;
            }

            return pointer.Value;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
            => throw new NotImplementedException();

        public int Count => this._count;

        public bool IsReadOnly { get; } = false;

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
            => new LinkedListEnumerator<T>(this);

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}