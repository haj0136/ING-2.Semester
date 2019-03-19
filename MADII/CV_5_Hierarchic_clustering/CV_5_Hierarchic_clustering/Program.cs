using System;
using System.Linq;

namespace CV_5_Hierarchic_clustering
{
    class Program
    {
        static void Main(string[] args)
        {
            const int numberOfNodes = 34;
            const int numberOfClusters = 3;

            var dt = new DataLoader();
            var graph = new Graph(numberOfNodes);
            foreach (var node in graph.NodeList)
            {
                node.Cluster = node.Id;
            }
            dt.LoadData(graph);
            var adjacencyMatrix = new int[numberOfNodes, numberOfNodes];
            adjacencyMatrix = dt.LoadDataToMatrix(adjacencyMatrix);
            //Utils.PrintMatrix(adjacencyMatrix);

            while (graph.NodeList.GroupBy(x => x.Cluster).Count() > numberOfClusters)
            {
                var similarityMatrix = Utils.GetSimilarityMatrix(adjacencyMatrix);
                //Utils.PrintMatrix(adjacencyMatrix);
                //Utils.PrintMatrix(similarityMatrix);

                // find max value
                int row = 1, col = 0;

                for (int i = 0; i < numberOfNodes; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (similarityMatrix[i, j] > similarityMatrix[row, col])
                        {
                            row = i;
                            col = j;
                        }
                    }
                }

                Console.WriteLine();
                Console.WriteLine($"row:{row + 1}   col:{col + 1}");
                var tempCluster = graph.NodeList.FindAll(x => x.Cluster == graph.NodeList[row].Cluster);
                foreach (var vertex in tempCluster)
                {
                    vertex.Cluster = graph.NodeList[col].Cluster;
                }
                for (int i = 0; i < numberOfNodes; i++)
                {
                    if (adjacencyMatrix[row, i] == 1 && col != i)
                    {
                        adjacencyMatrix[col, i] = 1;
                        adjacencyMatrix[i, col] = 1;
                    }
                        adjacencyMatrix[row, i] = 0;
                        adjacencyMatrix[i, row] = 0;
                }

                var clusters = graph.NodeList.GroupBy(x => x.Cluster);
                int clusterId = 0;
                foreach (var cluster in clusters)
                {
                    Console.WriteLine($"cluster {clusterId}:");
                    foreach (var graphNode in cluster)
                    {
                        Console.Write($"{graphNode.Id + 1}  ");
                    }

                    Console.WriteLine();
                    clusterId++;
                }
            }

            //var clusters = graph.NodeList.GroupBy(x => x.cluster);
            //foreach (var cluster in clusters)
            //{
            //    Console.WriteLine($"cluster: {cluster.Key}");
            //}

            //Utils.PrintMatrix(similarityMatrix);
        }


    }
}
