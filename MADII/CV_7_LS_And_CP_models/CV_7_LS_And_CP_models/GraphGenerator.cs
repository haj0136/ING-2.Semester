using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_7_LS_And_CP_models
{
    public class GraphGenerator
    {
        private readonly int _m0;
        private readonly int _m;
        private readonly int _numberOfNodes;
        private readonly float _probability;
        private readonly Random _rnd;
        private readonly float _agingParam;


        /// <param name="m0">Number of fundamental nodes.</param>
        /// <param name="m">Number of edges for new created nodes.</param>
        /// <param name="numberOfNodes">Number of added nodes.</param>
        /// <param name="p">Probability</param>
        /// <param name="agingParam"></param>
        public GraphGenerator(int m0, int m, int numberOfNodes, float p, float agingParam)
        {
            _m0 = m0;
            _m = m;
            _numberOfNodes = numberOfNodes;
            _probability = p;
            _rnd = new Random();
            _agingParam = agingParam != 0 ? agingParam : 0.000001f;


        }

        public Graph GenerateCopyingModel()
        {
            var graph = new Graph(_m0);
            var nodeIds = new List<int>();

            // Base graph (complete graph)
            for (int i = 0; i < graph.NodeList.Count; i++)
            {
                for (int j = 0; j < graph.NodeList.Count; j++)
                {
                    if (i == j)
                        continue;
                    graph.NodeList[i].Neighbors.Add(graph.NodeList[j]);
                }

                int actualId = graph.NodeList[i].Id;
                int agingValue = _agingParam < 0? (int)Math.Ceiling(Math.Abs(_agingParam)*(_m0 - actualId + 1)) : (int)Math.Ceiling(actualId * _agingParam);
                GraphUtils.FillIdList(nodeIds, actualId, agingValue);
            }

            for (int i = 0; i < _numberOfNodes - _m0; i++)
            {
                var newNode = new GraphNode(_m0 + 1 + i);
                int randomNode = nodeIds[_rnd.Next(nodeIds.Count)];
                randomNode = graph.NodeList.FindIndex(x => x.Id == randomNode);

                if(_rnd.NextDouble() < _probability)
                {
                    newNode.Neighbors.Add(graph.NodeList[randomNode]);
                    graph.NodeList[randomNode].Neighbors.Add(newNode);
                } else
                {
                    int randomNeighbor = _rnd.Next(graph.NodeList[randomNode].Neighbors.Count);

                    newNode.Neighbors.Add(graph.NodeList[randomNode].Neighbors[randomNeighbor]);
                    graph.NodeList[randomNode].Neighbors[randomNeighbor].Neighbors.Add(newNode);
                }

                int actualId = newNode.Id;
                int agingValue = _agingParam < 0? (int)Math.Ceiling(Math.Abs(_agingParam)*(_m0 - actualId + 1)) : (int)Math.Ceiling(actualId * _agingParam);
                GraphUtils.FillIdList(nodeIds, actualId, agingValue);
                graph.NodeList.Add(newNode);
            }
            

            return graph;
        }

        public Graph GenerateLinkSelectionModel()
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

            for (int i = 0; i < _numberOfNodes - _m0; i++)
            {
                var newNode = new GraphNode(_m0 + 1 + i);
                int randomNode = _rnd.Next(graph.NodeList.Count);
                int randomNeighbor = _rnd.Next(graph.NodeList[randomNode].Neighbors.Count);

                if (_rnd.NextDouble() < 0.5)
                {
                    newNode.Neighbors.Add(graph.NodeList[randomNode]);
                    graph.NodeList[randomNode].Neighbors.Add(newNode);
                }
                else
                {

                    newNode.Neighbors.Add(graph.NodeList[randomNode].Neighbors[randomNeighbor]);
                    graph.NodeList[randomNode].Neighbors[randomNeighbor].Neighbors.Add(newNode);
                }

                graph.NodeList.Add(newNode);
            }


            return graph;
        }
    }
}
