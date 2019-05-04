using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_9_MultiLayerNetworks
{
    public class GraphNode
    {
        public int Id { get; }
        public List<GraphNode> MarriageLayer { get; set; }
        public List<GraphNode> BusinessLayer { get; set; }
        public int Degree { get; set; }
        public float ClusteringCoefficient { get; set; }
        public Actor NodeActor { get; }

        public GraphNode(int id, string name)
        {
            MarriageLayer = new List<GraphNode>();
            BusinessLayer = new List<GraphNode>();
            Id = id;
            NodeActor = new Actor(name);
        }

        public GraphNode(GraphNode graphNode)
        {
            MarriageLayer = new List<GraphNode>(graphNode.MarriageLayer);
            BusinessLayer = new List<GraphNode>(graphNode.BusinessLayer);
            Id = graphNode.Id;
            Degree = graphNode.Degree;
            ClusteringCoefficient = graphNode.ClusteringCoefficient;
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

        public override string ToString()
        {
            return NodeActor.ToString();
        }
    }
}
