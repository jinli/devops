using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCoreConsole
{
    public class BFS
    {
        private int NumVertice;
        private LinkedList<int>[] adj;

        public BFS(int v)
        {
            adj = new LinkedList<int>[v];
            NumVertice = v;

            for (int i = 0; i < v; i++)
                adj[i] = new LinkedList<int>();
        }

        public void AddEdge(int v, int w)
        {
            adj[v].AddLast(w);
        }

        public void Traverse(int s)
        {
            bool[] visited = new bool[NumVertice];

            var queue = new LinkedList<int>();

            visited[s] = true;
            queue.AddLast(s);

            while (queue.Any())
            {
                int v = queue.First();
                Console.Write(v + " ");
                queue.RemoveFirst();

                var edges = adj[v];
                foreach (var vertex in edges)
                {
                    if (!visited[vertex])
                    {
                        visited[vertex] = true;
                        queue.AddLast(vertex);
                    }
                }
            }
        }
    }
}
