using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_3_Kernighan
{
    public class Graph
    {
        public List<GraphNode> NodeList { get; set; }

        public double AverageDegree { get; set; }

        public double AverageCC { get; set; }

        public Graph(int nodes)
        {
            NodeList = new List<GraphNode>();
            for (int i = 0; i < nodes; i++)
            {
                NodeList.Add(new GraphNode(i + 1));
            }
        }

        public void PrintToCSV(string filePath)
        {
            var csv = new StringBuilder();
            csv.Append("Source;Target\n");
            for (int i = 0; i < NodeList.Count; i++)
            {
                for (int j = i + 1; j < NodeList.Count; j++)
                {
                    if (i != j && NodeList[i].Neighbors.Contains(NodeList[j]))
                    {
                        csv.Append($"{NodeList[i].Id};{NodeList[j].Id}\n");
                    }
                }
            }

            File.WriteAllText(filePath, csv.ToString());
        }

        //shlukovací efekt
        public void WriteToCSV(string filePath)
        {
            var map = new Dictionary<int, double>();
            var set = new HashSet<int>();
            var csv = new StringBuilder();
            csv.Append("Degree;Average Clustering Coeficient\n");
            for (int i = 0; i < NodeList.Count; i++)
            {
                set.Add(NodeList[i].Degree);
            }
            foreach (var item in set)
            {
                var temp = NodeList.Where(x => x.Degree == item).Select(x => x);
                map[item] = temp.Sum(x => x.ClusteringCoefficient) / temp.Count();
            }
            foreach (var item in map)
            {
                var newLine = string.Format("{0};{1}\n", item.Key, item.Value);
                csv.Append(newLine);
            }

            File.WriteAllText(filePath, csv.ToString());
        }

        public void CutSize()
        {
           
        }
    }
}
