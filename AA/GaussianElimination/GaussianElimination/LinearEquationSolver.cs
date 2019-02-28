using System;

namespace GaussianElimination
{
    public static class LinearEquationSolver
    {
        /// <summary>Computes the solution of a linear equation system.</summary>
        /// <param name="M">
        /// The system of linear equations as an augmented matrix[row, col] where (rows + 1 == cols).
        /// It will contain the solution in "row canonical form" if the function returns "true".
        /// </param>
        /// <returns>Returns whether the matrix has a unique solution or not.</returns>
        public static bool Solve(float[,] M)
        {
            // input checks
            int rowCount = M.GetUpperBound(0) + 1;
            if (M == null || M.Length != rowCount * (rowCount + 1))
                throw new ArgumentException("Please enter (n x n+1) matrix.");
            if (rowCount < 1)
                throw new ArgumentException("The matrix must have at least one row.");

            // pivoting
            for (int col = 0; col + 1 < rowCount; col++)
            {
                // check for zero coefficients
                if (M[col, col] == 0)
                {
                    // find non-zero coefficient
                    int swapRowIndex = col + 1;
                    for (; swapRowIndex < rowCount; swapRowIndex++)
                    {
                        if (M[swapRowIndex, col] != 0f)
                            break;
                    }

                    if (M[swapRowIndex, col] != 0)
                    {
                        var tmp = new float[rowCount + 1];
                        for (int i = 0; i < rowCount + 1; i++)
                        {
                            tmp[i] = M[swapRowIndex, i];
                            M[swapRowIndex, i] = M[col, i];
                            M[col, i] = tmp[i];
                        }
                    }
                    else
                    {
                        Console.WriteLine("Matrix has no unique solution.");
                        return false; 
                    }
                }
            }

            Console.WriteLine("After pivoting:");
            MatrixUtils.PrintMatrix(M);
            // elimination
            for (int sourceRow = 0; sourceRow + 1 < rowCount; sourceRow++)
            {
                for (int destRow = sourceRow + 1; destRow < rowCount; destRow++)
                {
                    float df = M[sourceRow, sourceRow];
                    float sf = M[destRow, sourceRow];
                    for (int i = 0; i < rowCount + 1; i++)
                        M[destRow, i] = M[destRow, i] * df - M[sourceRow, i] * sf;
                }
            }

            Console.WriteLine("Upper triangular matrix:");
            MatrixUtils.PrintMatrix(M);
            // back-insertion
            for (int row = rowCount - 1; row >= 0; row--)
            {
                float f = M[row, row];
                if (f == 0) return false;

                for (int i = 0; i < rowCount + 1; i++) M[row, i] /= f;
                for (int destRow = 0; destRow < row; destRow++)
                { M[destRow, rowCount] -= M[destRow, row] * M[row, rowCount]; M[destRow, row] = 0; }
            }

            Console.WriteLine("Result:");
            MatrixUtils.PrintMatrix(M);
            return true;
        }
    }
}
