using P12Project.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace P12Project.Request3Module
{
    internal class EDGE
    {
        public int v;
        public int w;
        public int weight;
        public EDGE(int v, int w, int weight)
        {
            this.v = v;
            this.w = w;
            this.weight = weight;
        }
    }
    internal class Request3
    {
        static int Prim(AdjacencyMatrix g, int source)
        {
            int TotalWeight = 0;
            EDGE[] T = new EDGE[g.n - 1];
            int nT = 0;
            bool[] marked = new bool[g.n];
            marked[source] = true;
            while (nT < g.n - 1)
            {
                EDGE edgeMax = new EDGE(-1, -1, -1);
                int nMaxWeight = -1;
                for (int w = 0; w < g.n; w++)
                {
                    if (marked[w])
                    {
                        for (int v = 0; v < g.n; v++)
                        {
                            if (!marked[v] && g.data[w, v] != 0)
                            {
                                if (nMaxWeight == -1 || g.data[w, v] > nMaxWeight)
                                {
                                    nMaxWeight = g.data[w, v];
                                    edgeMax.w = w;
                                    edgeMax.v = v;
                                    edgeMax.weight = nMaxWeight;
                                }
                            }
                        }
                    }
                }
                marked[edgeMax.v] = true;
                T[nT++] = edgeMax;
            }
            foreach (EDGE edge in T)
            {
                Console.WriteLine($"{edge.w}-{edge.v}: {edge.weight}");
                TotalWeight += edge.weight;
            }
            return TotalWeight;
        }

        static int Kruskal(AdjacencyMatrix g)
        {
            int TotalWeight = 0;
            EDGE[] T = new EDGE[g.n - 1];
            int nT = 0;
            int[] label = new int[g.n];
            for (int i = 0; i < g.n; i++)
            {
                label[i] = i;
            }
            EDGE[] lstEdges;
            EDGE[] SortingListEdge(AdjacencyMatrix g)
            {
                
                List<EDGE> listEdge = new List<EDGE>();
                for (int i = 0; i < g.n; i++) { 
                    for (int j = i; j < g.n; j++)
                    {
                        if (g.data[i, j] != 0)
                        {
                            listEdge.Add(new EDGE(i, j, g.data[i, j]));
                        }
                    }
                }
                for (int i = 0; i < listEdge.Count - 1; i++)
                {
                    for (int j = i; j < listEdge.Count - 1; j++)
                    {
                        if (listEdge[i].weight < listEdge[j].weight)
                        {
                            EDGE temp = listEdge[i];
                            listEdge[i] = listEdge[j];
                            listEdge[j] = temp;
                        }
                    }
                }
                return listEdge.ToArray();
            }

            lstEdges = SortingListEdge(g);
            int nEdges = lstEdges.Length;

            bool IsCircle(int idx)
            {
                if (label[lstEdges[idx].v] == label[lstEdges[idx].w])
                { return true; }
                else
                {
                    int lab1 = Math.Min(label[lstEdges[idx].v], label[lstEdges[idx].w]);
                    int lab2 = Math.Max(label[lstEdges[idx].v], label[lstEdges[idx].w]);
                    for (int i = 0; i < g.n; i++)
                    {
                        if (label[i] == lab2)
                        {
                            label[i] = lab1;
                        }
                    }
                }
                return false;
            }
            int indx = 0;
            while (nT < g.n - 1 && indx < lstEdges.Length)
            { EDGE edge = lstEdges[indx];
                if (!IsCircle(indx))
                {
                    T[nT++] = edge;
                }
                indx++;
            }
            foreach (EDGE edge in T)
            {
                Console.WriteLine($"{edge.v}-{edge.w}: {edge.weight}");
                TotalWeight += edge.weight;
            }
            return TotalWeight;
        }
        public static void SubMain()
        {
            AdjacencyList adjacencyListRq3 = new AdjacencyList();
            bool readSuccess = adjacencyListRq3.ReadAdjacencyList("\\Data\\GraphData3.txt");
            if (readSuccess)
            {
                AdjacencyMatrix g = adjacencyListRq3.ConvertToAdjacencyMatrix();
                if (g.isUndirectedGraph() && g.isGraphConnected())
                {
                    Console.WriteLine("Giai thuat Prim");
                    Console.WriteLine("Tap canh cua cay khung");
                    int pw = Prim(g, 0);
                    Console.WriteLine($"Trong so cua cay khung: {pw}");
                    Console.WriteLine("--------------------------------------------------");
                    Console.WriteLine("Kruskal's Algorithm");
                    Console.WriteLine("Tap canh cua cay khung");
                    int kw = Kruskal(g);
                    Console.WriteLine($"Trong so cua cay khung: {kw}");
                }
                else
                {
                    Console.WriteLine("Graph is not connected or not undirected");
                }
            }
        }
    }
}

