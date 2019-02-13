using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_1
{
    public class Graph
    {
        public List<GraphNode> NodeList { get; }

        public Graph(List<Iris> irisList)
        {
            NodeList = new List<GraphNode>();
            // _rnd = new Random();
            foreach (var iris in irisList)
            {
                NodeList.Add(new GraphNode(iris));
            }
        }

        public void PrintToCSV(string filePath)
        {
            var csv = new StringBuilder();
            csv.Append("Source;Target");
            for (int i = 0; i < NodeList.Count; i++)
            {
                for (int j = i + 1; j < NodeList.Count; j++)
                {
                    if (i != j && NodeList[i].Neighbors.Contains(NodeList[j]))
                    {
                        csv.Append($"{NodeList[i].IrisInstance.Id};{NodeList[j].IrisInstance.Id}\n");
                    }
                }
            }

            File.WriteAllText(filePath, csv.ToString());
        }

        public double[,] ToMatrix()
        {
            var matrix = new double[NodeList.Count, NodeList.Count];

            for (int i = 0; i < NodeList.Count; i++)
            {
                foreach (var t in NodeList[i].Neighbors)
                {
                    int nodeIndex = NodeList.IndexOf(t);
                    matrix[i, nodeIndex] = 1;
                }
            }

            return matrix;
        }

        public int CountEdges()
        {
            int numberOfEdges = 0;

            foreach (var node in NodeList)
            {
                foreach (var t in node.Neighbors)
                {
                    numberOfEdges++;
                }
            }

            return numberOfEdges / 2;
        }
    }
}
