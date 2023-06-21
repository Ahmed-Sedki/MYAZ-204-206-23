using DataStructures.Trees.BinaryTree;
using System.Linq;
using Xunit;

namespace TreeTests
{
    public class BinaryTreeTests
    {
        private BinaryTree<int> bt;
        private int[] values = new int[] { 1, 2, 3, 4, 5, 6, 7 };

        public BinaryTreeTests()
        {
            bt = new BinaryTree<int>();
        }

        private void SetUpTree()
        {
            values.ToList().ForEach(x => bt.Insert(x));
        }

        [Fact]
        public void Insert_Create_Root()
        {
            bt.Insert(1);
            Assert.Equal(1, bt.Root.Value);
        }

        [Fact]
        public void Insert_Check_Left_Node()
        {
            bt.Insert(1);
            bt.Insert(2);
            Assert.Equal(1, bt.Root.Value);
            Assert.Equal(2, bt.Root.Left.Value);
        }

        [Fact]
        public void Insert_Check_Right_Node()
        {
            bt.Insert(1);
            bt.Insert(2);
            bt.Insert(3);
            Assert.Equal(1, bt.Root.Value);
            Assert.Equal(2, bt.Root.Left.Value);
            Assert.Equal(3, bt.Root.Right.Value);
        }

        [Fact]
        public void Multiple_Insertion_Check()
        {
            SetUpTree();
            Assert.Equal(1, bt.Root.Value);
            Assert.Equal(2, bt.Root.Left.Value);
            Assert.Equal(3, bt.Root.Right.Value);
            Assert.Equal(4, bt.Root.Left.Left.Value);
            Assert.Equal(5, bt.Root.Left.Right.Value);
            Assert.Equal(6, bt.Root.Right.Left.Value);
            Assert.Equal(7, bt.Root.Right.Right.Value);
        }

        [Fact]
        public void Count_Check()
        {
            new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }.Where(x => x % 2 == 0).ToList().ForEach(x => bt.Insert(x));
            Assert.Equal(5, bt.Count);
        }

        [Fact]
        public void Level_Order_Traverse_Test()
        {
            SetUpTree();
            var list = BinaryTree<int>.LevelOrderTraverse(bt.Root);
            for (int i = 0; i < values.Length; i++)
            {
                Assert.Equal(values[i], list[i].Value);
            }
            Assert.Equal(7, bt.Count);
        }

        [Fact]
        public void GetEnumerator_Test()
        {
            SetUpTree();
            var list = BinaryTree<int>.LevelOrderTraverse(bt.Root);
            for (int i = 0; i < values.Length; i++)
            {
                Assert.Equal(values[i], list[i].Value);
            }
            Assert.Equal(7, bt.Count);
        }

        [Fact]
        public void IsLeaf_Test()
        {
            SetUpTree();
            Assert.True(bt.Root.Left.Left.IsLeaf);
        }

        [Fact]
        public void IsNotLeaf_Test()
        {
            SetUpTree();
            Assert.False(bt.Root.Right.IsLeaf);
        }
    }
}
