namespace SortingAlgorithms
{
    public class MergeSort
    {
        public static void Sort<T>(T[] arr) where T : IComparable
        {
            Sort(arr, 0, arr.Length - 1);
        }

        private static void Sort<T>(T[] Array, int left, int right) where T : IComparable
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                Sort(Array, left, middle);
                Sort(Array, middle + 1, right);

                Merge(Array, left, middle, right);
            }
        }

        private static void Merge<T>(T[] Array, int left, int middle, int right) where T : IComparable
        {
            T[] leftArray = new T[middle - left + 1];
            T[] rightArray = new T[right - middle];

            System.Array.Copy(Array, left, leftArray, 0, middle - left + 1);
            System.Array.Copy(Array, middle + 1, rightArray, 0, right - middle);

            int i = 0, j = 0, k = left;

            while (i < leftArray.Length && j < rightArray.Length)
            {
                Array[k++] = leftArray[i].CompareTo(rightArray[j]) <= 0 ? leftArray[i++] : rightArray[j++];
            }

            while (i < leftArray.Length)
            {
                Array[k++] = leftArray[i++];
            }

            while (j < rightArray.Length)
            {
                Array[k++] = rightArray[j++];
            }
        }
    }
}
