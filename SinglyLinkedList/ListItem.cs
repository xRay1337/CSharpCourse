namespace SinglyLinkedList
{
    class ListItem<T>
    {
        public T Data { get; set; }

        public ListItem<T> Next { get; set; }

        public ListItem() { }

        public ListItem(T data)
        {
            Data = data;
        }

        public ListItem(T data, ListItem<T> next)
        {
            Data = data;
            Next = next;
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

            return Data.Equals(((ListItem<T>)obj).Data);
        }

        public override int GetHashCode()
        {
            return Data.GetHashCode();
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}