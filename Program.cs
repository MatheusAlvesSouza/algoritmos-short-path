using System;
using System.Diagnostics;

namespace trabalho_np2_grafos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Para um resultado mais exato rode apenas um por vez
            Console.WriteLine("Algoritmo de Floyd Warshall rodou em {0} ms\n", TimeMethod(FloydWarshall));
            Console.WriteLine("Algoritmo de Dijkstra rodou em {0} ms\n", TimeMethod(Dijkstra));
        }

        static long TimeMethod(Action methodToTime)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            methodToTime();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        static void Dijkstra()
        {
            int[,] graph =
                {
                    {0, 0, 2, 0}, // Vertice 1 
                    {4, 0, 3, 0}, // Vertice 2 
                    {0, 0, 0, 2}, // Vertice 3
                    {0, 1, 0, 0} // Vertice 4
                };

            Dijkstra dijkstra = new Dijkstra();

            Console.Write("Par     Distancia\n");
            for (int i = 1; i <= 4; i++)
            {
                dijkstra.Run(graph, 4, i);
            }
        }

        static void FloydWarshall()
        {
            int[,] weights =
                {
                    { 1, 3, 2 }, // Vertice 1
                    { 2, 1, 4 }, // Vertice  2
                    { 2, 3, 3 }, // Vertice  2
                    { 3, 4, 2 }, // Vertice  3
                    { 4, 2, 1 }  // Vertice 4
                };

            FloydWarshall FloydWarshall = new FloydWarshall();

            FloydWarshall.Run(weights, 4);
        }
    }
}