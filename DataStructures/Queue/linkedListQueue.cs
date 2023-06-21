using LinkedList.Doubly;
using Queue.Contract;


namespace Queue
{
    public class LinkedListQueue<T> : IQueue<T>
    {
        private DoublyLinkedList<T> _LinkedListQueue;
        public LinkedListQueue()
        {
            _LinkedListQueue = new DoublyLinkedList<T>();
        }
        public int Count => _LinkedListQueue.Count();

        public T Dequeue()
        {
            if (_LinkedListQueue.Head is null)
                throw new Exception("The queue is empty!");
            return _LinkedListQueue.RemoveFirst();
        }

        public void Enqueue(T item)
        {
            _LinkedListQueue.AddLast(item);
        }

        public T Peek()
        {
            return _LinkedListQueue.Head is null ? default : _LinkedListQueue.Head.Value;
        }
    }
}
