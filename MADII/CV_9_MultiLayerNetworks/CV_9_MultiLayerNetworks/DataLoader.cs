using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_9_MultiLayerNetworks
{
    public class DataLoader
    {
        public static Graph LoadData(Graph g, string fileName)
        {
            List<string> rows = LoadCsvFile(fileName);
            bool isActor = false;
            bool isEdge = false;
            int nodeId = 1;
            foreach (string row in rows)
            {
                if (string.IsNullOrEmpty(row))
                {
                    isActor = false;
                    isEdge = false;
                    continue;
                }

                List<string> attributes = row.Split(',').ToList();
                if (isActor)
                {
                    g.NodeList.Add(new GraphNode(nodeId++, attributes[0]));
                }

                if (isEdge)
                {
                    if (attributes[2].Equals("marriage"))
                    {
                        g.GetNodeByActor(attributes[0]).MarriageLayer.Add(g.GetNodeByActor(attributes[1]));
                        g.GetNodeByActor(attributes[1]).MarriageLayer.Add(g.GetNodeByActor(attributes[0]));
                    }
                    else if (attributes[2].Equals("business"))
                    {
                        g.GetNodeByActor(attributes[0]).BusinessLayer.Add(g.GetNodeByActor(attributes[1]));
                        g.GetNodeByActor(attributes[1]).BusinessLayer.Add(g.GetNodeByActor(attributes[0]));
                    }
                    else
                    {
                        throw new Exception($"Unknown layer: {attributes[2]}");
                    }
                }

                if (row.Equals("#ACTORS"))
                {
                    isActor = true;
                    isEdge = false;
                } else if (row.Equals("#EDGES"))
                {
                    isActor = false;
                    isEdge = true;
                }
            }
            return g;
        }

        public int[,] LoadDataToMatrix(int[,] matrix)
        {
            List<string> rows = LoadCsvFile("Data/KarateClub.csv");
            foreach (string row in rows)
            {
                List<string> attributes = row.Split(';').ToList();
                matrix[Int32.Parse(attributes[0]) - 1, Int32.Parse(attributes[1]) - 1] = 1;
                matrix[Int32.Parse(attributes[1]) - 1, Int32.Parse(attributes[0]) - 1] = 1;
            }
            return matrix;
        }

        private static List<string> LoadCsvFile(string filePath)
        {
            var reader = new StreamReader(File.OpenRead(filePath));
            var searchList = new List<string>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                searchList.Add(line);
            }

            return searchList;
        }
    }
}
