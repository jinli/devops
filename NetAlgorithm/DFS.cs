using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreConsole
{
    public class DFS
    {
        private int NumVertice;

        private List<int>[] adj;

        public DFS(int v)
        {
            NumVertice = v;
            adj = new List<int>[v];
            for (int i = 0; i < v; i++)
                adj[i] = new List<int>();
        }

        public void AddEdge(int v, int w)
        {
            adj[v].Add(w);
        }

        public void DFSRecursive(int v, bool[] visited)
        {
            visited[v] = true;
            Console.WriteLine(v + " ");

            var vList = adj[v];
            foreach(var n in vList)
            {
                if (!visited[n])
                    DFSRecursive(n, visited);
            }
        }

        public void Traverse(int start)
        {
            var visited = new bool[NumVertice];
            DFSRecursive(start, visited);
        }
    }
}
