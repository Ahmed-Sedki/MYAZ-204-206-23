namespace SortingAlgorithms
{
    public class SelectionSort
    {
        public static void Sort<T>(T[] array) where T : IComparable
        {
            for (var i = 0; i < array.Length - 1; i++)
            {
                var minIndex = i;
                for (var j = i + 1; j < array.Length; j++)
                {
                    if (array[j].CompareTo(array[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }
                Sorting.Swap(array, i, minIndex);
            }
        }
    }
}
