using Array;
using Queue.Contract;

namespace Queue
{
    public class ArrayQueue<T> : IQueue<T>
    {
        private readonly Array<T> _innerArray;

        public ArrayQueue()
        {
            _innerArray = new Array<T>();
        }

        public ArrayQueue(IEnumerable<T> collection) : this()
        {
            foreach (var item in collection)
            {
                Enqueue(item);
            }
        }

        public int Count => _innerArray.Count;

        public T Dequeue()
        {
            if (_innerArray.IsEmpty)
                throw new Exception("The queue is empty!");

            return _innerArray.RemoveItem(0);
        }

        public void Enqueue(T item)
        {
            _innerArray.Add(item);
        }

        public T Peek()
        {
            return _innerArray.IsEmpty ? default : _innerArray.GetItem(0);
        }
    }
}
