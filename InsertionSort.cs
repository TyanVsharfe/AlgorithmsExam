using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExam
{
    internal class InsertionSort
    {
        static void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }

        //сортировка вставками
        public static int[] GetInsertionSort(int[] array)
        {
            for (var i = 0; i < array.Length - 1; i++)
            {
                var j = i;
                while ((j >= 0) && (array[j] > array[j + 1]))
                {
                    Swap(ref array[j], ref array[j + 1]);
                    j--;
                }
            }

            return array;
        }
    }
}
