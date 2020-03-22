using System;
using System.Collections;
using System.Collections.Generic;

namespace ArrayList
{
    class ArrayList<T> : IList<T>
    {
        private T[] items;
        private int modCount = 0;

        public int Count { get; private set; }

        public int Capacity
        {
            get => items.Length;

            set
            {
                if (value < Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Value less than list size.");
                }

                if (value > Count)
                {
                    modCount++;
                    Array.Resize(ref items, value);
                }
            }
        }

        public bool IsReadOnly
        {
            get => false;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Invalid index.");
                }

                return items[index];
            }

            set
            {
                modCount++;

                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Invalid index.");
                }

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
                throw new ArgumentOutOfRangeException(nameof(capacity), "A non-negative number is required.");
            }

            items = new T[capacity];
        }

        public void Add(T item)
        {
            modCount++;

            if (Count >= items.Length)
            {
                IncreaseCapacity();
            }

            items[Count] = item;
            Count++;
        }

        private void IncreaseCapacity()
        {
            modCount++;

            if (items.Length == 0)
            {
                Array.Resize(ref items, 1);
            }
            else
            {
                Array.Resize(ref items, items.Length * 2);
            }
        }

        public void Clear()
        {
            modCount++;

            for (int i = 0; i < Count; i++)
            {
                items[i] = default;
            }

            Count = 0;
        }

        public bool Contains(T item)
        {
            //if(item == null)
            //{

            //}

            return IndexOf(item) >= 0 ? true : false;
        }

        public void CopyTo(T[] array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Array should not be NULL.");
            }

            if (Count > array.Length - index)
            {
                throw new ArgumentException("The number of elements in the source array is greater than the available number of elements from the index to the end of the destination array.", nameof(index));
            }

            Array.Copy(items, 0, array, index, Count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            int modNumber = modCount;

            for (int i = 0; i < Count; i++)
            {
                if (modNumber != modCount)
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
            if (index < 0 || index > Count + 1)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Invalid index.");
            }

            if (Count + 1 == items.Length)
            {
                IncreaseCapacity();
            }

            modCount++;
            Count++;

            Array.Copy(items, index, items, index + 1, Count - index);

            items[index] = item;
        }

        public bool Remove(T item)
        {
            int itemIndex = IndexOf(item);

            if (itemIndex != -1)
            {
                RemoveAt(itemIndex);
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Invalid index.");
            }

            modCount++;

            Array.Copy(items, index + 1, items, index, Count - index - 1);

            Count--;
        }

        public void TrimExcess()
        {
            if (items.Length != Count)
            {
                Array.Resize(ref items, Count);
            }
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