namespace Laufzeitanalyze
{
    public class SortingMethods
    {
        public static IList<int> BubbleSort(IList<int> list)
        {
            for (int i = list.Count - 1; i != 0; --i)
            {
                bool swapped = false;

                for (int j = 0; j != i; ++j)
                {
                    if (list[j] > list[j + 1])
                    {
                        (list[j], list[j + 1]) = (list[j + 1], list[j]);
                        swapped = true;
                    }
                }

                if (!swapped)
                    break;
            }

            return list;
        }

        public static IList<int> InserionSort(IList<int> list)
        {
            for (int i = 1; i != list.Count; ++i)
            {
                int elementToSort = list[i];

                int j = i;
                while (j > 0 && list[j - 1] > elementToSort)
                    list[j] = list[--j];

                list[j] = elementToSort;
            }

            return list;
        }

        public static IList<int> SelectionSort(IList<int> list)
        {
            for (int i = 0; i != list.Count; ++i)
            {
                int min = list[i];
                int minPos = i;

                for (int j = i + 1; j != list.Count; ++j)
                {
                    if (list[j] < min)
                    {
                        min = list[j];
                        minPos = j;
                    }
                }

                if (minPos != i)
                {
                    (list[i], list[minPos]) = (list[minPos], list[i]);
                }
            }

            return list;
        }
    }
}