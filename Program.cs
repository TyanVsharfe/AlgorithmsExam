
using static AlgorithmsExam.TreeSort;

namespace AlgorithmsExam
{
    class Program
    {
        public static void Main()
        {
            int[] arr = { 170, 45, 75, 90, 802, 24, 2, 66 };
            int[][] adjacencyMatrix = new int[][]
            {
                new int[] { 0, 7, 4, 0, 0, 0 },
                new int[] { 0, 0, 4, 2, 0, 0 },
                new int[] { 0, 0, 0, 8, 4, 0 },
                new int[] { 0, 0, 0, 0, 4, 5 },
                new int[] { 0, 0, 0, 0, 0, 12},
                new int[] { 0, 0, 0, 0, 0, 0 }
            };
            int[,] adjacencyMatrix1 = new int[,]
            {
                { 0, 7, 4, 0, 0, 0 },
                { 0, 0, 4, 2, 0, 0 },
                { 0, 0, 0, 8, 4, 0 },
                { 0, 0, 0, 0, 4, 5 },
                { 0, 0, 0, 0, 0, 12},
                { 0, 0, 0, 0, 0, 0 }
            };
            int[,] graph = new int[,] { { 0, 2, 0, 6, 0 },
                                      { 2, 0, 3, 8, 5 },
                                      { 0, 3, 0, 0, 7 },
                                      { 6, 8, 0, 0, 9 },
                                      { 0, 5, 7, 9, 0 } };
            string[] array = new string[] { "Carmen", "Adela", "Beatrix", "Abbey", "Abigale", "Barbara", "Camalia", "Belinda", "Beckie" };

            //RadixSort.radixSort(arr);
            //BubbleSort.GetBubbleSort(arr);
            //InsertionSort.GetInsertionSort(arr);
            //ShellSort.GetShellSort(arr);
            //SelectionSort.GetSelectionSort(arr);
            //DijkstraAlgorithm.Dijkstra(adjacencyMatrix,0,adjacencyMatrix.GetLength(0) - 1);
            //DepthTraversalGraph.HeightTraversal(adjacencyMatrix);
            //WidthTraversalGraph.WidthTraversal(adjacencyMatrix);
            //PrimAlgorithm.Prim(adjacencyMatrix1);
            QuickSort.SortArray(arr, 0, arr.Length - 1);
            Print(arr);
            //PrintS(ABCSort.Sort(array));

            Console.WriteLine("Random Array: {0}", string.Join(" ", arr));

            Console.WriteLine("Sorted Array: {0}", string.Join(" ", TreeSort(arr)));
        }

        public static void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }

        public static void PrintS(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
        }

        private static int[] TreeSort(int[] array)
        {
            TreeNode treeNode = new TreeNode(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                treeNode.Insert(new TreeNode(array[i]));
            }

            return treeNode.Transform();
        }
    }
}

