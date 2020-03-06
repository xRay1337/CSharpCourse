using System;
using System.Collections;
using System.Collections.Generic;

namespace ArrList
{
    class ArrList<T> : IList<T>
    {
        private T[] items = new T[10];

        private int length;

        public int Count
        {
            get { return length; }
        }

        private bool readOnly = false;

        public bool IsReadOnly
        {
            get { return readOnly; }
        }

        public T this[int index]
        {
            get { return items[index]; }
            set { items[index] = value; }
        }

        public void Add(T item)
        {
            if (IsReadOnly)
            {
                throw new InvalidOperationException("This array is read only");
            }

            if (length >= items.Length)
            {
                IncreaseCapacity();
            }

            items[length] = item;
            length++;
        }

        private void IncreaseCapacity()
        {
            T[] old = items;
            items = new T[old.Length * 2];
            Array.Copy(old, items, old.Length);
        }

        public void Clear()
        {
            if (IsReadOnly)
            {
                throw new InvalidOperationException("This array is read only");
            }

            items = new T[items.Length];
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex < 0 || arrayIndex >= array.Length)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = 0, j = arrayIndex; i < Count; i++, j++)
            {
                array[j] = items[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return items[i];
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (IsReadOnly)
            {
                throw new InvalidOperationException("This array is read only");
            }

            if (length + 1 > items.Length)
            {
                IncreaseCapacity();
            }

            length++;

            for (int i = length; i > index; i--)
            {
                items[i] = items[i - 1];
            }

            items[index] = item;
        }

        public bool Remove(T item)
        {
            if (IsReadOnly)
            {
                throw new InvalidOperationException("This array is read only");
            }

            bool flag = false;

            for (int i = 0; i < length; i++)
            {
                if (items[i].Equals(item))
                {
                    RemoveAt(i);
                    flag = true;
                }
            }

            return flag;
        }

        public void RemoveAt(int index)
        {
            if (IsReadOnly)
            {
                throw new InvalidOperationException("This array is read only");
            }

            if (index < 0 || index >= length)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = index; i < length - 1; i++)
            {
                items[i] = items[i + 1];
            }

            length--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }

        public override string ToString()
        {
            return "[ " + string.Join(", ", this) + " ]";
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

            ArrList<T> o = (ArrList<T>)obj;

            if (items.Length != o.items.Length)
            {
                return false;
            }

            for (int i = 0; i < items.Length; i++)
            {
                if (!items[i].Equals(o.items[i]))
                {
                    return false;
                }
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
    }
}
