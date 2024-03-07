using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P12Project.Common
{
    internal class AdjacencyMatrix
    {
        public int n;
        public int[,] data;


        private bool isUndirectedGraph()
        {
            int i, j;
            bool isSymmetric = true;
            for (i = 0; i < n && isSymmetric; ++i)
            {
                for (j = i + 1; (j < n) && (data[i, j] == data[j, i]); ++j) ;
                if (j < n)
                    isSymmetric = false;
            }
            return isSymmetric;
        }

        private bool isGraphHasNoLoops()
        {
            for (int i = 0; i < n && data[i, i] == 0; i++)
                if (i < n)
                    return false;
            return true;
        }

        public void ShowAdjacencyMatrix()
        {
            Console.WriteLine(n);
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    Console.Write(data[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
