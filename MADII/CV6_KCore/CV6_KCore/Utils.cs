using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV6_KCore
{
    public class Utils
    {
        public static void PrintMatrix<T>(T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    Console.Write(typeof(T) == typeof(int) ? $"{matrix[i, j]:0}" : $"{matrix[i, j]:0.00}");

                    Console.Write(" ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public static double[,] GetSimilarityMatrix(int[,] matrix)
        {

            double[,] resultMatrix = new double[matrix.GetLength(0), matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    resultMatrix[i, j] = GetSimilarity(matrix, i, j);
                }
            }
            return resultMatrix;
        }

        private static double GetSimilarity(int[,] matrix, int left, int right)
        {
            double ab = 0.0;
            double aa = 0.0;
            double bb = 0.0;

            for (int i = 0; i < matrix.GetLength(1); ++i)
            {
                aa += matrix[left, i] * matrix[left, i];
                ab += matrix[left, i] * matrix[right, i];
                bb += matrix[right, i] * matrix[right, i];
            }

            if (aa == 0)
                return 0.0; //return bb == 0 ? 1.0 : 0.0;
            else if (bb == 0)
                return 0.0;
            else
                return ab / Math.Sqrt(aa) / Math.Sqrt(bb);
        }
        private static int GetDegree(int[,] matrix, int colNumber)
        {
            int[] column = Enumerable.Range(0, matrix.GetLength(0))
                .Select(x => matrix[x, colNumber])
                .ToArray();
            int degree = 0;
            for (int i = 0; i < column.Length; i++)
            {
                if (column[i] == 1)
                {
                    degree++;
                }
            }

            return degree;
        }
    }
}
