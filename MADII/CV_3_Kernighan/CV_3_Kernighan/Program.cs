using System;
using System.Collections.Generic;
using System.Linq;
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
                node.Degree = node.Neighbours.Count;
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
            var usedEdges = new HashSet<(int i, int j)>();


            while (usedEdges.Count < (numberOfNodes/2) * (numberOfNodes/2))
            {
                var cutSizes = new Dictionary<(int i, int j), int>();
                int originalCutSize = CutSize(group1, group2);

                for (int i = 0; i < group1.Count; i++)
                {
                    for (int j = 0; j < group2.Count; j++)
                    {
                        if (usedEdges.Contains((i, j))) continue;
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

                group1[indexes.i].GroupId = 1;
                group2[indexes.j].GroupId = 0;
                group1.Add(group2[indexes.j]);
                group2.Add(group1[indexes.i]);
                group1.Remove(group1[indexes.i]);
                group2.Remove(group2[indexes.j]);

                usedEdges.Add(indexes);
            }

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
