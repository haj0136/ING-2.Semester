using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_4_Comunities
{
    class Program
    {
        static void Main(string[] args)
        {
            // Generate and print graph
            Console.WriteLine("Start generating graphs.");
            var graphGenerator = new GraphGenerator(m0: 3, m: 2, numberOfNodes: 500, p: 0.8f);
            var graphBA = graphGenerator.GenerateBaHolmeKin();
            var graphBianconi = graphGenerator.GenerateBianconi();
            Console.WriteLine("----Complete-----");

            graphBA.PrintToCSV("HomelKim.csv");
            graphBianconi.PrintToCSV("Bianconi.csv");
        }
    }
}
