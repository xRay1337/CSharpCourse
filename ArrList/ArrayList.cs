using System;
using System.Collections;
using System.Collections.Generic;

namespace ArrayList
{
    class ArrayList<T> : IList<T>
    {
        private T[] items;

        public int Count { get; private set; }

        private int ModCount { get; set; }

        public int Capacity
        {
            get
            {
                return items.Length;
            }
            set
            {
                if (value < Count)
                {
                    throw new ArgumentOutOfRangeException("Value less than list size.", nameof(value));
                }

                if (value > Count)
                {
                    T[] old = items;
                    items = new T[value];
                    Array.Copy(old, items, old.Length);
                }
            }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("Invalid value.");
                }

                return items[index];
            }
            set
            {
                items[index] = value;
            }
        }

        public ArrayList()
        {
            items = new T[10];
        }

        public ArrayList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("Need positive capacity.", nameof(capacity));
            }

            items = new T[capacity];
        }

        public void Add(T item)
        {
            if (Count >= items.Length)
            {
                IncreaseCapacity();
            }

            items[Count] = item;
            Count++;
            ModCount++;
        }

        private void IncreaseCapacity()
        {
            T[] old = items;
            items = new T[old.Length * 2];
            Array.Copy(old, items, old.Length);
        }

        public void Clear()
        {
            items = new T[items.Length];
            ModCount++;
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

        public void CopyTo(T[] array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array should not be NULL.");
            }

            if (index > array.Length - 1)
            {
                throw new ArgumentOutOfRangeException("Index is less than the bottom of the array.", nameof(index));
            }

            if (array.Rank != 1)
            {
                throw new ArgumentException("The destination array is multidimensional.");
            }

            if (Count > array.Length - index)
            {
                throw new ArgumentException("The number of elements in the source array is greater than the available number of elements from the index to the end of the destination array.");
            }

            Array.Copy(items, 0, array, index, Count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            int modNumber = ModCount;

            for (int i = 0; i < Count; i++)
            {
                if (modNumber != ModCount)
                {
                    throw new InvalidOperationException("List has been changed.");
                }

                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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
            if (Count + 1 > items.Length)
            {
                IncreaseCapacity();
            }

            Count++;

            for (int i = Count; i > index; i--)
            {
                items[i] = items[i - 1];
            }

            items[index] = item;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(item))
                {
                    RemoveAt(i);
                    return true;
                }
            }

            ModCount++;
            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Invalid value.");
            }

            for (int i = index; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }

            Count--;
            ModCount++;
        }

        public void TrimExcess()
        {
            T[] old = items;
            items = new T[Count];
            Array.Copy(old, items, Count);
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

            ArrayList<T> o = (ArrayList<T>)obj;

            if (Count != o.Count)
            {
                return false;
            }

            for (int i = 0; i < Count; i++)
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
