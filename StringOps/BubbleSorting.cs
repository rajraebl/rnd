using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringOps
{
    class BubbleSorting
    {
        public static void Sort(int[] arr)
        {
            int temp = 0;

            for (int write = 0; write < arr.Length; write++)
            {
                for (int sort = 0; sort < arr.Length - 1; sort++)
                {
                    if (arr[sort] > arr[sort + 1])
                    {
                        temp = arr[sort + 1];
                        arr[sort + 1] = arr[sort];
                        arr[sort] = temp;
                    }
                }
            }

            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");

        }
    }

    class QuickSorting //https://yadiragarnica.wordpress.com/2015/10/15/sorting-arrays/
    {
        public static void Sort(int[] arr, int init, int end)
        {
            Console.WriteLine(Environment.NewLine+ "-----------------QuickSorting--------------");
            if (init < end)
            {
                int pivot = Partition(arr, init, end);
                Sort(arr, init, pivot - 1);
                Sort(arr, pivot + 1, end);
            }

            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");

        }

        //O(n)
        private static int Partition(int[] array, int init, int end)
        {
            int last = array[end];
            int i = init - 1;
            for (int j = init; j < end; j++)
            {
                if (array[j] <= last)
                {
                    i++;
                    Exchange(array, i, j);
                }
            }
            Exchange(array, i + 1, end);
            return i + 1;
        }

        private static void Exchange(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        } 
    }
}
