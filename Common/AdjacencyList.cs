using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P12Project.Common
{
    internal class AdjacencyList
    {
        public int n;
        public int m;
        public int[,] data;

        
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
    }
}
