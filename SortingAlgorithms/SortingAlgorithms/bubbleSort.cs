namespace SortingAlgorithms
{
    public class BubbleSort
    {
        public static void Sort<T>(T[] array) where T : IComparable<T>
        {
            int n = array.Length;
            bool swapped;

            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        Sorting.Swap(array, j, j + 1);
                        swapped = true;
                    }
                }

                // If no two elements were swapped by inner loop, then the array is sorted
                if (!swapped)
                    break;
            }
        }
    }
}
