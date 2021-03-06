using System;
using System.Collections.Generic;

namespace trabalho_np2_grafos
{
    class FloydWarshall
    {
        public static void Run(int[,] weights, int numVerticies)
        {
            double[,] dist = new double[numVerticies, numVerticies];
            for (int i = 0; i < numVerticies; i++)
            {
                for (int j = 0; j < numVerticies; j++)
                {
                    dist[i, j] = double.PositiveInfinity;
                }
            }

            for (int i = 0; i < weights.GetLength(0); i++)
            {
                dist[weights[i, 0] - 1, weights[i, 1] - 1] = weights[i, 2];
            }

            int[,] next = new int[numVerticies, numVerticies];
            for (int i = 0; i < numVerticies; i++)
            {
                for (int j = 0; j < numVerticies; j++)
                {
                    if (i != j)
                    {
                        next[i, j] = j + 1;
                    }
                }
            }

            for (int k = 0; k < numVerticies; k++)
            {
                for (int i = 0; i < numVerticies; i++)
                {
                    for (int j = 0; j < numVerticies; j++)
                    {
                        if (dist[i, k] + dist[k, j] < dist[i, j])
                        {
                            dist[i, j] = dist[i, k] + dist[k, j];
                            next[i, j] = next[i, k];
                        }
                    }
                }
            }

            PrintResult(dist, next);
        }

        static void PrintResult(double[,] dist, int[,] next)
        {
            Console.WriteLine("Par     Distancia");
            for (int i = 0; i < next.GetLength(0); i++)
            {
                for (int j = 0; j < next.GetLength(1); j++)
                {
                    if (i != j)
                    {
                        int u = i + 1;
                        int v = j + 1;
                        string path = string.Format("{0} -> {1}    {2,2:G}         ", u, v, dist[i, j]);
                        Console.WriteLine(path);
                    }
                }
            }
        }
    }
}