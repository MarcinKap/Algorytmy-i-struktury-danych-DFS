using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace DFS
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Załaduj listę sąsiedztwa*/
            String[] lines = File.ReadAllLines("graf.txt");

            /* Przekonwertuj listę sąsiedztwa na macierz sąsiedztwa*/
            int nodeCount = Int32.Parse(lines[0]);
            int[,] adjacencyMatrix = new int[nodeCount, nodeCount];
            bool[] visited = new bool[nodeCount];
            for (int i = 1; i < lines.Length; i++)
            {
                String line = lines[i];
                String[] elements = line.Split(" ");

                adjacencyMatrix[Int32.Parse(elements[0]), Int32.Parse(elements[1])] = 1;

            }

            Console.WriteLine("\nMacierz sąsiedztwa");
            String columnHeader = "";
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                columnHeader += "\t" + i;
            }
            Console.WriteLine(columnHeader + "\n");
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                String rowText = i + "";
                for (int j = 0; j < adjacencyMatrix.GetLength(0); j++)
                {
                    rowText += "\t" + adjacencyMatrix[i, j];
                }
                Console.WriteLine(rowText);
            }
            Console.WriteLine("\nPrzechodzenie grafu w głąb:");
            DFS(0);
            void DFS(int v)
            {
                visited[v] = true;
                Console.WriteLine(v);
                for (int i = 0; i < nodeCount; i++)
                {
                    if (adjacencyMatrix[v, i] == 1 && visited[i] == false)
                    {
                        DFS(i);
                    }
                }
            }
        }

    }
}
