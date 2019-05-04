using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_9_MultiLayerNetworks
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph();
            DataLoader.LoadData(graph, "DATA/florentine.mpx");

            graph.PrintDegreeCentrality();
            Console.WriteLine();
            graph.PrintNeighborhoodCentrality();
        }
    }
}
