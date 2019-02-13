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

        public Graph(int nodes)
        {
            NodeList = new List<GraphNode>();
            // _rnd = new Random();
        }

        public void PrintToCSV(string filePath)
        {
            var csv = new StringBuilder();
            for (int i = 0; i < NodeList.Count; i++)
            {
                for (int j = i + 1; j < NodeList.Count; j++)
                {
                    if (i != j && NodeList[i].Neighbors.Contains(NodeList[j]))
                    {
                        //csv.Append($"{NodeList[i].Id};{NodeList[j].Id}\n");
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
    }
}
