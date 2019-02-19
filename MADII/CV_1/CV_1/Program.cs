using System;
using System.Collections.Generic;
using System.Linq;

namespace CV_1
{
    class Program
    {
        // e-radius
        // KNN method
        // combination
        // porovnat pomocí gephi
        static void Main(string[] args)
        {
            // sigma
            const double variance = 1;
            const double epsilon = 0.8d;
            const int k = 3;

            var dl = new DataLoader();
            List<Iris> irisList = dl.LoadData();

            var similarityMatrix = new double[irisList.Count, irisList.Count];
            var graph1 = new Graph(irisList);
            var graph2 = new Graph(irisList);
            var graph3 = new Graph(irisList);

            for (int i = 0; i < irisList.Count; i++)
            {
                for (int j = 0; j < irisList.Count; j++)
                {
                    similarityMatrix[i, j] = Utils.GaussianKernel(irisList[i].ToArray(), irisList[j].ToArray(), variance);

                    if (similarityMatrix[i, j] > epsilon && i != j)
                    {
                        graph1.NodeList[i].Neighbors.Add(graph1.NodeList[j]);
                    }
                }
            }

            for (int i = 0; i < irisList.Count; i++)
            {
                var row = similarityMatrix.SliceRow(i).ToList();
                var kNearestNeighbors = row.OrderByDescending(x => x).Take(k);
                foreach (double kNearestNeighbor in kNearestNeighbors)
                {
                    int index = row.IndexOf(kNearestNeighbor);

                    if (!graph2.NodeList[i].Neighbors.Contains(graph2.NodeList[index]))
                    {
                        graph2.NodeList[i].Neighbors.Add(graph2.NodeList[index]);
                        graph2.NodeList[index].Neighbors.Add(graph2.NodeList[i]);

                    }

                    if (kNearestNeighbor > epsilon && !graph3.NodeList[i].Neighbors.Contains(graph3.NodeList[index]))
                    {
                        graph3.NodeList[i].Neighbors.Add(graph3.NodeList[index]);
                        graph3.NodeList[index].Neighbors.Add(graph3.NodeList[i]);
                    }
                }
            }

            graph1.PrintToCSV("e-radius.csv");
            graph2.PrintToCSV("KNN-method.csv");
            graph3.PrintToCSV("combined.csv");

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        public static void PrintMatrix(double[,] matrix)
        {
            // print
            for (int i = 0; i < 150; i++)
            {
                for (int j = 0; j < 150; j++)
                {
                    Console.Write($"{matrix[i, j]:F2} ");
                }
                Console.WriteLine();
            }
        }
    }
}
