using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_1
{
    public class GraphNode
    {
        public Iris IrisInstance { get; set; }
        public List<GraphNode> Neighbors {get;set;}
        public int Degree { get; set; }
        public float ClusteringCoefficient { get; set; }

        public GraphNode(Iris iris)
        {
            Neighbors = new List<GraphNode>();
            IrisInstance = new Iris(iris);
        }

        public override string ToString()
        {
            return IrisInstance.Id.ToString();
        }
    }
}
