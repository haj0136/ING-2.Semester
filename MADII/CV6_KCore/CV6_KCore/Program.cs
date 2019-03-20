using System;
using System.Collections.Generic;

namespace CV6_KCore
{
    class Program
    {
        static void Main(string[] args)
        {
            const int numberOfNodes = 34;
            const int K = 4;

            var graph = new Graph(numberOfNodes);
            var dl = new DataLoader();
            dl.LoadData(graph);

            var nodesToDelete = new List<GraphNode>();

            while (graph.NodeList.FindAll(x => x.Degree < K).Count > 0)
            {

                foreach (var node in graph.NodeList)
                {
                    node.Degree = node.Neighbors.Count;
                    if (node.Degree < K)
                    {
                        nodesToDelete.Add(node);
                    }
                }

                foreach (var node in nodesToDelete)
                {
                    graph.NodeList.Remove(node);
                    foreach (var neighbor in node.Neighbors)
                    {
                        neighbor.Neighbors.Remove(node);
                    }
                }

                foreach (var node in graph.NodeList)
                {
                    node.Degree = node.Neighbors.Count;
                }
            }


            // print
            foreach (var node in graph.NodeList)
            {
                Console.WriteLine(node.Id + 1);
            }



        }
    }
}
