using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaussianElimination
{
    public class DataLoader
    {
        public static float[,] LoadData()
        {
            var rows = LoadFileByLine(@"data\matrix1.txt").ToList();
            int columnCount = rows[0].Split(' ').Length;
            var matrix = new float[rows.Count, columnCount];

            int i = 0;
            foreach (string row in rows)
            {
                List<string> values = row.Split(' ').ToList();
                for (int j = 0; j < values.Count; j++)
                {
                    matrix[i, j] = int.Parse(values[j]);
                }
                i++;
            }
            return matrix;
        }

        private static IEnumerable<string> LoadFileByLine(string filePath)
        {
            var reader = new StreamReader(File.OpenRead(filePath));
            var searchList = new List<string>();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                searchList.Add(line);
            }

            return searchList;
        }
    }
}
