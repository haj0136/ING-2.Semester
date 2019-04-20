using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV7_Resistance
{
    public class Graph
    {
        public List<GraphNode> NodeList { get; }

        public double AverageDegree { get; set; }

        public Graph()
        {
            NodeList = new List<GraphNode>();
        }

        public Graph(int nodes) : this()
        {
            for (int i = 0; i < nodes; i++)
            {
                NodeList.Add(new GraphNode(i));
            }
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
    }
}
