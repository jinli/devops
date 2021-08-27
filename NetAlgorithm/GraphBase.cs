using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCoreConsole
{
    public abstract class GraphBase
    {
        public readonly int NumVertices;
        public readonly bool Directed;

        public GraphBase(int numVertices, bool directed = false)
        {
            this.NumVertices = numVertices;
            this.Directed = directed;
        }

        public abstract void AddEdge(int v1, int v2, int weight);
        public abstract IEnumerable<int> GetAdjacentVertices(int v);
        public abstract int GetEdgeWeight(int v1, int v2);
        public abstract void Display();
    }

    public class AdjacentMatrixGraph : GraphBase
    {
        protected int[,] Matrix;
        public AdjacentMatrixGraph(int numVertices, bool directed): base(numVertices, directed)
        {
            GenerateEmptyMatrix(numVertices);
        }


        private void GenerateEmptyMatrix(int numVertices)
        {
            Matrix = new int[numVertices, numVertices];

            for (int row = 0; row < numVertices; row++)
                for (int col = 0; col < numVertices; col++)
                {
                    Matrix[row, col] = 0;
                }
        }

        public override void AddEdge(int v1, int v2, int weight)
        {
            if (v1 >= this.NumVertices || v2 >= this.NumVertices || v1 < 0 || v2 < 0)
                throw new ArgumentOutOfRangeException("Vertices are out of bounds");
            if (weight < 1)
                throw new ArgumentOutOfRangeException("Weight cannot be less than 1");

            Matrix[v1, v2] = weight;
            // all edges are bi-directional in undirected graph
            if (!Directed)
                Matrix[v2, v1] = weight;
        }

        public override void Display()
        {
            //throw new NotImplementedException();
        }

        public override IEnumerable<int> GetAdjacentVertices(int v)
        {
            if (v < 0 || v > NumVertices) throw new ArgumentOutOfRangeException("Invalid vertices");

            List<int> adjacentVertices = new List<int>();
            for (int i = 0; i < NumVertices; i++)
                if (Matrix[v, i] > 0)
                    adjacentVertices.Add(i);
            return adjacentVertices;
        }

        public override int GetEdgeWeight(int v1, int v2)
        {
            if (v1 >= this.NumVertices || v2 >= this.NumVertices || v1 < 0 || v2 < 0)
                throw new ArgumentOutOfRangeException("Vertices are out of bounds");

            var st = new HashSet<int>();
            st.ElementAt(0);
            return this.Matrix[v1, v2];
        }
    }
}
