using P12Project.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P12Project.Request2Module
{
    internal class Request2
    {
        public static void SubMain()
        {
            AdjacencyList adjacencyList = new AdjacencyList();
            adjacencyList.ReadAdjacencyList("\\Data\\GraphCheckConnected1.txt");
            adjacencyList.ShowAdjacencyList();
             
            AdjacencyMatrix adjacencyMatrix = adjacencyList.ConvertToAdjacencyMatrix();

            adjacencyMatrix.ShowAdjacencyMatrix();

            bool checkStrong = IsStronglyConnected(adjacencyMatrix);
            if (checkStrong)
            {
                Console.WriteLine("Do Thi Lien Thong Manh");
            } else
            {
                Console.WriteLine("Khong phai lien thong manh");
            }
        }

        static List<int> GetVertexAdjacencyList(AdjacencyMatrix matrix, int vertex)
        {
            List<int> result = new List<int>();
            for (int j = 0; j < matrix.n; j++)
            {
                if (matrix.data[vertex, j] > 0)
                {
                    result.Add(j);
                }
            }
            return result;
        }

        static bool CanRoute(AdjacencyMatrix matrix, List<int> visited ,int a, int b)
        {
            visited.Add(a);
            //Step 1
            List<int> vertexs = GetVertexAdjacencyList(matrix, a);
            //Step 2
            for (int i = 0; i < vertexs.Count; i++)
            {
                if (!visited.Contains(vertexs[i]))
                {
                    //success
                    if (vertexs[i] == b)
                        return true;
                    //fail
                    if (vertexs[i] != b)
                        return CanRoute(matrix, visited, vertexs[i], b);
                }
            }
            return false;
        }

        static bool IsStronglyConnected (AdjacencyMatrix matrix)
        {
            for (int i = 0; i < matrix.n; i++)
            {
                for (int j = 0; j < matrix.n; j++)
                {
                    if (i != j)
                    {
                        bool canRoute = CanRoute(matrix, new List<int>(), i, j);
                        if (canRoute == false)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

    }
}
