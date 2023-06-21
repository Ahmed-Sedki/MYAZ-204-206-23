using Queue;

namespace QueueTest
{
    public class LinkedListQueueTest
    {
        [Fact]
        public void QueueEnqueueTest()
        {
            var queue = new LinkedListQueue<int> { 1, 2, 3, 4, 5 };
            Assert.Equal(5, queue.Count);
            Assert.Equal(1, queue.Peek());
        }

        [Fact]
        public void QueueDequeueTest()
        {
            var queue = new LinkedListQueue<int> { 1, 2, 3, 4, 5 };
            Assert.Equal(1, queue.Dequeue());
            Assert.Equal(2, queue.Dequeue());
            Assert.Equal(3, queue.Dequeue());
            Assert.Equal(4, queue.Dequeue());
            Assert.Equal(5, queue.Dequeue());
        }

        [Fact]
        public void QueueDequeueExceptionTest() => Assert.Throws<Exception>(() => new LinkedListQueue<int>().Dequeue());
    }
}
