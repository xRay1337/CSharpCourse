using System;
using System.Collections;
using System.Collections.Generic;

namespace HashTable
{
    class HashTable<T> : ICollection<T>
    {
        private List<T>[] array;

        public HashTable() : this(1000) { }

        public HashTable(int capacity)
        {
            array = new List<T>[capacity];
        }

        public int Count { get; private set; }

        private int modCount = 0;

        public bool IsReadOnly
        {
            get => false;
        }

        private int GetIndex(T item)
        {
            return Math.Abs(item.GetHashCode() % array.Length);
        }

        public void Add(T item)
        {
            modCount++;

            int index = GetIndex(item);

            if (array[index] == null)
            {
                array[index] = new List<T>(1) { item };
            }
            else if (array[index].Contains(item))
            {
                return;
            }
            else
            {
                array[index].Add(item);
            }

            Count++;
        }

        public void Clear()
        {
            modCount++;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = default;
            }

            Count = 0;
        }

        public bool Contains(T item)
        {
            int index = GetIndex(item);

            if (array[index] != null)
            {
                foreach (var e in array[index])
                {
                    if (e.Equals(item))
                    {
                        return true;
                    }
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

            if (Count > array.Length - index)
            {
                throw new ArgumentException("The number of elements in the source array is greater than the available number of elements from the index to the end of the destination array.");
            }

            Array.Copy(this.array, 0, array, index, Count);
        }

        public bool Remove(T item)
        {
            modCount++;
            int index = GetIndex(item);

            if (array[index] == null)
            {
                return false;
            }

            bool deleted = array[index].Remove(item);

            if (deleted)
            {
                Count--;
            }

            return deleted;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int modNumber = modCount;

            foreach (var index in array)
            {
                if (index != null)
                {
                    foreach (var element in index)
                    {
                        if (modNumber != modCount)
                        {
                            throw new InvalidOperationException("Table has been changed.");
                        }

                        yield return element;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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

            HashTable<T> o = (HashTable<T>)obj;

            if (Count != o.Count)
            {
                return false;
            }

            foreach (var e in this)
            {
                if (!o.Contains(e))
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