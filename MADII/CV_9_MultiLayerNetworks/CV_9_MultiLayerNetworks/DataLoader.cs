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
        public static MultiGraph LoadMultiLayerGraph(MultiGraph g, string fileName)
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
                    var newNode = new MultiGraphNode(nodeId++, attributes[0]);
                    g.NodeList.Add(newNode);
                    newNode.Layers.Add("marriage", new List<MultiGraphNode>());
                    newNode.Layers.Add("business", new List<MultiGraphNode>());
                }

                if (isEdge)
                {
                    if (attributes[2].Equals("marriage"))
                    {
                        g.GetNodeByActor(attributes[0]).Layers["marriage"].Add(g.GetNodeByActor(attributes[1]));
                        g.GetNodeByActor(attributes[1]).Layers["marriage"].Add(g.GetNodeByActor(attributes[0]));
                    }
                    else if (attributes[2].Equals("business"))
                    {
                        g.GetNodeByActor(attributes[0]).Layers["business"].Add(g.GetNodeByActor(attributes[1]));
                        g.GetNodeByActor(attributes[1]).Layers["business"].Add(g.GetNodeByActor(attributes[0]));
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

        public static MultiGraph LoadTemporalGraph(MultiGraph g, string fileName, int layersCount)
        {
            List<string> rows = LoadCsvFile(fileName);
            int rowsPerLayer = (rows.Count / layersCount) + 1;
            int actualLayer = 1;

            for (int index = 0; index < rows.Count; index++)
            {
                if ((index + 1) > rowsPerLayer * actualLayer)
                {
                    actualLayer++;
                }
               
                List<string> attributes = rows[index].Split('\t').ToList();
                var node1 = g.GetNodeById(Int32.Parse(attributes[1]));
                var node2 = g.GetNodeById(Int32.Parse(attributes[2]));
                if (node1 == null)
                {
                    node1 = new MultiGraphNode(Int32.Parse(attributes[1]), attributes[1]);
                    CreateLayers(layersCount, node1);
                    g.NodeList.Add(node1);
                }
                if (node2 == null)
                {
                    node2 = new MultiGraphNode(Int32.Parse(attributes[2]), attributes[2]);
                    CreateLayers(layersCount, node2);
                    g.NodeList.Add(node2);
                }

                node1.Layers[actualLayer.ToString()].Add(node2);
                node2.Layers[actualLayer.ToString()].Add(node1);
            }

            return g;
        }

        private static void CreateLayers(int layersCount, MultiGraphNode node)
        {
            for (int i = 0; i < layersCount; i++)
            {
                node.Layers.Add((i + 1).ToString(), new List<MultiGraphNode>());
            }
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
