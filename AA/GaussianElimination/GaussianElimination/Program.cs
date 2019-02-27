using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaussianElimination
{
    class Program
    {
        static void Main(string[] args)
        {
            float[,] matrix = DataLoader.LoadData();
            Console.WriteLine("Matrix:");
            MatrixUtils.PrintMatrix(matrix);

            var temp = LinearEquationSolver.Solve(matrix);

            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey();
        }
    }
}
