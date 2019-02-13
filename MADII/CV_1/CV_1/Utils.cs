using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_1
{
    public class Utils
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
            double result = 0;
            result = Math.Exp(-(EuclideanDistance(x,y) / 2 * Math.Pow(variance, 2)));

            return result;
        }
    }
}
