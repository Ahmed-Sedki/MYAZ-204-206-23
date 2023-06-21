using Trees.BinaryTree;
using Trees.BinaryTree.BinarySearchTree;
using Xunit;
using System.Collections.Generic;

namespace BinaryTreeTests
{
    public class BinarySearchTreesTests
    {
        private readonly BST<int> _bst;

        public BinarySearchTreesTests()
        {
            _bst = new BST<int>();
        }

        [Fact]
        public void AddRootTest()
        {
            _bst.Add(23);
            Assert.Equal(23, _bst.Root.Value);
        }

        [Fact]
        public void AddingWithIEnumerableConstructor()
        {
            var bst = new BST<int>(new[] { 23, 16, 44, 3, 22, 99, 37 });
            bst.Add(4);
            var list = BinaryTree<int>.InOrderIterationTraverse(bst.Root);

            Assert.Equal(new List<int> { 3, 4, 16, 22, 23, 37, 44, 99 }, list);
        }

        [Fact]
        public void FindMinTest()
        {
            var bst = new BST<int>(new[] { 23, 16, 44, 3, 22, 99, 37 });
            Assert.Equal(3, bst.FindMin(bst.Root));
        }

        [Fact]
        public void FindMaxTest()
        {
            var bst = new BST<int>(new[] { 23, 16, 44, 3, 22, 99, 37 });
            Assert.Equal(99, bst.FindMax());
        }

        [Fact]
        public void FindTest()
        {
            var bst = new BST<int>(new[] { 23, 16, 44, 3, 22, 99, 37 });
            Assert.Equal(bst.Root.Right.Left, bst.Find(37));
        }

        [Fact]
        public void RemoveLeafTest()
        {
            var bst = new BST<int>(new[] { 60, 40, 70, 20, 45, 65, 85 });
            bst.Remove(bst.Root, 20);
            var list = BinaryTree<int>.InOrderIterationTraverse(bst.Root);
            Assert.Equal(new List<int> { 40, 45, 60, 65, 70, 85 }, list);
        }

        [Fact]
        public void RemoveNodeWithOneChildTest()
        {
            var bst = new BST<int>(new[] { 60, 40, 70, 20, 45, 65, 85 });
            bst.Remove(bst.Root, 20);
            bst.Remove(bst.Root, 40);
            var list = BinaryTree<int>.InOrderIterationTraverse(bst.Root);
            Assert.Equal(new List<int> { 45, 60, 65, 70, 85 }, list);
        }

        [Fact]
        public void RemoveNodeWithTwoChildTest()
        {
            var bst = new BST<int>(new[] { 60, 40, 70, 20, 45, 65, 85 });
            bst.Remove(bst.Root, 20);
            bst.Remove(bst.Root, 40);
            bst.Remove(bst.Root, 60);
            var list = BinaryTree<int>.InOrderIterationTraverse(bst.Root);
            Assert.Equal(new List<int> { 45, 65, 70, 85 }, list);
            Assert.Equal(65, bst.Root.Value);
        }
    }
}
