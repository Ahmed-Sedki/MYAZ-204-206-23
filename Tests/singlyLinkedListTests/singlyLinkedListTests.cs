using LinkedList.Singly;

namespace SinglyLinkedListTests
{
    public class SinglyLinkedListTests
    {
        [Fact]
        public void SinglyLinkedList_AddFirst_Test()
        {
            var linkedList = new SinglyLinkedList<int>();
            linkedList.AddFirst(10);
            linkedList.AddFirst(20);
            linkedList.AddFirst(30);
            Assert.Equal("30", linkedList.Head.ToString());
            Assert.Equal(20, linkedList.Head.Next.Value);
            Assert.Equal(10, linkedList.Head.Next.Next.Value);
        }

        [Fact]
        public void SinglyLinkedList_AddLast_Test()
        {
            var linkedList = new SinglyLinkedList<int>();
            linkedList.AddLast(10);
            linkedList.AddLast(20);
            linkedList.AddLast(30);
            Assert.Equal("10", linkedList.Head.ToString());
            Assert.Equal(20, linkedList.Head.Next.Value);
            Assert.Equal(30, linkedList.Head.Next.Next.Value);
        }

        [Fact]
        public void SinglyLinkedList_AddBefore_Test()
        {
            var linkedList = new SinglyLinkedList<char>();
            linkedList.AddFirst('a');
            linkedList.AddFirst('b');
            linkedList.AddFirst('c');
            linkedList.AddBefore(linkedList.Head.Next, 'x');
            Assert.Equal('c', linkedList.Head.Value);
            Assert.Equal('x', linkedList.Head.Next.Value);
        }

        [Fact]
        public void SinglyLinkedList_AddBefore_Throw_ExceptionTest()
        {
            var linkedList = new SinglyLinkedList<char>();
            var node = new SinglyLinkedListNode<char>('y');
            Assert.Throws<Exception>(() => linkedList.AddBefore(node, 'x'));
        }

        [Fact]
        public void SinglyLinkedList_AddAfter_Test()
        {
            var linkedList = new SinglyLinkedList<char>();
            linkedList.AddFirst('a');
            linkedList.AddFirst('b');
            linkedList.AddFirst('c');
            linkedList.AddAfter(linkedList.Head.Next, 'x');
            Assert.Equal(linkedList.Head.Value, 'c');
            Assert.Equal(linkedList.Head.Next.Next.Value, 'x');
        }

        [Fact]
        public void SinglyLinkedList_AddAfter_Throw_ExceptionTest()
        {
            var linkedList = new SinglyLinkedList<char>();
            var node = new SinglyLinkedListNode<char>('y');
            Assert.Throws<Exception>(() => linkedList.AddAfter(node, 'x'));
        }

        [Fact]
        public void SinglyLinkedList_RemoveFirst_Test()
        {
            var linkedList = new SinglyLinkedList<char>();
            linkedList.AddFirst('a');
            linkedList.AddFirst('b');
            linkedList.AddFirst('c');
            var item = linkedList.RemoveFirst();
            Assert.Equal('c', item);
            Assert.Equal('b', linkedList.Head.Value);
        }

        [Fact]
        public void SinglyLinkedList_RemoveFirst_One_Item_Test()
        {
            var linkedList = new SinglyLinkedList<char>();
            linkedList.AddFirst('a');
            var item = linkedList.RemoveFirst();
            Assert.Equal('a', item);
            Assert.True(linkedList.Head is null);
        }

        [Fact]
        public void SinglyLinkedList_RemoveFirst_Exception_Test()
        {
            var linkedList = new SinglyLinkedList<char>();
            Assert.Throws<Exception>(() => linkedList.RemoveFirst());
        }

        [Fact]
        public void SinglyLinkedList_RemoveLast_Test()
        {
            var linkedList = new SinglyLinkedList<char>();
            linkedList.AddFirst('a');
            linkedList.AddFirst('b');
            linkedList.AddFirst('c');
            Assert.Equal('a', linkedList.RemoveLast());
            Assert.Equal('b', linkedList.RemoveLast());
            Assert.Equal('c', linkedList.RemoveLast());
        }

        [Fact]
        public void SinglyLinkedList_RemoveLast_Exception_Test()
        {
            var linkedList = new SinglyLinkedList<char>();
            Assert.Throws<Exception>(() => linkedList.RemoveLast());
        }

        [Fact]
        public void SinglyLinkedList_Remove_Exception_Test()
        {
            var linkedList = new SinglyLinkedList<char>();
            var node = new SinglyLinkedListNode<char>('b');
            Assert.Throws<Exception>(() => linkedList.Remove(node));
        }

        [Fact]
        public void SinglyLinkedList_Get_Enumerator_Test()
        {
            var list = new SinglyLinkedList<int>();
            list.AddLast(10);
            list.AddLast(20);
            list.AddLast(30);
            Assert.Collection<int>(list,
                item => Assert.Equal(10, item),
                item => Assert.Equal(20, item),
                item => Assert.Equal(30, item));
        }

        [Fact]
        public void SinglyLinkedList_Constructor_For_Char_Array_Input_Test()
        {
            var list = new SinglyLinkedList<char>("meltem".ToArray());
            Assert.Collection<char>(list,
                item => Assert.Equal('m', item),
                item => Assert.Equal('e', item),
                item => Assert.Equal('t', item),
                item => Assert.Equal('l', item),
                item => Assert.Equal('e', item),
                item => Assert.Equal('m', item));
        }

        [Fact]
        public void SinglyLinkedList_Constructor_For_List_Input_Test()
        {
            var list = new SinglyLinkedList<int>(new List<int>() { 5, 10, 15, 20 });
            Assert.Collection<int>(list,
                item => Assert.Equal(20, item),
                item => Assert.Equal(15, item),
                item => Assert.Equal(10, item),
                item => Assert.Equal(5, item));
        }

        [Fact]
        public void SinglyLinkedList_Constructor_For_SortedSet_Input_Test()
        {
            var list = new SinglyLinkedList<int>(new SortedSet<int>() { 23, 16, 23, 55, 61, 23, 44 });
            Assert.Collection<int>(list,
                item => Assert.Equal(61, item),
                item => Assert.Equal(55, item),
                item => Assert.Equal(44, item),
                item => Assert.Equal(23, item),
                item => Assert.Equal(16, item));
        }
    }
}
