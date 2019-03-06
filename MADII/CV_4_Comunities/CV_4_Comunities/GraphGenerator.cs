using System;
using System.Collections.Generic;

namespace CV_4_Comunities
{
    public class GraphGenerator
    {
        private readonly int _m0;
        private readonly int _m;
        private readonly int _numberOfNodes;
        private readonly float _probability;
        private readonly Random _rnd;

        /// <param name="m0">Number of fundamental nodes.</param>
        /// <param name="m">Number of edges for new created nodes.</param>
        /// <param name="numberOfNodes">Number of nodes.</param>
        /// <param name="p">Probability of creating triangle.</param>
        public GraphGenerator(int m0, int m, int numberOfNodes, float p)
        {
            _m0 = m0;
            _m = m;
            _numberOfNodes = numberOfNodes;
            _probability = p;
            _rnd = new Random();
        }

        public Graph GenerateBaHolmeKin()
        {
            var graph = new Graph(_m0);

            // Base graph (complete graph)
            for (int i = 0; i < graph.NodeList.Count; i++)
            {
                for (int j = 0; j < graph.NodeList.Count; j++)
                {
                    if (i == j)
                        continue;
                    graph.NodeList[i].Neighbors.Add(graph.NodeList[j]);
                }
            }

            var nodes = new List<int>();
            foreach (var node in graph.NodeList)
            {
                node.Degree = node.Neighbors.Count;
                for (int i = 0; i < node.Degree; i++)
                {
                    nodes.Add(node.Id);
                }
            }

            // Adding new nodes

            for (int i = 0; i < _numberOfNodes; i++)
            {
                var node = new GraphNode(_m0 + 1 + i);
                var usedNodesIds = new List<int>();
                for (int j = 0; j < _m; j++)
                {
                    GraphNode newNeighbor;
                    float randomNumber = (float)_rnd.NextDouble();
                    if (j == 0 || randomNumber > _probability) // First node is selected by prefered joining (j==0)
                    {
                        int randomIndex = _rnd.Next(nodes.Count - 1);
                        while (usedNodesIds.Contains(nodes[randomIndex]))
                        {
                            randomIndex = _rnd.Next(nodes.Count - 1);
                        }
                        newNeighbor = graph.NodeList.Find(x => x.Id == nodes[randomIndex]);
                        usedNodesIds.Add(nodes[randomIndex]);
                    }
                    else
                    {
                        int index = _rnd.Next(node.Neighbors[j-1].Neighbors.Count);
                        while (node.Neighbors.Contains(node.Neighbors[j - 1].Neighbors[index]))
                        {
                            index = _rnd.Next(node.Neighbors[j - 1].Neighbors.Count);
                        }
                        newNeighbor = node.Neighbors[j - 1].Neighbors[index];
                        usedNodesIds.Add(newNeighbor.Id);
                    }
 
                    node.Neighbors.Add(newNeighbor);
                    newNeighbor.Neighbors.Add(node);
                }

                for (int j = 0; j < _m; j++)
                {
                    nodes.Add(node.Id);
                    nodes.Add(node.Neighbors[j].Id);
                }

                graph.NodeList.Add(node);
            }

            return graph;
        }

        public Graph GenerateBianconi()
        {
            var graph = new Graph(_m0);

            // Base graph (complete graph)
            for (int i = 0; i < graph.NodeList.Count; i++)
            {
                for (int j = 0; j < graph.NodeList.Count; j++)
                {
                    if (i == j)
                        continue;
                    graph.NodeList[i].Neighbors.Add(graph.NodeList[j]);
                }
            }

            // Adding new nodes

            for (int i = 0; i < _numberOfNodes; i++)
            {
                var node = new GraphNode(_m0 + 1 + i);
                var usedNodesIds = new List<int>();
                for (int j = 0; j < _m; j++)
                {
                    GraphNode newNeighbor;
                    float randomNumber = (float)_rnd.NextDouble();
                    if (j == 0 || randomNumber > _probability)
                    {
                        int randomIndex = _rnd.Next(graph.NodeList.Count);
                        while (usedNodesIds.Contains(randomIndex))
                        {
                            randomIndex = _rnd.Next(graph.NodeList.Count);
                        }
                        newNeighbor = graph.NodeList[randomIndex];
                        usedNodesIds.Add(randomIndex);
                    }
                    else
                    {
                        int index = _rnd.Next(node.Neighbors[j - 1].Neighbors.Count);
                        while (node.Neighbors.Contains(node.Neighbors[j - 1].Neighbors[index]))
                        {
                            index = _rnd.Next(node.Neighbors[j - 1].Neighbors.Count);
                        }
                        newNeighbor = node.Neighbors[j - 1].Neighbors[index];
                        usedNodesIds.Add(node.Neighbors[j - 1].Neighbors[index].Id - 1);
                    }

                    node.Neighbors.Add(newNeighbor);
                    newNeighbor.Neighbors.Add(node);
                }

                graph.NodeList.Add(node);
            }

            return graph;
        }

        public Graph generateER(float probability)
        {
            var graph = new Graph(_numberOfNodes + _m0);

            for (int i = 0; i < graph.NodeList.Count; i++)
            {
                for (int j = i + 1; j < graph.NodeList.Count; j++)
                {
                    if (i != j && !graph.NodeList[i].Neighbors.Contains(graph.NodeList[j]))
                    {
                        if (_rnd.NextDouble() < probability)
                        {
                            graph.NodeList[i].Neighbors.Add(graph.NodeList[j]);
                            graph.NodeList[j].Neighbors.Add(graph.NodeList[i]);
                        }
                    }
                }
            }

            return graph;
        }
    }
}
