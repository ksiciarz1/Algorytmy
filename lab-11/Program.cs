using System;

namespace lab_11
{
    class Program
    {
        static void Main(string[] args)
        {
            ADGrah adgraph = new(5);

            adgraph.AddEdge(1, 0);
            adgraph.AddEdge(1, 2);

            Console.WriteLine(adgraph);

        }
    }

    class ADGrah : IGraph
    {
        private int[,] _matrix;

        public ADGrah(int matrixLength)
        {
            _matrix = new int[matrixLength, matrixLength];
        }

        public bool AddEdge(int start, int end)
        {
            if (start > 0 || end > 0
                || start < _matrix.GetLength(0) || end < _matrix.GetLength(0))
            {
                _matrix[start, end] = 1;
                _matrix[end, start] = 1;
                return true;
            }
            return false;
        }

        public bool AddEdgdeDirected(int start, int end)
        {
            if (start > 0 || end > 0
                || start < _matrix.GetLength(0) || end < _matrix.GetLength(0))
            {
                _matrix[start, end] = 1;
                return true;
            }
            return false;
        }

        public bool AddEdgeWeighted(int start, int end, int weight)
        {
            if (start > 0 || end > 0
                || start < _matrix.GetLength(0) || end < _matrix.GetLength(0))
            {
                _matrix[start, end] = weight;
                _matrix[end, start] = weight;
                return true;
            }
            return false;
        }

        public bool AddEdgdeDirectedWeighted(int start, int end, int weight)
        {
            if (start > 0 || end > 0
                || start < _matrix.GetLength(0) || end < _matrix.GetLength(0))
            {
                _matrix[start, end] = weight;
                return true;
            }
            return false;
        }

        public bool RemoveEdgde(int start, int end)
        {
            if (start > 0 || end > 0
                || start < _matrix.GetLength(0) || end < _matrix.GetLength(0))
            {
                _matrix[start, end] = 0;
                _matrix[end, start] = 0;
                return true;
            }
            return false;
        }

        public bool RemoveEdgdeDirectional(int start, int end)
        {
            if (start > 0 || end > 0
                || start < _matrix.GetLength(0) || end < _matrix.GetLength(0))
            {
                _matrix[start, end] = 0;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            string returnString = "";

            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(0); j++)
                {
                    returnString += $"{_matrix[i, j]}";
                }
                returnString += "\n";
            }

            return returnString;
        }
    }

    class INGraph : IGraph
    {
        private int[,] _matrix;
        int edge = 0;

        public INGraph(int vertex, int edges)
        {
            _matrix = new int[vertex, edges];
        }

        public bool AddEdge(int start, int end)
        {
            if (start > 0 || start < _matrix.GetLength(0) || edge < _matrix.GetLength(1) || end > 0 || end < _matrix.GetLength(0))
            {
                _matrix[start, edge] = 1;
                _matrix[end, edge] = 1;
                edge++;
                return true;
            }
            return false;
        }

        public bool AddEdgdeDirected(int start, int end)
        {
            if (start > 0 || start < _matrix.GetLength(0) || edge < _matrix.GetLength(1) || end > 0 || end < _matrix.GetLength(0))
            {
                _matrix[start, edge] = 1;
                _matrix[end, edge] = -1;
                edge++;
                return true;
            }
            return false;
        }

        public bool AddEdgeWeighted(int start, int end, int weight)
        {
            if (start > 0 || start < _matrix.GetLength(0) || edge < _matrix.GetLength(1) || end > 0 || end < _matrix.GetLength(0))
            {
                _matrix[start, edge] = weight;
                _matrix[end, edge] = weight;
                edge++;
                return true;
            }
            return false;
        }

        public bool AddEdgdeDirectedWeighted(int start, int end, int weight)
        {
            if (start > 0 || start < _matrix.GetLength(0) || edge < _matrix.GetLength(1) || end > 0 || end < _matrix.GetLength(0))
            {
                _matrix[start, edge] = weight;
                _matrix[end, edge] = -weight;
                edge++;
                return true;
            }
            return false;
        }

        public bool RemoveEdgde(int start, int edge)
        {
            if (start > 0 || start < _matrix.GetLength(0) || edge < _matrix.GetLength(1) || edge > 0 || edge < _matrix.GetLength(0))
            {
                _matrix[start, edge] = 0;
                for (int i = 0; i < _matrix.GetLength(1); i++)
                    _matrix[i, edge] = 0;
                return true;
            }
            return false;
        }

        public bool RemoveEdgdeDirectional(int start, int edge)
        {
            if (start > 0 || edge < _matrix.GetLength(1) || start < _matrix.GetLength(0))
            {
                _matrix[start, edge] = 0;
                return true;
            }
            return false;
        }
    }

    interface IGraph
    {
        bool AddEdge(int start, int end);
        bool AddEdgdeDirected(int start, int end);
        bool AddEdgeWeighted(int start, int end, int weight);
        bool AddEdgdeDirectedWeighted(int start, int end, int weight);
        bool RemoveEdgde(int start, int end);
        bool RemoveEdgdeDirectional(int start, int end);
    }
}
