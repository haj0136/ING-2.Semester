﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_7_LS_And_CP_models
{
    public class GraphNode
    {
        public int Id { get; }
        public List<GraphNode> Neighbors { get; set; }
        public int Degree { get; set; }
        public float ClusteringCoefficient { get; set; }
        public int Time { get; set; }

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
            Time = graphNode.Time;
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
