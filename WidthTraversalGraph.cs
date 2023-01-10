using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExam
{
    internal class WidthTraversalGraph
    {
        public static void WidthTraversal(int[][] adjacencyMatrix)
        {
            Queue<int> queue = new Queue<int>();
            List<int> nodes = new List<int>();
            List<int> nodesQueue = new List<int>();
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                nodes.Add(0);
            }
            queue.Enqueue(0);
            Console.WriteLine("Добавили элемент \"1\".");
            while (queue.Count != 0)
            {
                int node = queue.Dequeue();
                Console.WriteLine($"Взяли элемент \"{node + 1}\".");
                Console.WriteLine($"Перешли в элемент \"{node + 1}\".");
                nodes[node] = 2;
                nodesQueue.Add(node + 1);
                for (int i = 0; i < nodes.Count; i++)
                {
                    if (nodes[i] == 0 && adjacencyMatrix[node][i] != 0)
                    {
                        queue.Enqueue(i);
                        Console.WriteLine($"Обнаружили элемент \"{i + 1}\".");
                        Console.WriteLine($"Добавили элемент \"{i + 1}\".");
                        nodes[i] = 1;
                    }
                }
                Console.WriteLine($"{GetAllElementOfCollection(queue)}");
                Console.WriteLine($"Состояние обхода: {GetAllElementOfTrevalers(nodesQueue)}\n");
            }
        }

        private static string GetAllElementOfTrevalers(List<int> nodes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var elem in nodes)
            {
                sb.Append($"\"{(int)elem}\" -> ");
            }

            return sb.ToString().Substring(0, sb.Length - 3);
        }

        private static string GetAllElementOfCollection(IEnumerable<int> collection)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var elem in collection)
            {
                sb.Append($"\"{(int)elem + 1}\";");
            }
            return sb.Length > 0 ?
                $"Состояние коллекции: {sb.ToString().Substring(0, sb.Length - 1)}." :
                "Коллекция пуста.";
        }
    }
}
