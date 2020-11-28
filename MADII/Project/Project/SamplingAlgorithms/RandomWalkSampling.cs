using Project.Network;
using System;
using System.Collections.Generic;

namespace Project.SamplingAlgorithms
{
    public class RandomWalkSampling : ISampling
    {
        private readonly Random _rnd;

        public RandomWalkSampling()
        {
            _rnd = new Random();
        }

        public Graph GetSample(double size, List<GraphNode> nodeList, double restartChance)
        {
            var sampledGraph = new Graph();
            var nodeDic = new Dictionary<int, GraphNode>();
            int finalSize = (int)(nodeList.Count * size);

            int v0 = _rnd.Next(nodeList.Count - 1);
            int vk = v0;
            var firstNode = new GraphNode(nodeList[v0].Id);
            sampledGraph.NodeList.Add(firstNode);
            nodeDic.Add(firstNode.Id, firstNode);
            var actualNode = firstNode;
            while (sampledGraph.NodeList.Count < finalSize)
            {
                if (restartChance > _rnd.NextDouble())
                {
                    vk = v0;
                }

                int vk1 = _rnd.Next(nodeList[vk].Neighbors.Count);
                var newNode = new GraphNode(nodeList[vk].Neighbors[vk1].Id);
                if (nodeDic.ContainsKey(newNode.Id))
                {
                    newNode = nodeDic[newNode.Id];
                }
                else
                {
                    sampledGraph.NodeList.Add(newNode);
                    nodeDic.Add(newNode.Id, newNode);
                }

                if (!actualNode.Neighbors.Contains(newNode))
                {
                    actualNode.Neighbors.Add(newNode);
                }

                if (!newNode.Neighbors.Contains(actualNode))
                {
                    newNode.Neighbors.Add(actualNode);
                }
                actualNode = newNode;
                vk = nodeList.IndexOf(actualNode);
            }

            return sampledGraph;
        }
    }
}
