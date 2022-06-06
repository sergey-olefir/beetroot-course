using System;
using System.Collections;
using System.Collections.Generic;

namespace Lesson17.Collections
{
    public class LinkedList<T> : ICollection<T>
    {
        private class Node<T>
        {
            public Node(T value, Node<T> next)
            {
                Value = value;
                Next = next;
            }

            public T Value { get; }

            public Node<T> Next { get; set; }
        }

        private Node<T> head;
        private Node<T> tail;
        private int _count;

        public void Add(T item)
        {
            if (this.head == null)
            {
                this.head = new Node<T>(item, null);
                this.tail = this.head;
            }
            else
            {
                var newNode = new Node<T>(item, null);
                this.tail.Next = newNode;

                this.tail = newNode;
            }

            this._count++;
        }

        public IEnumerable<T> GetAll()
        {
            var item = this.head;
            while (item != null)
            {
                yield return item.Value;
                item = item.Next;
            }
        }

        public bool Contains(T item)
        {
            var pointer = this.head;
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
            => throw new NotImplementedException();

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}