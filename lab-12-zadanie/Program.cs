using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace lab_11
{
    class Edge : IComparable<Edge>
    {
        public int Source { get; set; }
        public int Destination { get; set; }
        public double Weight { get; set; }

        public Edge(int Source, int Destination, double weight)
        {
            this.Source = Source;
            this.Destination = Destination;
            Weight = weight;
        }
        public Edge() { }

        public int CompareTo(Edge other)
        {
            return Weight.CompareTo(other.Weight);
        }
    }
    class Graph
    {
        public Dictionary<int, List<Edge>> Edges = new Dictionary<int, List<Edge>>();

        public void AddDirectedEdge(int source, int destination, double weight)
        {
            if (!Edges.ContainsKey(source))
            {
                Edges.Add(source, new List<Edge>());
            }
            if (!Edges.ContainsKey(destination))
            {
                Edges.Add(destination, new List<Edge>());
            }
            Edges[source].Add(new Edge() { Source = source, Destination = destination, Weight = weight });
        }

        public void AddUndirectedEdge(int source, int destination, double weight)
        {
            AddDirectedEdge(source, destination, weight);
            AddDirectedEdge(destination, source, weight);
        }
        public void AddUndirectedEdge(Edge edge)
        {
            AddDirectedEdge(edge.Source, edge.Destination, edge.Weight);
            AddDirectedEdge(edge.Destination, edge.Source, edge.Weight);
        }


        public void BFTraversal(int start, Action<int> action)
        {
            Queue<int> queue = new Queue<int>();
            ISet<int> visited = new HashSet<int>();
            queue.Enqueue(start);
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                if (visited.Contains(node))
                {
                    continue;
                }
                action.Invoke(node);
                visited.Add(node);
                List<Edge> children = Edges[node];
                foreach (Edge child in children)
                {
                    queue.Enqueue(child.Destination);
                }
            }
        }

        public class Kruskal
        {
            public Graph Result { get; set; }
            public Kruskal(Graph graph)
            {
                Result = new Graph();
                List<Edge> edgesSortedByWeight = new();

                foreach (List<Edge> edgeList in graph.Edges.Values)
                    foreach (Edge edge in edgeList)
                        edgesSortedByWeight.Add(edge);
                edgesSortedByWeight.Sort((x, y) => { return x.Weight.CompareTo(y.Weight); });

                ISet<int> pointsWithPathToIt = new HashSet<int>();

                foreach (Edge edge in edgesSortedByWeight)
                {
                    if (!pointsWithPathToIt.Contains(edge.Source) || !pointsWithPathToIt.Contains(edge.Destination))
                    {
                        pointsWithPathToIt.Add(edge.Source);
                        pointsWithPathToIt.Add(edge.Destination);
                        Result.AddUndirectedEdge(edge);
                    }
                }
            }

            private int[] GetAllPoints(Graph graph)
            {
                int[] returnArray = new int[graph.Edges.Keys.Count()];
                for (int i = 0; i < graph.Edges.Keys.Count(); i++)
                {
                    returnArray[i] = graph.Edges.Keys.ElementAt(i);
                }
                return returnArray;
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.AddDirectedEdge(1, 2, 3);
            graph.AddDirectedEdge(1, 3, 2);
            graph.AddDirectedEdge(1, 4, 6);
            graph.AddDirectedEdge(2, 5, 3);
            graph.AddDirectedEdge(3, 6, 7);
            graph.AddDirectedEdge(4, 6, 5);
            graph.AddDirectedEdge(5, 6, 8);
            graph.BFTraversal(1, n => Console.Write(n + " "));

            Console.WriteLine("\n");

            Graph.Kruskal kruskal = new(graph);
            kruskal.Result.BFTraversal(1, node => Console.Write(node + " "));
        }
    }
}
