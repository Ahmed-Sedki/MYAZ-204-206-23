using LinkedList.Doubly;

namespace DoublyLinkedListTest
{
    public class DoublyLinkedListTests
    {
        [Fact]
        public void DoublyLinkedList_AddFirst_Check()
        {
            var linkedList = new DoublyLinkedList<int>();
            linkedList.AddFirst(1);
            linkedList.AddFirst(2);
            linkedList.AddFirst(3);
            linkedList.AddFirst(4);

            Assert.Equal(4, linkedList.Head.Value);
            Assert.Equal(3, linkedList.Head.Next.Value);
            Assert.Equal(2, linkedList.Tail.Prev.Value);
            Assert.Equal(1, linkedList.Tail.Value);
        }

        [Fact]
        public void DoublyLinkedList_AddLast_Check()
        {
            var linkedList = new DoublyLinkedList<int>();
            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);
            linkedList.AddLast(4);

            Assert.Equal(1, linkedList.Head.Value);
            Assert.Equal(2, linkedList.Head.Next.Value);
            Assert.Equal(3, linkedList.Tail.Prev.Value);
            Assert.Equal(4, linkedList.Tail.Value);
        }

        [Fact]
        public void DoublyLinkedList_RemoveFirst_Check()
        {
            var linkedList = new DoublyLinkedList<int>();
            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);
            linkedList.AddLast(4);

            var item1 = linkedList.RemoveFirst();
            var item2 = linkedList.RemoveFirst();
            var item3 = linkedList.RemoveFirst();
            var item4 = linkedList.RemoveFirst();

            Assert.Equal(1, item1);
            Assert.Equal(2, item2);
            Assert.Equal(3, item3);
            Assert.Equal(4, item4);
        }

        [Fact]
        public void DoublyLinkedList_RemoveFirst_ThrowsException()
        {
            var linkedList = new DoublyLinkedList<int>();
            Assert.Throws<Exception>(() => linkedList.RemoveFirst());
        }

        [Fact]
        public void DoublyLinkedList_RemoveLast_Check()
        {
            var linkedList = new DoublyLinkedList<int>();
            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);
            linkedList.AddLast(4);

            var lastItem = linkedList.RemoveLast();

            Assert.Equal(4, lastItem);
        }

        [Fact]
        public void DoublyLinkedList_Constructor_ArrayInput_Check()
        {
            var list = new DoublyLinkedList<int>(new int[] { 23, 16, 23, 55, 61, 23, 44 });

            Assert.Collection<int>(list,
                item => Assert.Equal(23, item),
                item => Assert.Equal(16, item),
                item => Assert.Equal(23, item),
                item => Assert.Equal(55, item),
                item => Assert.Equal(61, item),
                item => Assert.Equal(23, item),
                item => Assert.Equal(44, item));
        }
    }
}
