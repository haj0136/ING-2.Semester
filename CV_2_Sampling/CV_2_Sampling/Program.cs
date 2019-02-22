using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_2_Sampling
{
    // BA, n=1000, m0= 10, m=2, M= 1990 (hran)
    // ER, n=1000, M= p*((n*(n-1))/2) = 0.00399
    // 3. naimplementovat Random Node Sampling a RDN(Degree-based Sampling), vzorek o velikosti 15%
    // 4. Posudte metody vzhledem k distribuci stupnu (vzkreslete kumulativní distribuci) // Excel || GNUPlot || R || Oxyplot
    class Program
    {
        static void Main(string[] args)
        {
            const double RnsProbability = 0.15; // 15% size 

            // Generate and print graph
            Console.WriteLine("Start generating graphs.");
            var graphGenerator = new GraphGenerator(m0: 10, m: 2, numberOfNodes: 990);
            var graphBA = graphGenerator.GenerateBA();
            var graphER = graphGenerator.generateER(probability: 0.00399f);
            Console.WriteLine("----Complete-----");
            //var edgesCount = graphBA.CountEdges();
            //var edgesCount2 = graphER.CountEdges();



            Console.ReadKey();
        }
    }
}
