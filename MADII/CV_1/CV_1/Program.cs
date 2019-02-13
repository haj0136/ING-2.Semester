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
            const double epsilon = 0.5d;

            var dl = new DataLoader();
            List<Iris> irisList = dl.LoadData();

            var similarityMatrix = new double[irisList.Count, irisList.Count];

            for (int i = 0; i < irisList.Count; i++)
            {
                for (int j = 0; j < irisList.Count; j++)
                {
                    similarityMatrix[i, j] = Utils.GaussianKernel(irisList[i].ToArray(), irisList[j].ToArray(), variance);
                }
            }

            PrintMatrix(similarityMatrix);
            Console.ReadKey();
        }

        public static void PrintMatrix(double[,] matrix)
        {
            // print
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    Console.Write($"{matrix[i,j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
