using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_5_Hierarchic_clustering
{
    class Program
    {
        static void Main(string[] args)
        {
            const int numberOfNodes = 34;
            var dt = new DataLoader();
            int[,] adjacencyMatrix = new int[numberOfNodes, numberOfNodes];
            double[,] similarityMatrix = new double[numberOfNodes, numberOfNodes];
            adjacencyMatrix = dt.LoadDataToMatrix(adjacencyMatrix);
            similarityMatrix = Utils.GetSimilarityMatrix(adjacencyMatrix);


            Utils.PrintMatrix(similarityMatrix);
        }

        
    }
}
