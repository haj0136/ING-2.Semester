using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_9_MultiLayerNetworks
{
    public class MultiGraph
    {
        public List<MultiGraphNode> NodeList { get; }

        public double AverageDegree { get; set; }

        public MultiGraph()
        {
            NodeList = new List<MultiGraphNode>();
        }

        public MultiGraph(MultiGraph g) : this()
        {
            foreach (var graphNode in g.NodeList)
            {
                NodeList.Add(new MultiGraphNode(graphNode));
            }

            AverageDegree = g.AverageDegree;
        }

        public MultiGraphNode GetNodeById(int id)
        {
            MultiGraphNode node = NodeList.Find(x => x.Id == id);
            if (node == null)
            {
                Debug.WriteLine($"GetNodeById({id}) returned null");
            }
            return node;
        }

        public MultiGraphNode GetNodeByActor(string name)
        {
            MultiGraphNode node = NodeList.Find(x => x.NodeActor.Name.Equals(name));
            if (node == null)
            {
                Debug.WriteLine($"GetNodeByActor({name}) returned null");
            }
            return node;
        }

        public void PrintDegreeCentrality()
        {
            Console.WriteLine("Degree Centrality:");
            foreach (var graphNode in NodeList)
            {
                int dc = 0;
                foreach (var layer in graphNode.Layers)
                {
                    dc += layer.Value.Count;
                }
                Console.WriteLine($"{graphNode.NodeActor} : {dc}");
            }
        }

        public void PrintNeighborhoodCentrality()
        {
            Console.WriteLine("Neighborhood Centrality:");
            foreach (var graphNode in NodeList)
            {
                var uniqueNeighbors = new HashSet<MultiGraphNode>();
                foreach (var layer in graphNode.Layers)
                {
                    foreach (var node in layer.Value)
                    {
                        uniqueNeighbors.Add(node);
                    }
                }

                int nc = uniqueNeighbors.Count;
                Console.WriteLine($"{graphNode.NodeActor} : {nc}");
            }
        }
    }
}
