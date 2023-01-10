using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExam
{
    internal class PrimAlgorithm
    {
        static bool isValidEdge(int u, int v,
                        bool[] inMST)
        {
            if (u == v)
                return false;
            if (inMST[u] == false && inMST[v] == false)
                return false;
            else if (inMST[u] == true &&
                     inMST[v] == true)
                return false;
            return true;
        }

        public static void Prim(int[,] adjacencyMatrix)
        {
            int V = adjacencyMatrix.GetLength(0);
            bool[] inMST = new bool[V];

            // Include first vertex in MST
            inMST[0] = true;

            // Keep adding edges while number of
            // included edges does not become V-1.
            int edge_count = 0, mincost = 0;
            while (edge_count < V - 1)
            {

                // Find minimum weight valid edge.
                int min = int.MaxValue, a = -1, b = -1;
                for (int i = 0; i < V; i++)
                {
                    for (int j = 0; j < V; j++)
                    {
                        if (adjacencyMatrix[i, j] < min && adjacencyMatrix[i, j] != 0)
                        {
                            if (isValidEdge(i, j, inMST))
                            {
                                min = adjacencyMatrix[i, j];
                                a = i;
                                b = j;
                            }
                        }
                    }
                }

                if (a != -1 && b != -1)
                {
                    Console.Write("Edge {0}:({1}, {2}) cost: {3} \n",
                                            edge_count++, a, b, min);
                    mincost = mincost + min;
                    inMST[b] = inMST[a] = true;
                }
            }
            Console.Write("\n Minimum cost = {0} \n", mincost);
        }
    }
}
