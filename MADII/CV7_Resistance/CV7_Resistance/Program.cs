using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CV7_Resistance
{
    class Program
    {
        static void Main(string[] args)
        {
            const int numberOfNodes = 500;
            const double betta = 0.2;
            const double recoveryTime = 2;
            const int time = 20;

            var rand = new Random();

            var g = new Graph(numberOfNodes);

            var dl = new DataLoader();
            dl.LoadData(g, "Data/BA_model.txt");
            //dl.LoadData(g, "Data/ER_model.txt");
            //dl.LoadData(g, "Data/US_Airport_model.txt");


            var susceptable = new Graph(g);
            var infected = new Graph();
            var recovered = new Graph();

            MoveNode(0, susceptable, infected);
            PrintSirModel(susceptable, infected, recovered,-1);

            for (int i = 0; i < time; i++)
            {
                var stoi = new HashSet<int>();
                var itor = new HashSet<int>();
                foreach (var graphNode in infected.NodeList)
                {
                    foreach (var neighbor in graphNode.Neighbors)
                    {
                        if (rand.NextDouble() < betta)
                        {
                            stoi.Add(neighbor.Id);
                        }
                    }

                    graphNode.RecoveryTime++;
                    if (graphNode.RecoveryTime >= recoveryTime)
                    {
                        itor.Add(graphNode.Id);
                    }
                }

                foreach (int id in stoi)
                {
                    MoveNode(id, susceptable, infected);
                }

                foreach (int id in itor)
                {
                    MoveNode(id, infected, recovered);
                }

                PrintSirModel(susceptable, infected, recovered, i + 1);
                if(infected.NodeList.Count < 1) break;
            }
        }

        private static void MoveNode(int nodeId, Graph source, Graph destination)
        {
            GraphNode node = source.GetNodeById(nodeId);
            if (node != null)
            {
                destination.NodeList.Add(node);
                source.NodeList.Remove(node);
            }
        }

        private static void PrintSirModel(Graph susceptable, Graph infected, Graph recovered, int iteration)
        {
            Console.WriteLine($"########### Iteration: {iteration} ##########");
            Console.WriteLine("Susceptable nodes:");
            foreach (var node in susceptable.NodeList)
            {
                Console.Write($"[{node.Id}] ");
            }
            Console.WriteLine();
            Console.WriteLine("Infected nodes:");
            foreach (var node in infected.NodeList)
            {
                Console.Write($"[{node.Id}] ");
            }
            Console.WriteLine();
            Console.WriteLine("Recovered nodes:");
            foreach (var node in recovered.NodeList)
            {
                Console.Write($"[{node.Id}] ");
            }
            Console.WriteLine("\n");
        }
    }
}
