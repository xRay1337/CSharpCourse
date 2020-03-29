using System;
using System.Collections;
using System.Collections.Generic;

namespace HashTable
{
    class HashTable<T> : ICollection<T>
    {
        private List<T>[] array;
        private int modCount;

        public HashTable() : this(10) { }

        public HashTable(int capacity)
        {
            if (capacity < 1)
            {
                throw new ArgumentException("Capacity must be greater than 0.", nameof(capacity));
            }

            array = new List<T>[capacity];
        }

        public int Count { get; private set; }

        public bool IsReadOnly => false;

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
                array[index] = new List<T>() { item };
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
                array[i] = null;
            }

            Count = 0;
        }

        public bool Contains(T item)
        {
            int index = GetIndex(item);

            if (array[index] != null && array[index].Contains(item))
            {
                return true;
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
            int index = GetIndex(item);

            if (array[index] == null)
            {
                return false;
            }

            modCount++;
            bool deleted = array[index].Remove(item);

            if (deleted)
            {
                Count--;
            }

            return deleted;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int initialModCount = modCount;

            foreach (var list in array)
            {
                if (list != null)
                {
                    foreach (var element in list)
                    {
                        if (initialModCount != modCount)
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

            if (obj is null || obj.GetType() != GetType())
            {
                return false;
            }

            HashTable<T> o = (HashTable<T>)obj;

            if (Count != o.Count)
            {
                return false;
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] is null && o.array[i] != null || array[i] != null && o.array[i] is null)
                {
                    return false;
                }

                if (array[i] is null && o.array[i] is null)
                {
                    continue;
                }

                if (array[i].Count != o.array[i].Count)
                {
                    return false;
                }

                T[] thisArray = new T[array[i].Count];
                T[] objArray = new T[o.array[i].Count];

                Array.Sort(thisArray);
                Array.Sort(objArray);

                for (int j = 0; j < thisArray.Length; j++)
                {
                    if (thisArray[j] is null && objArray[j] != null || thisArray[j] != null && objArray[j] is null)
                    {
                        return false;
                    }

                    if (thisArray[j] is null && objArray[j] is null)
                    {
                        continue;
                    }

                    if (!thisArray[j].Equals(objArray[j]))
                    {
                        return false;
                    }
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