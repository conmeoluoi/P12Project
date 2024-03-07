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
            adjacencyList.ReadAdjacencyList("\\Data\\GraphData1.txt");
            adjacencyList.ShowAdjacencyList();

            AdjacencyMatrix adjacencyMatrix = adjacencyList.ConvertToAdjacencyMatrix();
            adjacencyMatrix.ShowAdjacencyMatrix();
        }
    }
}
