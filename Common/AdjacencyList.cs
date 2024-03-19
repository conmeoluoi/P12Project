using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P12Project.Common
{
    internal class AdjacencyList
    {
        public int n; // number of vertices 
        public int m; // number of edges
        public int[,] data; // adjacency matrix
        public List<int>[] adjList; 

        public bool ReadAdjacencyList(string filename)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + filename;
            if (!File.Exists(path))
            {
                Console.WriteLine("This file does not exist.");
                return false;
            }
            string[] lines = File.ReadAllLines(path);
            n = Int32.Parse(lines[0]);
            m = 1 + ((n - 1) * 2);
            data = new int[n, m];
            for (int i = 0; i < n; ++i)
            {
                string[] tokens = lines[i + 1].Split(new char[]
                { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < tokens.Length; ++j)
                    data[i, j] = Int32.Parse(tokens[j]);
            }
            return true;
        }

        public void ShowAdjacencyList()
        {
            Console.WriteLine(n);
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    Console.Write(data[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public AdjacencyMatrix ConvertToAdjacencyMatrix()
        {
            int[,] adjacencyMatrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 1, count = 0; count < data[i, 0]; j+= 2, count++)
                {
                    adjacencyMatrix[i, data[i, j]] = data[i, j + 1];
                }
            }

            AdjacencyMatrix result = new AdjacencyMatrix();
            result.data = adjacencyMatrix;
            result.n = n;
            return result;
        }

        public void GetAdjList ()
        {
            adjList = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                adjList[i] = new List<int>();
                for (int j = 1, count = 0; count < data[i, 0]; j += 2, count++)
                {
                    adjList[i].Add(data[i, j]);
                }
            }
        }

        public void addEdge(int u, int v)
        {
            adjList[u].Add(v);
            adjList[v].Add(u);
        }

        public void removeEdge(int u, int v)
        {
            adjList[u].Remove(v);
            adjList[v].Remove(u);
        }

        public int DFSCount(int v, bool[] isVisited)
            {
                isVisited[v] = true;
                int count = 1;
                foreach (int i in adjList[v])
                {
                    if (!isVisited[i])
                    {
                        count += DFSCount(i, isVisited);
                    }
                }
                return count;
            }

        bool isValidNextEdge(int u, int v)
        {
            if (adjList[u].Count == 1)
            {
                return true;
            }

            bool[] isVisited = new bool[n];
            int count1 = DFSCount(u, isVisited);
            removeEdge(u, v);
            isVisited = new bool[n];
            int count2 = DFSCount(u, isVisited);
            addEdge(u, v);
            return count1 > count2 ? false : true;
        }

        public void printEulerUtil(int u)
        {
            for (int i = 0; i < adjList[u].Count; i++)
            {
                int v = adjList[u][i];
                if (isValidNextEdge(u, v))
                {
                    Console.Write($"{u} - {v} ");
                    removeEdge(u, v);
                    printEulerUtil(v);
                }
            }
        }

}
}
