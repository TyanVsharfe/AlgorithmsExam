using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExam
{
    internal class RadixSort
    {
        // A function to do counting sort of arr[] according to
        // the digit represented by exp.
        // Функция для подсчета типа arr[] в соответствии с
        // разрядом, представленной exp.
        public static void countSort(int[] arr, int exp)
        {
            int[] output = new int[arr.Length]; // output array
            int i;
            int[] count = new int[10];

            // Сохранить количество вхождений в count[]
            for (i = 0; i < arr.Length; i++)
                count[(arr[i] / exp) % 10]++;

            // Change count[i] so that count[i] now contains
            //actual position of this digit in output[]

            //Измените count[i] так, чтобы count[i] теперь содержал 
            //фактическое положение этой цифры в выводе[]
            for (i = 1; i < 10; i++)
                count[i] += count[i - 1];

            // Построить выходной массив
            for (i = arr.Length - 1; i >= 0; i--)
            {
                output[count[(arr[i] / exp) % 10] - 1] = arr[i];
                count[(arr[i] / exp) % 10]--;
            }

            // Copy the output array to arr[], so that arr[] now
            // contains sorted numbers according to current
            // digit
            for (i = 0; i < arr.Length; i++)
                arr[i] = output[i];
        }

        // The main function to that sorts arr[] of size n using Radix Sort
        //Основная функция для сортировки arr[] размера n с использованием Radix Sort
        public static void radixSort(int[] arr)
        {
            // Find the maximum number to know number of digits
            int m = arr.Max();

            // Do counting sort for every digit. Note that
            // instead of passing digit number, exp is passed.
            // exp is 10^i where i is current digit number
            for (int exp = 1; m / exp > 0; exp *= 10)
                countSort(arr, exp);
        }

        public static void LSDSort(List<string> words)
        {
            string alphabet = "0123456789";
            int maxLength = words.Max(word => word.Length);
            var workingList = words;
            var tempResult = new List<string>();

            var alphaDict = new Dictionary<char, int>();
            for (int i = 0; i < alphabet.Length; i++)
                alphaDict.Add(alphabet[i], i + 1);

            // loop for each char index (starting at last - least significant - char) цикл для каждого индекса символа (начало с последнего - наименее значимого символа)						
            for (int charLoc = maxLength - 1; charLoc >= 0; charLoc--)
            {

                var queues = new Queue<string>[alphabet.Length + 1];
                for (int i = 0; i < alphabet.Length + 1; i++)
                    queues[i] = new Queue<string>();
                //помещаем разные строки в соответствующую очередь
                foreach (var str in workingList)
                {
                    int queueIndex = 0;
                    if (charLoc < str.Length)
                    {
                        char cr = str[charLoc];
                        queueIndex = alphaDict[cr];
                    }
                    queues[queueIndex].Enqueue(str);
                }
                //объединяем все очереди
                for (int queueIndex = 0; queueIndex <= alphabet.Length; queueIndex++)
                {
                    var queue = queues[queueIndex];
                    if (queue != null)
                    {

                        tempResult.AddRange(queue.ToArray());

                    }
                }
                workingList = tempResult;
                tempResult = new List<string>();
            }
            words = workingList;
        }
    }
}
