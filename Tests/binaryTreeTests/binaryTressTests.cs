using System.Linq;
using Trees.BinaryTree;
using Xunit;

namespace BinaryTreeTests
{
    public class BinaryTressTests
    {
        private readonly BinaryTree<int> _bt;

        public BinaryTressTests()
        {
            _bt = new BinaryTree<int>();
        }

        [Fact]
        public void RootNodeCreation()
        {
            _bt.Insert(1);
            Assert.Equal(1, _bt.Root.Value);
        }

        [Fact]
        public void LeftNodeCheck()
        {
            _bt.Insert(1);
            _bt.Insert(2);
            Assert.Equal(1, _bt.Root.Value);
            Assert.Equal(2, _bt.Root.Left.Value);
        }

        [Fact]
        public void RightNodeCheck()
        {
            _bt.Insert(1);
            _bt.Insert(2);
            _bt.Insert(3);
            Assert.Equal(1, _bt.Root.Value);
            Assert.Equal(2, _bt.Root.Left.Value);
            Assert.Equal(3, _bt.Root.Right.Value);
        }

        [Fact]
        public void MultipleInsertionCheck()
        {
            Enumerable.Range(1, 7).ToList().ForEach(_bt.Insert);
            Assert.Equal(1, _bt.Root.Value);
            Assert.Equal(2, _bt.Root.Left.Value);
            Assert.Equal(3, _bt.Root.Right.Value);
            Assert.Equal(4, _bt.Root.Left.Left.Value);
            Assert.Equal(5, _bt.Root.Left.Right.Value);
            Assert.Equal(6, _bt.Root.Right.Left.Value);
            Assert.Equal(7, _bt.Root.Right.Right.Value);
        }

        [Fact]
        public void BinaryTreeCount()
        {
            Enumerable.Range(1, 10).Where(x => x % 2 == 0).ToList().ForEach(_bt.Insert);
            Assert.Equal(5, _bt.Count);
        }

        [Fact]
        public void LevelOrderTraversal()
        {
            Enumerable.Range(1, 7).ToList().ForEach(_bt.Insert);
            var list = BinaryTree<int>.LevelOrderTraverse(_bt.Root);
            Assert.Equal(7, list.Count);
        }

        [Fact]
        public void EnumeratorCheck()
        {
            Enumerable.Range(1, 7).ToList().ForEach(_bt.Insert);
            var list = BinaryTree<int>.LevelOrderTraverse(_bt.Root);
            Assert.Equal(7, list.Count);
        }

        [Fact]
        public void LeafNodeCheck()
        {
            Enumerable.Range(1, 7).ToList().ForEach(_bt.Insert);
            Assert.True(_bt.Root.Left.Left.IsLeaf);
        }

        [Fact]
        public void NonLeafNodeCheck()
        {
            Enumerable.Range(1, 7).ToList().ForEach(_bt.Insert);
            Assert.False(_bt.Root.Right.IsLeaf);
        }
    }
}
