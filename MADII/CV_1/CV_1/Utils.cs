using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_1
{
    public static class Utils
    {
        public static double EuclideanDistance(double[] a, double[] b)
        {
            double result = 0;
            for (int i = 0; i < a.Length; i++)
            {
                result += Math.Pow(a[i] - b[i], 2);
            }

            return Math.Sqrt(result);
        }

        public static double GaussianKernel(double x, double y, double variance)
        {
            double result = 0;
            result = Math.Exp(-(Math.Pow(x - y, 2) / 2 * Math.Pow(variance,2)));

            return result;
        }

        public static double GaussianKernel(double[] x, double[] y, double variance)
        {
            double temp = 0;
            for (int i = 0; i < x.Length; i++)
            {
                temp += Math.Pow(x[i] - y[i], 2);
            }

            double result = Math.Exp(-(temp / 2 * Math.Pow(variance, 2)));

            return result;
        }

        public static IEnumerable<T> SliceRow<T>(this T[,] array, int row)
        {
            for (var i = array.GetLowerBound(1); i <= array.GetUpperBound(1); i++)
            {
                if(i == row) continue;
                yield return array[row, i];
            }
        }
    }
}
