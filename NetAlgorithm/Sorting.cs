using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreConsole
{
    class Sorting
    {
        public static void BubbleSort(int[] ar)
        {
            if (ar == null || ar.Length < 2)
                return;

            var n = ar.Length;
            bool swapped;
            int t;
            do
            {
                swapped = false;
                for (int i = 1; i < n; i++)
                {
                    if (ar[i-1] > ar[i])
                    {
                        t = ar[i - 1];
                        ar[i - 1] = ar[i];
                        ar[i] = t;
                        swapped = true;
                    }
                }
                n = n - 1;
            } while (swapped);
        }

        public static void InsertionSort(int[] ar)
        {
            if (ar == null || ar.Length < 2)
                return;

            for (int i=1; i<ar.Length; i++)
            {
                int key = ar[i];
                int j = i - 1;
                while (j >= 0 && key < ar[j])
                {
                    ar[j + 1] = ar[j];
                    j--;
                }
                ar[j + 1] = key;
            }
        }

        private static void mergeSort_Merge(int[] ar, int left, int mid, int right)
        {
            int leftSize = mid - left + 1;
            int rightSize = right - mid;

            int[] leftHalve = new int[leftSize];
            int[] rightHalve = new int[rightSize];

            int i, j;

            for (i = 0; i < leftSize; i++)
                leftHalve[i] = ar[left + i];
            for (j = 0; j < rightSize; j++)
                rightHalve[j] = ar[mid + 1 + j];

            i = 0;
            j = 0;
            int k = left;
            while (i<leftSize || j<rightSize)
            {
                if (i == leftSize)
                {
                    ar[k++] = rightHalve[j++];
                }
                else
                if (j == rightSize)
                {
                    ar[k++] = leftHalve[i++];
                }
                else
                if (leftHalve[i] < rightHalve[j])
                {
                    ar[k++] = leftHalve[i++];
                }
                else
                {
                    ar[k++] = rightHalve[j++];
                }
            }

            //while (i < leftSize)
            //    ar[k++] = leftHalve[i++];

            //while (j < rightSize)
            //    ar[k++] = rightHalve[j++];

        }
        private static void mergeSort_Sort(int[] ar, int left, int right)
        {
            if (left < right)
            {
                int m = left + (right - left) / 2;
                mergeSort_Sort(ar, left, m);
                mergeSort_Sort(ar, m + 1, right);

                mergeSort_Merge(ar, left, m, right);
            }
        }

        private static void swap(int[] ar, int i, int j)
        {
            int tmp = ar[i];
            ar[i] = ar[j];
            ar[j] = tmp;
        }

        public static void MergeSort(int[] ar)
        {
            mergeSort_Sort(ar, 0, ar.Length - 1);
        }

        private static int quickSort_Partition(int[] ar, int lo, int hi)
        {
            //// Lomuto's partition scheme
            //int pivot = ar[hi];

            //int i = lo - 1;
            //for (int j = lo; j < hi; j++)
            //{
            //    if (ar[j] < pivot)
            //    {
            //        i++;
            //        swap(ar, i, j);
            //    }
            //}

            //swap(ar, i + 1, hi);

            //return i + 1;

            // Hoare's partition scheme
            int pivot = ar[lo];
            int i = lo - 1;
            int j = hi + 1;
            while (true)
            {
                do
                {
                    i = i + 1;
                }
                while (ar[i] < pivot);

                do
                {
                    j = j - 1;
                }
                while (ar[j] > pivot);

                if (i >= j)
                    return j;

                swap(ar, i, j);
            }
        }
        private static void quickSort_Sort(int[] ar, int lo, int hi)
        {
            if (lo < hi)
            {
                int pi = quickSort_Partition(ar, lo, hi);

                //// Lomuto's partition
                //quickSort_Sort(ar, lo, pi - 1);
                //quickSort_Sort(ar, pi + 1, hi);

                // Hoare's partition
                quickSort_Sort(ar, lo, pi);
                quickSort_Sort(ar, pi + 1, hi);
            }
        }

        public static void Test()
        {
            int[] ar = new[] {9,8,7,6,5,4,3,2,1,0 };
            //{ 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //{ 9,8,12,33,1,2,9,0,88 };
            //{ 9, 9, 9, 9, 9, 9 }; 

            //BubbleSort(ar);
            //InsertionSort(ar);
            //MergeSort(ar);
            quickSort_Sort(ar, 0, ar.Length - 1);

            for (int i = 0; i < ar.Length; i++)
                Console.Write("{0}\t", ar[i]);
        }
    }
}
