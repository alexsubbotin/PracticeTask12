using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask12
{
    class Program
    {
        // Task: compare two sorting algorithms – Bubble sort and Heapsort – on number of swaps and number of compares.
        // Compare them using three types of arrays: 1. Sorted 2. Reverse sorted 3. Unsorted
        // Student: Alexey Subbtoin. Group: SE-17-1.
        static void Main(string[] args)
        {
        }

        // Bubble sort.
        public static void BubbleSort(ref int[] arr, ref int SwapCount, ref int CompareCount)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = 0; i < arr.Length - i - 1; j++)
                {
                    // Increasing the number of compares.
                    CompareCount++;

                    if(arr[j] > arr[j + 1])
                    {
                        int buf = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = buf;

                        // Increasing the number of swaps.
                        SwapCount++;
                    }
                }
            }
        }

        public static void HeapSort(ref int[] arr, ref int SwapCount, ref int CompareCount)
        {
            // Step 1: creating a pyramid.
            for(int i = arr.Length / 2 - 1; i >=0; i--)
            {
                int prev = i;
                i = AddToPyramid(arr, i);
                if (prev != i)
                    ++i;
            }

            // Step 2: sorting.
            for(int i = arr.Length - 1; i > 0; i--)
            {
                int buf = arr[i];
                arr[i] = arr[0];
                buf = arr[0];

                int k = 0;
                int prev = -1;

                while(k != prev)
                {
                    prev = k;
                    k = AddToPyramid(arr, k);
                }
            }
        }

        public static int AddToPyramid(int[] arr, int elemIndex)
        {
            int imax;

            if (2 * elemIndex + 2 < arr.Length)
            {
                if (arr[2 * elemIndex + 1] < arr[2 * elemIndex + 2])
                    imax = arr[2 * elemIndex + 2];
                else
                    imax = arr[2 * elemIndex + 1];
            }
            else
                imax = 2 * elemIndex + 1;

            if (imax >= arr.Length)
                return elemIndex;

            if(arr[elemIndex] < arr[imax])
            {
                int buf = arr[elemIndex];
                arr[elemIndex] = arr[imax];
                arr[imax] = buf;

                if (imax < arr.Length / 2)
                    elemIndex = imax;
            }

            return elemIndex;
        }
    }
}
