using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExam
{
    internal class DijkstraAlgorithm
    {
        public static void Dijkstra(int[][] adjacencyMatrix, int startIndex, int endIndex)
        {
            int size = adjacencyMatrix.GetLength(0);

            //Начальный Node: startIndex
            //Конечный Node: endIndex

            int[] distance = new int[size]; // минимальное расстояние
            int[] visitedNodes = new int[size]; // посещенные вершины
            int temp, minindex, min;

            for (int i = 0; i < size; i++)
            {
                distance[i] = int.MaxValue - 1;
                visitedNodes[i] = 1;
            }

            distance[startIndex] = 0;

            do
            {
                minindex = int.MaxValue;
                min = int.MaxValue;
                for (int i = 0; i < size; i++)
                {
                    if ((visitedNodes[i] == 1) && (distance[i] < min))
                    {
                        Console.WriteLine($"Обнаружили непосещенную вершину: {i + 1}");
                        min = distance[i];
                        minindex = i;
                        Console.WriteLine($"Установили минимальную дистанцию \"{distance[i]}\" до Node \"{minindex + 1}\".");
                    }
                }

                if (minindex != int.MaxValue)
                {
                    for (int i = 0; i < size; i++)
                    {
                        if (adjacencyMatrix[minindex][i] > 0)
                        {
                            temp = min + adjacencyMatrix[minindex][i];
                            Console.WriteLine($"Добавляем найденный минимальный путь \"{adjacencyMatrix[minindex][i]}\" к текущему.");
                            if (temp < distance[i])
                            {
                                distance[i] = temp;
                                Console.WriteLine($"Устанавливаем новый минимальный путь \"{temp}\" до Node \"{i + 1}\", Т.к. предыдущий минимальный путь \"{temp}\" <= текущему \"{distance[i]}\".");
                            }
                            else
                            {
                                Console.WriteLine($"Оставляем предыдущий минимальный путь \"{distance[i]}\" до Node \"{i + 1}\", Т.к. предыдущий минимальный путь \"{distance[i]}\" < текущего \"{temp}\".");
                            }
                        }
                    }
                    visitedNodes[minindex] = 0;
                    Console.WriteLine($"Указываем, что Node \"{minindex + 1}\" был посещен.\n");
                }
            } while (minindex < int.MaxValue);

            Console.WriteLine($"Кратчайший путь равен: {distance[endIndex]}. \n");        
        }
    }
}
