namespace SinglyLinkedList
{
    class ListItem<T>
    {
        public T Data { get; set; }

        public ListItem<T> Next { get; set; }

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

            if (obj is null || obj.GetType() != GetType())
            {
                return false;
            }

            ListItem<T> item = (ListItem<T>)obj;

            return Data.Equals(item.Data);
        }

        public override int GetHashCode()
        {
            return Data.GetHashCode();
        }
    }
}