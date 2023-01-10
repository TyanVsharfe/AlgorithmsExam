using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExam
{
    internal class DepthTraversalGraph
    {
        public static void HeightTraversal(int[][] adjacencyMatrix)
        {
            Stack<int> stack = new Stack<int>();
            List<int> nodes = new List<int>();
            List<int> nodesQueue = new List<int>();
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                nodes.Add(0);
            }
            stack.Push(0);
            Console.WriteLine($"Добавили элемент \"1\".");
            while (stack.Count != 0)
            {
                int node = stack.Pop();
                Console.WriteLine($"Взяли элемент \"{node + 1}\".");
                if (nodes[node] == 2)
                {
                    Console.WriteLine($"Элемент \"{node + 1}\" ранее был посещён.");
                    Console.WriteLine($"{GetAllElementOfCollection(stack)}");
                    continue;
                }
                nodesQueue.Add(node + 1);
                Console.WriteLine($"Перешли в элемент \"{node + 1}\".");
                nodes[node] = 2;
                for (int i = nodes.Count - 1; i >= 0; i--)
                {
                    if (adjacencyMatrix[node][i] != 0 && nodes[i] != 2)
                    {
                        stack.Push(i);
                        Console.WriteLine($"Обнаружили элемент \"{i + 1}\".");
                        Console.WriteLine($"Добавили элемент \"{i + 1}\".");
                        nodes[i] = 1;
                    }
                }
                Console.WriteLine($"{GetAllElementOfCollection(stack)}");
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
