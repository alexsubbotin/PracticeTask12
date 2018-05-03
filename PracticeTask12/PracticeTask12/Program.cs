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
        public static void BubbleSort(int[] arr, ref int SwapCount, ref int CompareCount)
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
    }
}
