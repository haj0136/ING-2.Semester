using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_9_MultiLayerNetworks
{
    public class Graph
    {
        public List<GraphNode> NodeList { get; }

        public double AverageDegree { get; set; }

        public Graph()
        {
            NodeList = new List<GraphNode>();
        }

        public Graph(Graph g) : this()
        {
            foreach (var graphNode in g.NodeList)
            {
                NodeList.Add(new GraphNode(graphNode));
            }

            AverageDegree = g.AverageDegree;
        }

        public GraphNode GetNodeById(int id)
        {
            GraphNode node = NodeList.Find(x => x.Id == id);
            if (node == null)
            {
                Debug.WriteLine($"GetNodeById({id}) returned null");
            }
            return node;
        }

        public GraphNode GetNodeByActor(string name)
        {
            GraphNode node = NodeList.Find(x => x.NodeActor.Name.Equals(name));
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
                int dc = graphNode.BusinessLayer.Count + graphNode.MarriageLayer.Count;
                Console.WriteLine($"{graphNode.NodeActor} : {dc}");
            }
        }

        public void PrintNeighborhoodCentrality()
        {
            Console.WriteLine("Neighborhood Centrality:");
            foreach (var graphNode in NodeList)
            {
                var uniqueNeighbors = new HashSet<GraphNode>();
                foreach (var node in graphNode.BusinessLayer)
                {
                    uniqueNeighbors.Add(node);
                }

                foreach (var node in graphNode.MarriageLayer)
                {
                    uniqueNeighbors.Add(node);
                }

                int nc = uniqueNeighbors.Count;
                Console.WriteLine($"{graphNode.NodeActor} : {nc}");
            }
        }
    }
}
