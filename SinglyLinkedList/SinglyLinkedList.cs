using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SinglyLinkedList
{
    class SinglyLinkedList<T> : IEnumerable<T>
    {
        private ListItem<T> first;

        public T First { get => first.Data; }

        public int Count { get; private set; }

        private int modCount;

        public void Add(T data)
        {
            modCount++;

            ListItem<T> newItem = new ListItem<T>(data);

            if (first == null)
            {
                first = newItem;
            }
            else
            {
                ListItem<T> last = first;

                while (last.Next != null)
                {
                    last = last.Next;
                }

                last.Next = newItem;
            }

            Count++;
        }

        public T ElementAt(int index)
        {
            CheckIndex(index, Count);

            ListItem<T> result = first;

            int i = 0;

            for (ListItem<T> current = first; current != null; current = current.Next, i++)
            {
                if (i == index)
                {
                    return current.Data;
                }
            }

            return result.Data;
        }

        public bool Remove(T data)
        {
            modCount++;

            if (first != null && ((first.Data == null && data == null) || first.Data.Equals(data)))
            {
                first = first.Next;
                Count--;
                return true;
            }

            ListItem<T> prev = first;
            ListItem<T> current = first.Next;

            for (int i = 1; i < Count - 1; i++)
            {
                prev = current;
                current = current.Next;

                if ((current.Data == null && data == null) || current.Data.Equals(data))
                {
                    prev.Next = current.Next;
                    Count--;
                    return true;
                }
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
                ListItem<T> deleted = first;
                first = first.Next;
                Count--;
                return deleted.Data;
            }

            ListItem<T> prev = first;
            ListItem<T> current = first;

            FindItem(index, ref prev, ref current);

            prev.Next = current.Next;

            Count--;
            return current.Data;
        }

        public T SetAt(int index, T data)
        {
            CheckIndex(index, Count);
            modCount++;

            ListItem<T> current = first;

            for (int i = 1; i <= index; i++)
            {
                current = current.Next;
            }

            T oldData = current.Data;
            current.Data = data;

            return oldData;
        }

        public void InsertFirst(T data)
        {
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

            ListItem<T> prev = first;
            ListItem<T> current = first.Next;

            FindItem(index, ref prev, ref current);

            ListItem<T> newItem = new ListItem<T>(data);

            prev.Next = newItem;
            newItem.Next = current;

            Count++;
        }

        public void Reverse()
        {
            modCount++;
            SinglyLinkedList<T> newList = new SinglyLinkedList<T>();

            foreach (var e in this)
            {
                newList.InsertFirst(e);
            }

            first = newList.first;
        }

        public SinglyLinkedList<T> Copy()
        {
            SinglyLinkedList<T> newList = new SinglyLinkedList<T>();

            if (first == null)
            {
                return newList;
            }

            newList.first = new ListItem<T>(first.Data);

            ListItem<T> currentOld = first.Next;
            ListItem<T> currentNew = newList.first;

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
                throw new ArgumentException("Need positive index.", nameof(index));
            }

            if (index >= maxIndex)
            {
                throw new IndexOutOfRangeException("The index must be smaller than the list.");
            }
        }

        private void FindItem(int index, ref ListItem<T> prev, ref ListItem<T> current)
        {
            for (int i = 0; i < index; i++)
            {
                prev = current;
                current = current.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int initialModCount = modCount;

            ListItem<T> current = first;

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

            SinglyLinkedList<T> inputList = (SinglyLinkedList<T>)obj;

            if (Count != inputList.Count)
            {
                return false;
            }

            ListItem<T> thisItem = first;
            ListItem<T> inputItem = inputList.first;

            for (int i = 0; i < Count; i++)
            {
                if (!thisItem.Equals(inputItem))
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
            StringBuilder result = new StringBuilder("[ ");

            foreach (var e in this)
            {
                result.Append(e).Append(", ");
            }

            if (result.Length > 2)
            {
                result.Remove(result.Length - 2, 2);
            }

            result.Append(" ]");

            return result.ToString();
        }
    }
}