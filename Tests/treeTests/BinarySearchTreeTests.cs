using DataStructures.Trees.BinaryTree;
using System.Collections.Generic;
using Trees.BinaryTree.BinarySearchTree;
using Xunit;

namespace TreeTests
{
    public class BinarySearchTreesTests
    {
        private BST<int> bst;
        private List<int> testData;

        public BinarySearchTreesTests()
        {
            bst = new BST<int>();
            testData = new List<int> { 23, 16, 44, 3, 22, 99, 37 };
        }

        private void SetUpTree()
        {
            bst = new BST<int>(testData);
        }

        [Fact]
        public void Add_Root_Test()
        {
            bst.Add(23);
            Assert.Equal(23, bst.Root.Value);
        }

        [Fact]
        public void Adding_with_IEnumerable_Constructor()
        {
            SetUpTree();
            bst.Add(4);
            var list = BinaryTree<int>.InOrderIterationTraverse(bst.Root);
            Assert.Collection(list, item => Assert.Equal(3, item),
                                    item => Assert.Equal(4, item),
                                    item => Assert.Equal(16, item),
                                    item => Assert.Equal(22, item),
                                    item => Assert.Equal(23, item),
                                    item => Assert.Equal(37, item),
                                    item => Assert.Equal(44, item),
                                    item => Assert.Equal(99, item));
        }

        [Fact]
        public void Findmin_Test()
        {
            SetUpTree();
            var min = bst.FindMin(bst.Root);
            Assert.Equal(3, min);
        }

        [Fact]
        public void Findmax_Test()
        {
            SetUpTree();
            var max = bst.FindMax();
            Assert.Equal(99, max);
        }

        [Fact]
        public void Find()
        {
            SetUpTree();
            var node = bst.Find(37);
            Assert.Equal(node, bst.Root.Right.Left);
        }

        [Fact]
        public void Remove_A_Leaf()
        {
            testData = new List<int> { 60, 40, 70, 20, 45, 65, 85 };
            SetUpTree();
            bst.Remove(bst.Root, 20);
            AssertInOrderIterationTraverse(testData.Except(new List<int> { 20 }).ToList());
        }

        [Fact]
        public void Remove_A_Node_With_One_Child()
        {
            testData = new List<int> { 60, 40, 70, 20, 45, 65, 85 };
            SetUpTree();
            bst.Remove(bst.Root, 20);
            bst.Remove(bst.Root, 40);
            AssertInOrderIterationTraverse(testData.Except(new List<int> { 20, 40 }).ToList());
        }

        [Fact]
        public void Remove_A_Node_With_Two_Child()
        {
            testData = new List<int> { 60, 40, 70, 20, 45, 65, 85 };
            SetUpTree();
            bst.Remove(bst.Root, 20);
            bst.Remove(bst.Root, 40);
            bst.Remove(bst.Root, 60);
            AssertInOrderIterationTraverse(testData.Except(new List<int> { 20, 40, 60 }).ToList());
            Assert.Equal(65, bst.Root.Value);
        }

        private void AssertInOrderIterationTraverse(List<int> expectedValues)
        {
            var list = BinaryTree<int>.InOrderIterationTraverse(bst.Root);
            for (int i = 0; i < expectedValues.Count; i++)
            {
                Assert.Equal(expectedValues[i], list[i]);
            }
        }
    }
}
