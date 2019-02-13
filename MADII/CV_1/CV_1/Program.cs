using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var dl = new DataLoader();
            List<Iris> irisList = dl.LoadData();

            var similarityMatrix = new double[irisList.Count, irisList.Count];
            var graph = new Graph(irisList);

            for (int i = 0; i < irisList.Count; i++)
            {
                for (int j = 0; j < irisList.Count; j++)
                {
                    similarityMatrix[i, j] = Utils.GaussianKernel(irisList[i].ToArray(), irisList[j].ToArray(), variance);

                    if(similarityMatrix[i,j] > epsilon)
                    {
                        graph.NodeList[i].Neighbors.Add(graph.NodeList[j]);
                        graph.NodeList[j].Neighbors.Add(graph.NodeList[i]);
                    }
                }
            }

            graph.PrintToCSV("test.csv");
            Console.WriteLine(graph.CountEdges());
            Console.ReadKey();
        }

        public static void PrintMatrix(double[,] matrix)
        {
            // print
            for (int i = 0; i < 150; i++)
            {
                for (int j = 0; j < 150; j++)
                {
                    Console.Write($"{matrix[i,j]:F2} ");
                }
                Console.WriteLine();
            }
        }
    }
}
