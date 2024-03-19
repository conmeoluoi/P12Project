using P12Project.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace P12Project.Request5Module
{
    internal class Request5
    {
        public static void SubMain()
        {
            AdjacencyList adjList = new AdjacencyList();
            bool readSuccess = adjList.ReadAdjacencyList("\\Data\\GraphData5c.txt");
            bool isEuler = false;
            bool isSemiEuler = false;
            if (readSuccess) 
            { 
                AdjacencyMatrix adjMatrix = adjList.ConvertToAdjacencyMatrix();
                int[] degreeArray = new int[adjMatrix.n];
                if (adjMatrix.isUndirectedGraph() && adjMatrix.isGraphConnected())
                {
                    for (int i = 0; i < adjMatrix.n; i++)
                    {
                        for (int j = 0; j < adjMatrix.n; j++)
                        {
                            if (adjMatrix.data[i, j] != 0)
                            {
                                degreeArray[i]++;
                            }
                        }
                    }

                    int oddDegreeCount = 0;
                    for (int i = 0; i < adjMatrix.n; i++)
                    {
                        if (degreeArray[i] % 2 != 0)
                        {
                            oddDegreeCount++;
                        }
                    }

                    if (oddDegreeCount == 0)
                    {
                        Console.WriteLine("Do thi Euler.");
                        isEuler = true;
                    }
                    else if (oddDegreeCount == 2)
                    {
                        Console.WriteLine("Do thi nua Euler.");
                        isSemiEuler = true;
                    }
                    else
                    {
                        Console.WriteLine("Do thi khong Euler.");
                    }
                }
                else
                {
                    Console.WriteLine("Do thi khong phai do thi vo huong lien thong.");
                }

                if (isEuler || isSemiEuler)
                {
                    Console.WriteLine("Nhap dinh bat dau: ");
                    int start = int.Parse(Console.ReadLine());
                    if (isSemiEuler)
                    {
                        if (degreeArray[start] % 2 != 0)
                        {
                            Console.WriteLine("Do thi nua Euler co duong di nhu sau: ");
                        }
                        else
                        {
                            Console.WriteLine("Do di nua Euler khong bat dau tu dinh co bac chan.");
                            return;
                        }
                    }
                    if (isEuler)
                    {
                        Console.WriteLine("Do thi Euler co chu trinh nhu sau: ");
                    }

                    adjList.GetAdjList();
                    adjList.printEulerUtil(start);
                }
            }
        }
    }
}


//Console.WriteLine("Nhap dinh bat dau: ");
//int start = int.Parse(Console.ReadLine());
//if (isSemiEuler) 
//{
//    if (degreeArray[start] % 2 == 0)
//    {
//        Console.WriteLine("Do thi nua Euler co duong di nhu sau: ");
//    }
//    else
//    {
//        Console.WriteLine("Do thi nua Euler khong bat dau tu dinh co bac le.");
//        return;
//    }
//}
//if (isEuler)
//{
//    Console.WriteLine("Do thi Euler co chu trinh nhu sau: ");
//}
//Stack<int> stack = new Stack<int>();
//List<int> result = new List<int>();
//stack.Push(start);
//while (stack.Count > 0)
//{
//    int current = stack.Peek();
//    int i;
//    for (i = 0; i < adjMatrix.n; i++)
//    {
//        if (adjMatrix.data[current, i] != 0)
//        {
//            break;
//        }
//    }
//    if (i == adjMatrix.n)
//    {
//        result.Add(current);
//        stack.Pop();
//    }
//    else
//    {
//        stack.Push(i);
//        adjMatrix.data[current, i] = 0;
//        adjMatrix.data[i, current] = 0;
//    }
//}
//result.Reverse();
//foreach (int i in result)
//{
//    Console.Write(i + " ");
//}