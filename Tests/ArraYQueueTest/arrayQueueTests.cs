using Queue;

namespace ArraYQueueTest
{
    public class ArrayQueueTests
    {
        [Fact]
        public void ArrayQueue_Enqueue_Test()
        {
            var queue = new ArrayQueue<char>("Mehmet");
            queue.Enqueue('A');
            Assert.Equal(7, queue.Count);
        }

        [Fact]
        public void ArrayQueue_Dequeue_Test()
        {
            var queue = new ArrayQueue<char>("Mehmet");
            Assert.Equal('M', queue.Dequeue());
            Assert.Equal(5, queue.Count);
        }

        [Fact]
        public void ArrayQueue_Dequeue_Exception_Test()
        {
            Assert.Throws<Exception>(() => new ArrayQueue<char>().Dequeue());
        }

        [Fact]
        public void ArrayQueue_Peek_Test()
        {
            Assert.Equal('M', new ArrayQueue<char>("Mehmet").Peek());
        }
    }
}
