using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_3_Kernighan
{
    public class GraphNode
    {
        public int Id { get; }
        public List<GraphNode> Neighbors { get; set; }
        public int Degree { get; set; }
        public float ClusteringCoefficient { get; set; }
        public int GroupId { get; set; }

        public GraphNode(int id)
        {
            Neighbors = new List<GraphNode>();
            Id = id;
        }

        public GraphNode(GraphNode graphNode)
        {
            Neighbors = new List<GraphNode>(graphNode.Neighbors);
            Id = graphNode.Id;
            Degree = graphNode.Degree;
            ClusteringCoefficient = graphNode.ClusteringCoefficient;
        }

        public bool isNeighbor(GraphNode node)
        {
            if (Neighbors.Contains(node))
            {
                return true;
            }else
            {
                return false;
            }
        }

        public bool Equals(GraphNode obj)
        {
            return obj.Id == Id;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as GraphNode);
        }
        public override int GetHashCode()
        {
            return Id;
        }
    }
}
