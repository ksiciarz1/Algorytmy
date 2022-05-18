using System;
using System.Collections.Generic;

namespace lab_12
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();

            graph.Add(1, 3, 2);
            graph.Add(1, 4, 3);
            graph.Add(2, 5, 5);
            graph.Add(3, 6, 6);
            graph.Add(4, 5, 9);

            graph.BFTraversal(1, node => { Console.WriteLine($"{node} "); });
            // ALGORYTM KLASCARA ALBO DIKSCTRII
        }
    }

    internal class Graph
    {
        public Dictionary<int, List<Edge>> Edges = new Dictionary<int, List<Edge>>();


        public void Add(int source, int destination, double weight = 1)
        {
            if (!Edges.ContainsKey(source))
            {
                Edges.Add(source, new List<Edge>());
            }
            if (!Edges.ContainsKey(destination))
            {
                Edges.Add(destination, new List<Edge>());
            }

            Edges[source].Add(new Edge() { Node = destination, Weight = weight });
            Edges[destination].Add(new Edge() { Node = source, Weight = weight });
        }

        public void AddDirected(int source, int destination, double weight = 1)
        {
            if (!Edges.ContainsKey(source))
            {
                Edges.Add(source, new List<Edge>());
            }
            if (!Edges.ContainsKey(destination))
            {
                Edges.Add(destination, new List<Edge>());
            }

            Edges[source].Add(new Edge() { Node = destination, Weight = weight });
        }

        public void BFTraversal(int start, Action<int> action)
        {
            Queue<int> queue = new Queue<int>();
            ISet<int> visited = new HashSet<int>();

            queue.Enqueue(start);
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                if (!visited.Contains(node))
                {
                    action.Invoke(node);
                    visited.Add(node);
                    List<Edge> children = Edges[node];
                    foreach (Edge child in children)
                    {
                        queue.Enqueue(child.Node);
                        queue.Enqueue(child.Node);
                    }
                }
            }
        }

    }

    internal class Edge : IComparable<Edge>
    {
        public int Node { get; set; }
        public double Weight { get; set; }

        public int CompareTo(Edge other)
        {
            return Weight.CompareTo(other.Weight);
        }
    }
}
