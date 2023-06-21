using System.Collections;

namespace LinkedList.Doubly
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        public DbNode<T>? Head { get; set; }
        public DbNode<T>? Tail { get; set; }
        private bool IsHeadNull { get; set; }

        public DoublyLinkedList()
        {
            IsHeadNull = true;
        }

        public DoublyLinkedList(IEnumerable<T> collection)
        {
            IsHeadNull = true;
            foreach (var item in collection)
            {
                AddLast(item);
            }
        }

        public void AddFirst(T item)
        {
            var node = new DbNode<T>(item);
            if (IsHeadNull)
            {
                Head = node;
                Tail = node;
                IsHeadNull = false;
                return;
            }

            Head.Prev = node;
            node.Next = Head;
            Head = node;
        }
        public void AddLast(T item)
        {
            var node = new DbNode<T>(item);
            if (IsHeadNull)
            {
                Head = node;
                Tail = node; 
                IsHeadNull = false;
                return; 
            }

            Tail.Next = node;
            node.Prev = Tail;
            Tail = node;
        }
        public T RemoveFirst()
        {
            if (IsHeadNull)
                throw new Exception("The linked list is empty!");

            T? item;
            if (Head.Equals(Tail))
            {
                item = Head.Value;
                Head = null;
                Tail = null;
                return item;
            }

            item = Head.Value;
            Head = Head.Next;
            Head.Prev = null;
            return item;
        }
        public T RemoveLast()
        {
            if (IsHeadNull)
                throw new Exception("The linked list is empty!");

            T item = Tail.Value;
            Tail = Tail.Prev;
            Tail.Next = null;
            return item;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new DbLinkedListEnumerator<T>(Head, Tail);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
