using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Windows.Forms;

namespace Project.Network
{
    public class DataLoader
    {
        public static Graph LoadData(Graph g, string fileName)
        {
            List<string> rows = LoadCsvFile(fileName);
            var createdNodes = new Dictionary<int, GraphNode>(); 
            foreach (string row in rows)
            {
                List<string> attributes = row.Split(' ').ToList();
                createdNodes.TryGetValue(int.Parse(attributes[0]), out var node1);
                createdNodes.TryGetValue(int.Parse(attributes[1]), out var node2);
                if (node1 == null)
                {
                    node1 = new GraphNode(int.Parse(attributes[0]));
                    g.NodeList.Add(node1);
                    createdNodes[node1.Id] = node1;
                }

                if (node2 == null)
                {
                    node2 = new GraphNode(int.Parse(attributes[1]));
                    g.NodeList.Add(node2);
                    createdNodes[node2.Id] = node2;
                }

                node1.Neighbors.Add(node2);
                node2.Neighbors.Add(node1);
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
            try
            {

                var reader = new StreamReader(File.OpenRead(filePath));
                var searchList = new List<string>();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    searchList.Add(line);
                }

                reader.Dispose();
                return searchList;
            }
            catch (SecurityException ex)
            {
                MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\nDetails:\n\n{ex.StackTrace}");
                throw;
            }
        }
    }
}
