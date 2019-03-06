using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace CV_3_Kernighan
{
    class Program
    {
        static void Main(string[] args)
        {
            const int numberOfNodes = 34;

            var graph = new Graph(numberOfNodes);
            var dt = new DataLoader();
            dt.LoadData(graph);
            var rand = new Random();

            int firstGroupCount = 0;
            int secondGroupCount = 0;
            foreach (var node in graph.NodeList)
            {
                int randomNumber = rand.Next(2);
                if(firstGroupCount >= numberOfNodes /2)
                {
                    randomNumber = 1;
                } else if( secondGroupCount >= numberOfNodes / 2)
                {
                    randomNumber = 0;
                }
                node.Degree = node.Neighbors.Count;
                node.GroupId = randomNumber;
                if(randomNumber == 0)
                {
                    firstGroupCount++;
                }else
                {
                    secondGroupCount++;
                }

            }

            var groups = graph.NodeList.GroupBy(x => x.GroupId).ToList();

            var group1 = groups[0].ToList();
            var group2 = groups[1].ToList();
            var usedNodes = new HashSet<GraphNode>();


            while (usedNodes.Count < numberOfNodes)
            {
                var cutSizes = new Dictionary<(int i, int j), int>();
                int originalCutSize = CutSize(group1, group2);

                for (int i = 0; i < group1.Count; i++)
                {
                    if (usedNodes.Contains(group1[i])) continue;
                    for (int j = 0; j < group2.Count; j++)
                    {
                        if (usedNodes.Contains(group2[j])) continue;
                        var group1Copy = new List<GraphNode>(group1);
                        var group2Copy = new List<GraphNode>(group2);
                        group1Copy.Remove(group1[i]);
                        group1Copy.Add(group2[j]);
                        group2Copy.Remove(group2[j]);
                        group2Copy.Add(group1[i]);
                        cutSizes.Add((i, j), CutSize(group1Copy, group2Copy));
                    }
                }

                int minimalCutSize = cutSizes.Values.Min();
                var indexes = cutSizes.FirstOrDefault(x => x.Value == minimalCutSize).Key;

                usedNodes.Add(group1[indexes.i]);
                usedNodes.Add(group2[indexes.j]);
                group1[indexes.i].GroupId = 1;
                group2[indexes.j].GroupId = 0;
                group1.Add(group2[indexes.j]);
                group2.Add(group1[indexes.i]);
                group1.Remove(group1[indexes.i]);
                group2.Remove(group2[indexes.j]);

            }

            var group1Graph = new Graph(0);
            var group2Graph = new Graph(0);

            group1Graph.NodeList = group1;
            group2Graph.NodeList = group2;

            group1Graph.PrintToCSV("g1.csv");
            group2Graph.PrintToCSV("g2.csv");

            Console.ReadKey();
        }

        public static int CutSize(List<GraphNode> group1, List<GraphNode> group2)
        {
            int cutSize = 0;
            for (int i = 0; i < group1.Count; i++)
            {
                for (int j = 0; j < group2.Count; j++)
                {
                    if (group1[i].isNeighbor(group2[j]))
                    {
                        cutSize++;
                    }
                }
            }

            return cutSize;
        }

    }
}
