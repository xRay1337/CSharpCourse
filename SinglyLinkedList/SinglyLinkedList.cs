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
                    throw new NullReferenceException("The list is empty.");
                }

                return first.Data;
            }
        }

        public int Count { get; private set; }

        public void Add(T data)
        {
            modCount++;

            var newItem = new ListItem<T>(data);

            if (first == null)
            {
                first = newItem;
            }
            else
            {
                var last = first;

                while (last.Next != null)
                {
                    last = last.Next;
                }

                last.Next = newItem;
            }

            Count++;
        }

        public T GetElement(int index)
        {
            CheckIndex(index, Count);

            var result = FindItem(index);

            return result.Data;
        }

        public bool Remove(T data)
        {
            if (Count == 0)
            {
                return false;
            }

            if (Equals(first.Data, null) && Equals(data, null) || first.Data.Equals(data))
            {
                first = first.Next;
                modCount++;
                Count--;
                return true;
            }

            var prev = first;
            var current = first.Next;

            for (int i = 1; i < Count - 1; i++)
            {
                if ((Equals(current.Data, null) && Equals(data, null)) || current.Data.Equals(data))
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

            T firstData = first.Data;
            RemoveAt(0);
            return firstData;
        }

        public T RemoveAt(int index)
        {
            CheckIndex(index, Count);
            modCount++;

            if (index == 0)
            {
                var deleted = first;
                first = first.Next;
                Count--;
                return deleted.Data;
            }

            if (index == Count - 1)
            {
                var penultItem = FindItem(index - 1);
                T deleted = penultItem.Next.Data;
                penultItem.Next = null;
                Count--;
                return deleted;
            }

            var prev = FindItem(index - 1);
            var current = prev.Next;

            prev.Next = current.Next;

            Count--;
            return current.Data;
        }

        public T SetAt(int index, T data)
        {
            CheckIndex(index, Count);
            modCount++;

            var current = FindItem(index);

            T oldData = current.Data;
            current.Data = data;

            return oldData;
        }

        public void InsertFirst(T data)
        {
            modCount++;
            first = new ListItem<T>(data, first);
            Count++;
        }

        public void InsertAt(int index, T data)
        {
            CheckIndex(index, Count + 1);
            modCount++;

            if (index == 0)
            {
                InsertFirst(data);
                return;
            }

            var prev = FindItem(index);
            var current = prev.Next;
            var newItem = new ListItem<T>(data);

            prev.Next = newItem;
            newItem.Next = current;

            Count++;
        }

        public void Reverse()
        {
            if (Count == 0 || Count == 1)
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

            for (int i = 1; i < Count; i++)
            {
                currentNew.Next = new ListItem<T>(currentOld.Data);

                currentOld = currentOld.Next;
                currentNew = currentNew.Next;
            }

            return newList;
        }

        private void CheckIndex(int index, int maxIndex)
        {
            if (index < 0)
            {
                throw new ArgumentException("Index cannot be negative.", nameof(index));
            }

            if (index >= maxIndex)
            {
                throw new IndexOutOfRangeException($"The index should not exceed {Count}.");
            }
        }

        private ListItem<T> FindItem(int index)
        {
            CheckIndex(index, Count);

            if (index == 0)
            {
                return first;
            }

            var prev = first;
            var current = first.Next;

            for (int i = 1; i < index; i++)
            {
                prev = current;
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

            for (int i = 0; i < Count; i++)
            {
                if (!thisItem.Data.Equals(inputItem.Data))
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