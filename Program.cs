using System;
using System.Diagnostics;

namespace trabalho_np2_grafos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Para um resultado mais exato rode apenas um por vez
            Console.WriteLine("Algoritmo de Floyd Warshall rodou em {0} ticks\n", TimeMethod(FloydWarshall));
            Console.WriteLine("Algoritmo de Dijkstra rodou em {0} ticks\n", TimeMethod(Dijkstra));
        }

        static long TimeMethod(Action methodToTime)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            methodToTime();
            stopwatch.Stop();
            return stopwatch.ElapsedTicks;
        }

        static void Dijkstra()
        {
            Dijkstra dijkstra = new Dijkstra();

            int[,] grafo_3_completo =
                {
                    {0, 3, 4}, // Vertice 1 
                    {3, 0, 8}, // Vertice 2 
                    {4, 8, 0} // Vertice 3
                };

            int[,] grafo_3_esperso =
                {
                    {0, 3, 0}, // Vertice 1 
                    {3, 0, 4}, // Vertice 2 
                    {0, 4, 0} // Vertice 3
                };

            int[,] grafo_6_completo =
                {
                    {0, 4, 10, 4, 4, 2}, // Vertice 1 
                    {4, 0, 5, 5, 13, 4}, // Vertice 2 
                    {10, 5, 0, 8, 1, 5}, // Vertice 3 
                    {4, 5, 8, 0, 7, 9}, // Vertice 4 
                    {4, 13, 1, 7, 0, 3}, // Vertice 5 
                    {2, 4, 5, 9, 3, 0} // Vertice 6 
                };

            int[,] grafo_6_esperso =
                {
                    {0, 3, 0, 1, 0, 0}, // Vertice 1 
                    {3, 0, 5, 0, 0, 0}, // Vertice 2 
                    {0, 5, 0, 0, 0, 2}, // Vertice 3 
                    {1, 0, 0, 0, 4, 0}, // Vertice 4 
                    {0, 0, 0, 4, 0, 7}, // Vertice 5 
                    {0, 0, 2, 0, 7, 0} // Vertice 6 
                };

            int[,] grafo_8_completo =
                {
                    {0, 5, 6, 7, 3, 2, 8, 4}, // Vertice 1 
                    {5, 0, 7, 8, 3, 7, 9, 2}, // Vertice 2 
                    {6, 7, 0, 2, 1, 4, 6, 5}, // Vertice 3 
                    {7, 8, 2, 0, 5, 8, 21, 13}, // Vertice 4 
                    {3, 3, 1, 5, 0, 3, 8, 4}, // Vertice 5 
                    {2, 7, 4, 8, 3, 0, 8, 23}, // Vertice 6 
                    {8, 9, 6, 21, 8, 8, 0, 12}, // Vertice 7 
                    {4, 2, 5, 13, 4, 23, 12, 0} // Vertice 8
                };

            int[,] grafo_8_esperso =
                {
                    {0, 7, 0, 0, 0, 0, 0, 4}, // Vertice 1 
                    {7, 0, 3, 0, 0, 0, 0, 0}, // Vertice 2 
                    {0, 3, 0, 2, 0, 0, 0, 0}, // Vertice 3 
                    {0, 0, 2, 0, 1, 0, 0, 0}, // Vertice 4 
                    {0, 0, 0, 1, 0, 5, 0, 0}, // Vertice 5 
                    {0, 0, 0, 0, 5, 0, 4, 0}, // Vertice 6 
                    {0, 0, 0, 0, 0, 4, 0, 7}, // Vertice 7 
                    {4, 0, 0, 0, 0, 0, 7, 0} // Vertice 8
                };


            Console.WriteLine("\nGrafo 3 vertices esperso");
            Console.Write("Par     Distancia\n");
            for (int i = 1; i <= 3; i++)
            {
                dijkstra.Run(grafo_3_esperso, 3, i);
            }

            Console.WriteLine("\nGrafo 3 vertices completo");
            Console.Write("Par     Distancia\n");
            for (int i = 1; i <= 3; i++)
            {
                dijkstra.Run(grafo_3_completo, 3, i);
            }

            Console.WriteLine("\nGrafo 6 vertices esperso");
            Console.Write("Par     Distancia\n");
            for (int i = 1; i <= 6; i++)
            {
                dijkstra.Run(grafo_6_esperso, 6, i);
            }

            Console.WriteLine("\nGrafo 6 vertices completo");
            Console.Write("Par     Distancia\n");
            for (int i = 1; i <= 6; i++)
            {
                dijkstra.Run(grafo_6_completo, 6, i);
            }

            Console.WriteLine("\nGrafo 8 vertices esperso");
            Console.Write("Par     Distancia\n");
            for (int i = 1; i <= 8; i++)
            {
                dijkstra.Run(grafo_8_esperso, 8, i);
            }

            Console.WriteLine("\nGrafo 8 vertices completo");
            Console.Write("Par     Distancia\n");
            for (int i = 1; i <= 8; i++)
            {
                dijkstra.Run(grafo_8_completo, 8, i);
            }
        }

        static void FloydWarshall()
        {
            FloydWarshall FloydWarshall = new FloydWarshall();

            int[,] grafo_3_completo =
                {
                    { 1, 3, 4 },
                    { 1, 2, 3 },
                    { 2, 1, 3 },
                    { 2, 3, 8 },
                    { 3, 1, 4 },
                    { 3, 2, 8 }
                };

            int[,] grafo_3_esperso =
                {
                    { 1, 2, 3 },
                    { 2, 1, 3},
                    { 2, 3, 4 },
                    { 3, 2, 4}
                };

            int[,] grafo_6_completo =
                {
                    {1,2,4},
                    {1,3,10},
                    {1,4,4},
                    {1,5,4},
                    {1,6,2},
                    {2,1,4},
                    {2,3,5},
                    {2,4,5},
                    {2,5,13},
                    {2,6,4},
                    {3,1,10},
                    {3,2,5},
                    {3,4,8},
                    {3,5,1},
                    {3,6,5},
                    {4,1,4},
                    {4,2,5},
                    {4,3,8},
                    {4,5,7},
                    {4,6,9},
                    {5,1,4},
                    {5,2,13},
                    {5,3,1},
                    {5,4,7},
                    {5,6,3},
                    {6,1,2},
                    {6,2,4},
                    {6,3,5},
                    {6,4,9},
                    {6,5,3}
                };

            int[,] grafo_6_esperso =
                {
                    {1, 2, 3},
                    {1, 4, 1},
                    {2, 1, 3},
                    {2, 3, 5},
                    {3, 2, 5},
                    {3, 6, 2},
                    {4, 1, 1},
                    {4, 5, 4},
                    {5, 4, 4},
                    {5, 6, 7},
                    {6, 5, 7},
                    {6, 3, 2}
                };

            int[,] grafo_8_esperso =
                {
                    {1, 2, 7},
                    {1, 8, 4},
                    {2, 1, 7},
                    {2, 3, 3},
                    {3, 2, 3},
                    {3, 4, 2},
                    {4, 3, 2},
                    {4, 5, 1},
                    {5, 4, 1},
                    {5, 6, 5},
                    {6, 5, 5},
                    {6, 7, 4},
                    {7, 6, 4},
                    {7, 8, 7},
                    {8, 7, 7},
                    {8, 1, 4},
                };

            
            int[,] grafo_8_completo =
                {
                    {1,2,5},
                    {1,3,6},
                    {1,4,7},
                    {1,5,3},
                    {1,6,2},
                    {1,7,8},
                    {1,8,4},
                    {2,1,5},
                    {2,3,7},
                    {2,4,8},
                    {2,5,3},
                    {2,6,7},
                    {2,7,9},
                    {2,8,2},
                    {3,1,6},
                    {3,2,7},
                    {3,4,2},
                    {3,5,1},
                    {3,6,4},
                    {3,7,6},
                    {3,8,5},
                    {4,1,7},
                    {4,2,8},
                    {4,3,2},
                    {4,5,5},
                    {4,6,8},
                    {4,7,21},
                    {4,8,13},
                    {5,1,3},
                    {5,2,3},
                    {5,3,1},
                    {5,4,5},
                    {5,6,3},
                    {5,7,8},
                    {5,8,4},
                    {6,1,2},
                    {6,2,7},
                    {6,3,4},
                    {6,4,8},
                    {6,5,3},
                    {6,7,8},
                    {6,8,23},
                    {7,1,8},
                    {7,2,9},
                    {7,3,6},
                    {7,4,21},
                    {7,5,8},
                    {7,6,8},
                    {7,8,12},
                    {8,1,4},
                    {8,2,2},
                    {8,3,5},
                    {8,4,13},
                    {8,5,4},
                    {8,6,23},
                    {8,7,12},
                };
                
            Console.WriteLine("\nGrafo 3 vertices esperso");
            FloydWarshall.Run(grafo_3_esperso, 3);

            Console.WriteLine("\nGrafo 3 vertices completo");
            FloydWarshall.Run(grafo_3_completo, 3);

            Console.WriteLine("\nGrafo 6 vertices esperso");
            FloydWarshall.Run(grafo_6_esperso, 6);

            Console.WriteLine("\nGrafo 6 vertices completo");
            FloydWarshall.Run(grafo_6_completo, 6);

            Console.WriteLine("\nGrafo 8 vertices esperso");
            FloydWarshall.Run(grafo_8_esperso, 8);

            Console.WriteLine("\nGrafo 8 vertices completo");
            FloydWarshall.Run(grafo_8_completo, 8);
        }
    }
}