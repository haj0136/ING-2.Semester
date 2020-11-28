using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Network;

namespace Project.SamplingAlgorithms
{
    public interface ISampling
    {
        Graph GetSample(double size, List<GraphNode> nodeList, double restartChance);
    }
}
