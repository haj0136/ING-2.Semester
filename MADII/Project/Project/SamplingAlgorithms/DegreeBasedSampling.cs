﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Network;

namespace Project.SamplingAlgorithms
{
    public class DegreeBasedSampling : ISampling
    {
        private readonly Random _rnd;

        public DegreeBasedSampling()
        {
            _rnd = new Random();
        }

        public Graph GetSample(double size, List<GraphNode> nodeList, double restartChance)
        {
            var sampledGraph = new Graph();
            float m = CountEdges(nodeList);

            // nodes
            for (int i = 0; i < nodeList.Count; i++)
            {
                double randomNumber = _rnd.NextDouble();
                int nodeDegree = nodeList[i].Neighbors.Count();
                if (randomNumber <= size + nodeDegree / m)
                {
                    if (!sampledGraph.NodeList.Contains(nodeList[i]))
                    {
                        sampledGraph.NodeList.Add(new GraphNode(nodeList[i].Id));
                    }
                }
            }
            // edges
            for (int i = 0; i < nodeList.Count; i++)
            {
                for (int j = i + 1; j < nodeList.Count; j++)
                {
                    if (i != j && nodeList[i].Neighbors.Contains(nodeList[j]))
                    {
                        if (sampledGraph.NodeList.Contains(nodeList[i]) && sampledGraph.NodeList.Contains(nodeList[j]))
                        {
                            int node1 = sampledGraph.NodeList.IndexOf(nodeList[i]);
                            int node2 = sampledGraph.NodeList.IndexOf(nodeList[j]);
                            sampledGraph.NodeList[node1].Neighbors.Add(sampledGraph.NodeList[node2]);
                            sampledGraph.NodeList[node2].Neighbors.Add(sampledGraph.NodeList[node1]);
                        }
                    }
                }
            }



            return sampledGraph;
        }

        private int CountEdges(IEnumerable<GraphNode> nodeList)
        {
            int numberOfEdges = 0;

            foreach (var node in nodeList)
            {
                foreach (var t in node.Neighbors)
                {
                    numberOfEdges++;
                }
            }

            return numberOfEdges / 2;
        }
    }
}
