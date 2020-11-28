using Project.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Accord.Statistics.Distributions.Univariate;

namespace Project.SamplingAlgorithms
{
    public class ForestFireSampling : ISampling
    {
        private readonly Random _rnd;

        public ForestFireSampling()
        {
            _rnd = new Random();
        }

        public Graph GetSample(double size, List<GraphNode> nodeList, double fireProb)
        {
            var sampledGraph = new Graph();
            var burnedNodes = new Dictionary<int, GraphNode>();
            int finalSize = (int)(nodeList.Count * size);
            var queue = new Queue<GraphNode>();

            var dist = new GeometricDistribution(0.3);
            Console.WriteLine();

            int v0 = _rnd.Next(nodeList.Count);
            var firstNode = new GraphNode(nodeList[v0].Id);
            sampledGraph.NodeList.Add(firstNode);
            burnedNodes.Add(firstNode.Id, firstNode);
            queue.Enqueue(nodeList[v0]);

            while (sampledGraph.NodeList.Count < finalSize && queue.Count > 0)
            {
                GraphNode actualNode = queue.Dequeue();
                int nodesToBurn = (int)GetGeometricRandomNumber(1 / (1 + fireProb / (1 - fireProb)));
                List<GraphNode> selectedNeighbors;

                if (nodesToBurn >= actualNode.Neighbors.Count)
                {
                    selectedNeighbors = actualNode.Neighbors;
                }
                else
                {
                    foreach (var neighbor in actualNode.Neighbors)
                    {
                        if (burnedNodes.ContainsKey(neighbor.Id))
                        {
                            var foundNode = burnedNodes[neighbor.Id];
                            if (!foundNode.Neighbors.Contains(burnedNodes[actualNode.Id]))
                            {
                                foundNode.Neighbors.Add(burnedNodes[actualNode.Id]);
                                burnedNodes[actualNode.Id].Neighbors.Add(foundNode);
                            }
                        }
                    }
                    selectedNeighbors = actualNode.Neighbors.FindAll(x => !burnedNodes.ContainsKey(x.Id)).OrderBy(i => _rnd.Next()).Take(nodesToBurn).ToList();
                }

                foreach (var neighbor in selectedNeighbors)
                {
                    if (!burnedNodes.ContainsKey(neighbor.Id))
                    {
                        queue.Enqueue(neighbor);
                        var newNode = new GraphNode(neighbor.Id);
                        newNode.Neighbors.Add(burnedNodes[actualNode.Id]);
                        burnedNodes[actualNode.Id].Neighbors.Add(newNode);
                        sampledGraph.NodeList.Add(newNode);
                        burnedNodes.Add(newNode.Id, newNode);
                    }
                    else
                    {
                        var foundNode = burnedNodes[neighbor.Id];
                        if (!foundNode.Neighbors.Contains(burnedNodes[actualNode.Id]))
                        {
                            foundNode.Neighbors.Add(burnedNodes[actualNode.Id]);
                            burnedNodes[actualNode.Id].Neighbors.Add(foundNode);
                        }
                    }
                }



            }


            return sampledGraph;
        }

        private double GetGeometricRandomNumber(double probability)
        {
            return Math.Ceiling(Math.Log(1 -_rnd.NextDouble()) / Math.Log(1 - probability));
        }
    }
}
