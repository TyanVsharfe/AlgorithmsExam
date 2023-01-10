using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExam
{
    internal class SelectionSort
    {
        public static void GetSelectionSort(int[] array)
        {
            int min;
            for(int i = 0; i < array.Length - 2; i++)
            {
                min = i;
                for(int j = i + 1; j < array.Length ; j++)
                {
                    if (array[j] < array[min])
                        min = j;
                }
                Swap(ref array[i], ref array[min]);   
            }
        }

        public static void Swap(ref int x, ref int y)
        {
            int t = x;
            x = y;
            y = t;
        }
    }
}
