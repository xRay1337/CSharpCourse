using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SinglyLinkedList
{
    class SinglyLinkedList<T> : IEnumerable<T>
    {
        private int modCount;
        private ListItem<T> first;

        public T First
        {
            get
            {
                if (first == null)
                {
                    throw new InvalidOperationException("The list is empty.");
                }

                return first.Data;
            }
        }

        public int Count { get; private set; }

        public T GetElement(int index)
        {
            return FindItem(index).Data;
        }

        public T SetElement(int index, T data)
        {
            var current = FindItem(index);

            modCount++;

            var oldData = current.Data;
            current.Data = data;

            return oldData;
        }

        public bool Remove(T data)
        {
            if (Count == 0)
            {
                return false;
            }

            if (Equals(first.Data, data))
            {
                RemoveFirst();
                return true;
            }

            var prev = first;
            var current = first.Next;

            for (var i = 1; i < Count; i++)
            {
                if (Equals(current.Data, data))
                {
                    prev.Next = current.Next;
                    modCount++;
                    Count--;
                    return true;
                }

                prev = current;
                current = current.Next;
            }

            return false;
        }

        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty.");
            }

            modCount++;
            var deleted = first;
            first = first.Next;
            Count--;
            return deleted.Data;
        }

        public T RemoveAt(int index)
        {
            CheckIndex(index, Count - 1);

            if (index == 0)
            {
                return RemoveFirst();
            }

            modCount++;
            var prev = FindItem(index - 1);
            var current = prev.Next;

            prev.Next = current.Next;
            Count--;

            return current.Data;
        }

        public void InsertFirst(T data)
        {
            modCount++;
            first = new ListItem<T>(data, first);
            Count++;
        }

        public void InsertAt(int index, T data)
        {
            CheckIndex(index, Count);

            if (index == 0)
            {
                InsertFirst(data);
                return;
            }

            modCount++;
            var prev = FindItem(index - 1);
            var current = prev.Next;
            var newItem = new ListItem<T>(data);

            prev.Next = newItem;
            newItem.Next = current;

            Count++;
        }

        public void Add(T data)
        {
            InsertAt(Count, data);
        }

        public void Reverse()
        {
            if (Count <= 1)
            {
                return;
            }

            modCount++;

            var prev = first;
            var current = first.Next;
            prev.Next = null;

            while (current != null)
            {
                var next = current.Next;
                current.Next = prev;

                prev = current;
                current = next;
            }

            first = prev;
        }

        public SinglyLinkedList<T> Copy()
        {
            var newList = new SinglyLinkedList<T>();

            if (first == null)
            {
                return newList;
            }

            newList.first = new ListItem<T>(first.Data);

            var currentOld = first.Next;
            var currentNew = newList.first;

            for (var i = 1; i < Count; i++)
            {
                currentNew.Next = new ListItem<T>(currentOld.Data);

                currentOld = currentOld.Next;
                currentNew = currentNew.Next;
            }

            newList.Count = Count;

            return newList;
        }

        private void CheckIndex(int index, int maxIndex)
        {
            if (index < 0)
            {
                throw new ArgumentException("Index cannot be negative.", nameof(index));
            }

            if (index > maxIndex)
            {
                throw new IndexOutOfRangeException($"The index should not exceed {Count}.");
            }
        }

        private ListItem<T> FindItem(int index)
        {
            CheckIndex(index, Count - 1);

            if (index == 0)
            {
                return first;
            }

            var current = first.Next;

            for (var i = 1; i < index; i++)
            {
                current = current.Next;
            }

            return current;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var initialModCount = modCount;

            var current = first;

            while (current != null)
            {
                if (initialModCount != modCount)
                {
                    throw new InvalidOperationException("List has been changed.");
                }

                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var inputList = (SinglyLinkedList<T>)obj;

            if (Count != inputList.Count)
            {
                return false;
            }

            var thisItem = first;
            var inputItem = inputList.first;

            for (var i = 0; i < Count; i++)
            {
                if (!Equals(inputItem.Data, thisItem.Data))
                {
                    return false;
                }

                thisItem = thisItem.Next;
                inputItem = inputItem.Next;
            }

            return true;
        }

        public override int GetHashCode()
        {
            int prime = 47;
            int hash = 1;

            foreach (var e in this)
            {
                if (e == null)
                {
                    continue;
                }

                hash = prime * hash + e.GetHashCode();
            }

            return hash;
        }

        public override string ToString()
        {
            var result = new StringBuilder("[");

            foreach (var e in this)
            {
                result.Append(e).Append(", ");
            }

            if (result.Length > 2)
            {
                result.Remove(result.Length - 2, 2);
            }

            result.Append("]");

            return result.ToString();
        }
    }
}