using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExam
{
    internal class ABCSort
    {
        static int[] wordTracker { get; set; }
        static int[,] letterTracker { get; set; }
        static List<string> result { get; set; }

        public static string[] Sort(string[] words)
        {
            wordTracker = new int[words.Length];
            letterTracker = new int[15, 26];
            result = new List<string>();

            SetLevel(words, 0);
            Recursive(words, 0);

            return result.ToArray();
        }

        private static void Recursive(string[] words, int depth)
        {
            for (int i = 0; i < letterTracker.GetLength(1); i++)
            {
                if (letterTracker[depth, i] == 0) continue;

                var wordInd = letterTracker[depth, i] - 1;
                if (letterTracker[depth, i] != 0 && wordTracker[wordInd] == 0)
                {
                    result.Add(words[wordInd]);
                    letterTracker[depth, i] = 0;
                    continue;
                }

                letterTracker[depth, i] = 0;

                while (wordInd >= 0)
                {
                    if (words[wordInd].Length <= depth + 1)
                    {
                        result.Add(words[wordInd]);
                        wordInd = wordTracker[wordInd] - 1;
                        continue;
                    }

                    int ind = char.ToUpper(words[wordInd][depth + 1]) - 65;
                    int temp = wordTracker[wordInd] - 1;
                    wordTracker[wordInd] = letterTracker[depth + 1, ind];
                    letterTracker[depth + 1, ind] = wordInd + 1;
                    wordInd = temp;
                }

                Recursive(words, depth + 1);
            }
        }

        private static void SetLevel(string[] words, int depth)
        {
            for (int i = 1; i < words.Length + 1; i++)
            {
                int ind = char.ToUpper(words[i - 1][depth]) - 65;
                wordTracker[i - 1] = letterTracker[depth, ind];
                letterTracker[depth, ind] = i;
            }
        }
    }
}
