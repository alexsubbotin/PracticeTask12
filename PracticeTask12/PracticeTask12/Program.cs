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
            DemonstrateSorted();
            DemonstrateReverseSorted();
            DemonstrateUnsorted();

            Console.ReadLine();
        }

        // Methods comparing with a sorted array.
        public static void DemonstrateSorted()
        {
            // Bubble sort characteristics.
            int bubbleNumOfSwaps = 0;
            int bubbleNumOfCompares = 0;

            // Heapsort characteristics.
            int heapNumOfSwaps = 0;
            int heapNumOfCompares = 0;

            // Sorted array.
            int[] sortedOrig = CreateSortedArray();
            Console.WriteLine("ORIGINAL SORTED ARRAY:");
            foreach (int a in sortedOrig)
                Console.Write(a + " ");
            Console.WriteLine("\n");

            // Sorting bubble.
            int[] sortedClone = CloneArray(sortedOrig);
            BubbleSort(ref sortedClone, ref bubbleNumOfSwaps, ref bubbleNumOfCompares);

            Console.WriteLine("SORTED ARRAY AFTER BUBBLE SORTING:");
            foreach (int a in sortedClone)
                Console.Write(a + " ");
            Console.WriteLine();
            Console.WriteLine("The number of swaps: {0}\nThe number of compares: {1}\n", bubbleNumOfSwaps, bubbleNumOfCompares);

            // Sorting heap.
            sortedClone = CloneArray(sortedOrig);
            HeapSort(ref sortedClone, ref heapNumOfSwaps, ref heapNumOfCompares);

            Console.WriteLine("SORTED ARRAY AFTER HEAP SORTING:");
            foreach (int a in sortedClone)
                Console.Write(a + " ");
            Console.WriteLine();
            Console.WriteLine("The number of swaps: {0}\nThe number of compares: {1}\n", heapNumOfSwaps, heapNumOfCompares);
        }

        // Methods comparing with a reverse sorted array.
        public static void DemonstrateReverseSorted()
        {
            // Bubble sort characteristics.
            int bubbleNumOfSwaps = 0;
            int bubbleNumOfCompares = 0;

            // Heapsort characteristics.
            int heapNumOfSwaps = 0;
            int heapNumOfCompares = 0;

            // Reverse sorted array.
            int[] reverseOrig = CreateReverseSortedArray();
            Console.WriteLine("ORIGINAL REVERSE SORTED ARRAY:");
            foreach (int a in reverseOrig)
                Console.Write(a + " ");
            Console.WriteLine("\n");

            // Sorting bubble.
            int[] reverseClone = CloneArray(reverseOrig);
            BubbleSort(ref reverseClone, ref bubbleNumOfSwaps, ref bubbleNumOfCompares);

            Console.WriteLine("REVERSE SORTED ARRAY AFTER BUBBLE SORTING:");
            foreach (int a in reverseClone)
                Console.Write(a + " ");
            Console.WriteLine();
            Console.WriteLine("The number of swaps: {0}\nThe number of compares: {1}\n", bubbleNumOfSwaps, bubbleNumOfCompares);

            // Sorting heap.
            reverseClone = CloneArray(reverseOrig);
            HeapSort(ref reverseClone, ref heapNumOfSwaps, ref heapNumOfCompares);

            Console.WriteLine("REVERSE SORTED ARRAY AFTER HEAP SORTING:");
            foreach (int a in reverseClone)
                Console.Write(a + " ");
            Console.WriteLine();
            Console.WriteLine("The number of swaps: {0}\nThe number of compares: {1}\n", heapNumOfSwaps, heapNumOfCompares);
        }

        // Methods comparing with an unsorted array.
        public static void DemonstrateUnsorted()
        {
            // Bubble sort characteristics.
            int bubbleNumOfSwaps = 0;
            int bubbleNumOfCompares = 0;

            // Heapsort characteristics.
            int heapNumOfSwaps = 0;
            int heapNumOfCompares = 0;

            // Unsorted array.
            int[] unsortedOrig = CreateUnsortedArray();
            Console.WriteLine("ORIGINAL UNSORTED SORTED ARRAY:");
            foreach (int a in unsortedOrig)
                Console.Write(a + " ");
            Console.WriteLine("\n");

            // Sorting bubble.
            int[] unsortedClone = CloneArray(unsortedOrig);
            BubbleSort(ref unsortedClone, ref bubbleNumOfSwaps, ref bubbleNumOfCompares);

            Console.WriteLine("UNSORTED ARRAY AFTER BUBBLE SORTING:");
            foreach (int a in unsortedClone)
                Console.Write(a + " ");
            Console.WriteLine();
            Console.WriteLine("The number of swaps: {0}\nThe number of compares: {1}\n", bubbleNumOfSwaps, bubbleNumOfCompares);

            // Sorting heap.
            unsortedClone = CloneArray(unsortedOrig);
            HeapSort(ref unsortedClone, ref heapNumOfSwaps, ref heapNumOfCompares);

            Console.WriteLine("UNSORTED ARRAY AFTER HEAP SORTING:");
            foreach (int a in unsortedClone)
                Console.Write(a + " ");
            Console.WriteLine();
            Console.WriteLine("The number of swaps: {0}\nThe number of compares: {1}\n", heapNumOfSwaps, heapNumOfCompares);
        }

        // Bubble sort.
        public static void BubbleSort(ref int[] arr, ref int SwapCount, ref int CompareCount)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = 0; j < arr.Length - i - 1; j++)
                {
                    // Increasing the number of compares.
                    CompareCount++;

                    if(arr[j] > arr[j + 1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);

                        // Increasing the number of swaps.
                        SwapCount++;
                    }
                }
            }
        }

        // Heapsort.
        public static void HeapSort(ref int[] arr, ref int SwapCount, ref int CompareCount)
        {
            // Step 1: creating a pyramid.
            for(int i = arr.Length / 2 - 1; i >= 0; i--)
            {
                int prev = i;
                i = AddToPyramid(ref arr, i, arr.Length, ref SwapCount, ref CompareCount);
                if (prev != i)
                    ++i;
            }

            // Step 2: sorting.
            for(int i = arr.Length - 1; i > 0; i--)
            {
                SwapCount++;
                Swap(ref arr[i], ref arr[0]);

                int k = 0;
                int prev = -1;

                while(k != prev)
                {
                    prev = k;
                    k = AddToPyramid(ref arr, k, i, ref SwapCount, ref CompareCount);
                }
            }
        }

        // Method to add an element to the pyramid.
        public static int AddToPyramid(ref int[] arr, int elemIndex, int size, ref int SwapCount, ref int CompareCount)
        {
            int imax;

            if (2 * elemIndex + 2 < size)
            {
                if (arr[2 * elemIndex + 1] < arr[2 * elemIndex + 2])
                    imax = 2 * elemIndex + 2;
                else
                    imax = 2 * elemIndex + 1;

                CompareCount++;
            }
            else
                imax = 2 * elemIndex + 1;

            if (imax >= size)
                return elemIndex;

            CompareCount++;
            if(arr[elemIndex] < arr[imax])
            {
                Swap(ref arr[elemIndex], ref arr[imax]);
                SwapCount++;

                if (imax < size / 2)
                    elemIndex = imax;
            }

            return elemIndex;
        }

        // Swap method.
        public static void Swap(ref int a, ref int b)
        {
            int buf = a;
            a = b;
            b = buf;
        }

        public static Random rnd = new Random();

        // Method to create a sorted array.
        public static int[] CreateSortedArray()
        {
            int[] arr = new int[rnd.Next(3, 21)];

            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = i;
            }

            return arr;
        }

        // Method to create a reverse sorted array.
        public static int[] CreateReverseSortedArray()
        {
            int[] arr = new int[rnd.Next(3, 21)];

            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = arr.Length - i - 1;
            }

            return arr;
        }

        // Method to create an unsorted array.
        public static int[] CreateUnsortedArray()
        {
            int[] arr = new int[rnd.Next(3, 21)];

            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(-50, 51);
            }

            return arr;
        }

        // Method to clone an array.
        public static int[] CloneArray(int[] arr)
        {
            int[] clone = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
                clone[i] = arr[i];

            return clone;
        }
    }
}
