using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SinglyLinkedList
{
    class SinglyLinkedList<T> : IEnumerable<T>
    {
        public ListItem<T> First { get; private set; }

        public int Count { get; private set; }

        private int modCount;

        public SinglyLinkedList() { }

        public void Add(T data)
        {
            CheckData(data);
            modCount++;

            ListItem<T> newItem = new ListItem<T>(data);

            if (First == null)
            {
                First = newItem;
            }
            else
            {
                ListItem<T> last = First;

                while (last.Next != null)
                {
                    last = last.Next;
                }

                last.Next = newItem;
            }

            Count++;
        }

        public ListItem<T> ElementAt(int index)
        {
            CheckIndex(index);

            ListItem<T> result = First;

            int i = 0;

            for (ListItem<T> current = First; current != null; current = current.Next, i++)
            {
                if (i == index)
                {
                    return current;
                }
            }

            return result;
        }

        public bool Remove(T data)
        {
            CheckData(data);
            modCount++;

            if (First != null && First.Data.Equals(data))
            {
                First = First.Next;
                Count--;
                return true;
            }

            ListItem<T> prev = First;
            ListItem<T> current = First.Next;

            for (int i = 1; i < Count - 1; i++)
            {
                prev = current;
                current = current.Next;

                if (current.Data.Equals(data))
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
            T firstData = First.Data;
            RemoveAt(0);
            return firstData;
        }

        public ListItem<T> RemoveAt(int index)
        {
            CheckIndex(index);
            modCount++;

            if (index == 0)
            {
                ListItem<T> deleted = First;
                First = First.Next;
                Count--;
                return deleted;
            }

            ListItem<T> prev = First;
            ListItem<T> current = First;

            for (int i = 0; i < index; i++)
            {
                prev = current;
                current = current.Next;
            }

            prev.Next = current.Next;

            Count--;
            return current;
        }

        public T SetAt(int index, T data)
        {
            CheckIndex(index);
            CheckData(data);
            modCount++;

            ListItem<T> current = First;

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
            CheckData(data);
            First = new ListItem<T>(data, First);
            Count++;
        }

        public void InsertAt(int index, T data)
        {
            CheckIndex(index);
            CheckData(data);
            modCount++;

            if (index == 0)
            {
                InsertFirst(data);
                return;
            }

            ListItem<T> prev = First;
            ListItem<T> current = First.Next;

            for (int i = 1; i <= index; i++)
            {
                prev = current;
                current = current.Next;
            }

            ListItem<T> newItem = new ListItem<T>(data);

            prev.Next = newItem;
            newItem.Next = current;

            Count++;
        }

        public void Reverce()
        {
            modCount++;
            SinglyLinkedList<T> newList = new SinglyLinkedList<T>();

            foreach (var e in this)
            {
                newList.InsertFirst(e);
            }

            First = newList.First;
        }

        public void Copy(ref SinglyLinkedList<T> singlyLinkedList)
        {
            singlyLinkedList = new SinglyLinkedList<T>()
            {
                First = new ListItem<T>(First.Data)
            };

            ListItem<T> currentSource = First.Next;
            ListItem<T> currentOutput = singlyLinkedList.First;

            for (int i = 1; i < Count; i++)
            {
                currentOutput.Next = new ListItem<T>(currentSource.Data);

                currentSource = currentSource.Next;
                currentOutput = currentOutput.Next;
            }
        }

        private void CheckIndex(int index)
        {
            if (index < 0)
            {
                throw new ArgumentException("Need positie index.", nameof(index));
            }

            if (index >= Count)
            {
                throw new IndexOutOfRangeException("The index must be smaller than the list.");
            }
        }

        private void CheckData(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("Data must not be null.", nameof(data));
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int initialModCount = modCount;

            ListItem<T> current = First;

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
            return ((IEnumerable)this).GetEnumerator();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            SinglyLinkedList<T> inputList = (SinglyLinkedList<T>)obj;

            if(Count != inputList.Count)
            {
                return false;
            }

            ListItem<T> thisItem = First;
            ListItem<T> inputItem = inputList.First;

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