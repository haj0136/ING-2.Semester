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
            //  ############### Part one
            var multiGraph = new MultiGraph();
            DataLoader.LoadMultiLayerGraph(multiGraph, "DATA/florentine.mpx");

            multiGraph.PrintDegreeCentrality();
            Console.WriteLine();
            multiGraph.PrintNeighborhoodCentrality();

            Console.WriteLine();
            //  ############### Part two
            var temporalGraph = new MultiGraph();
            DataLoader.LoadTemporalGraph(temporalGraph, "DATA/contact_list.dat", 5);

            temporalGraph.PrintDegreeCentrality();
            Console.WriteLine();
            temporalGraph.PrintNeighborhoodCentrality();
        }
    }
}
