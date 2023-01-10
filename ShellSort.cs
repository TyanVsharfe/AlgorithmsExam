using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace AlgorithmsExam
{
    public class ShellSort
    {
        public static void GetShellSort(int[] Array)
        {
            int j;
            int step = Array.Length / 2;
            while (step > 0)
            {
                for (int i = 0; i < (Array.Length - step); i++)
                {
                    j = i;
                    while ((j >= 0) && (Array[j] > Array[j + step]))
                    {
                        Swap(ref Array[j], ref Array[j + step]);
                        j -= step;
                    }
                }
                step = step / 2;
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
