using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_9_MultiLayerNetworks
{
    public class MultiGraphNode
    {
        public int Id { get; }
        public Dictionary<string, List<MultiGraphNode>> Layers { get; set; }
        public int Degree { get; set; }
        public float ClusteringCoefficient { get; set; }
        public Actor NodeActor { get; }

        public MultiGraphNode(int id, string name)
        {
            Layers = new Dictionary<string, List<MultiGraphNode>>();

            Id = id;
            NodeActor = new Actor(name);
        }

        public MultiGraphNode(MultiGraphNode graphNode)
        {
            Layers = new Dictionary<string,List<MultiGraphNode>>(graphNode.Layers);
            Id = graphNode.Id;
            Degree = graphNode.Degree;
            ClusteringCoefficient = graphNode.ClusteringCoefficient;
        }

        public bool Equals(MultiGraphNode obj)
        {
            return obj.Id == Id;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as MultiGraphNode);
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
