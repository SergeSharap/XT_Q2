using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace T4_3
{
    public static class Sorter
    {
        public static event Action<string> OnSorted;  

        public static T[] Sort<T>(T[] array, Func<T, T, int> comparer)
        {
            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer), "comparer cannot be null");

            for (int i = 1; i < array.Length; i++)
            {
                T current = array[i];
                int j = i;
                while (j > 0 && comparer.Invoke(current, array[j - 1]) == -1)//while (j > 0 && cur < array[j - 1])
                {
                    array[j] = array[j - 1];
                    j--;
                }

                array[j] = current;
            }

            return array;
        }

        public static T[] SortInIndividualThread<T>(T[] array, Func<T, T, int> comparer)
        {
            T[] sortedArray = null;
            Thread th = new Thread(
                () =>
                {
                    sortedArray = Sort(array, comparer);
                    OnSorted?.Invoke("Sort is done.");

                });

            th.Start();
            th.Join();
            return sortedArray;
        }
    }
}
