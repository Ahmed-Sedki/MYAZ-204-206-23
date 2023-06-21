using SortingAlgorithms;
using Xunit;

namespace SortingAlgorithmsTests
{
    public class SortingTests
    {
        private int[] Array;
        private int[] _array;
        private char[] charArray;
        public SortingTests()
        {
            Array = new int[10] { 2, 3, 5, 8, 10, 1, 4, 5, 4, 6 };
            _array = new int[] { 10, 20, 50, 30, 40 };
            charArray = new char[] { 'a', 'd', 'z', 'c' };
        }

        private void AssertIntCollection(int[] arr, int[] expected)
        {
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], arr[i]);
            }
        }

        private void AssertCharCollection(char[] arr, char[] expected)
        {
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], arr[i]);
            }
        }

        [Fact]
        public void Bubble_Sort_Test()
        {
            BubbleSort.Sort(Array);
            AssertIntCollection(Array, new int[] { 1, 2, 3, 4, 4, 5, 5, 6, 8, 10 });
        }

        [Fact]
        public void Insertion_Sort_Test()
        {
            InsertionSort.Sort(Array);
            AssertIntCollection(Array, new int[] { 1, 2, 3, 4, 4, 5, 5, 6, 8, 10 });
        }

        [Fact]
        public void MergeSort_Test()
        {
            MergeSort.Sort(_array);
            AssertIntCollection(_array, new int[] { 10, 20, 30, 40, 50 });
        }

        [Fact]
        public void QuickSort_Test()
        {
            Quicksort.Sort(_array);
            AssertIntCollection(_array, new int[] { 10, 20, 30, 40, 50 });
        }

        [Fact]
        public void SelectionSort_Test()
        {
            SelectionSort.Sort(charArray);
            AssertCharCollection(charArray, new char[] { 'a', 'c', 'd', 'z' });
        }
    }
}
