using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_7_LS_And_CP_models
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start generating graphs.");
            var graphGenerator = new GraphGenerator(m0: 2, m: 1, numberOfNodes: 10, p: 1f, agingParam:0.01f);

            var copyingModel = graphGenerator.GenerateCopyingModel();
            var linkSelection = graphGenerator.GenerateLinkSelectionModel();

            copyingModel.PrintToCSV("copyingModel.csv");
            linkSelection.PrintToCSV("linkSelection.csv");
        }
    }
}
