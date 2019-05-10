using System;

namespace trabalho_np2_grafos
{
    //https://www.geeksforgeeks.org/csharp-program-for-dijkstras-shortest-path-algorithm-greedy-algo-7/
    class Dijkstra
    {

        static int V;
        static int SRC;

        int minDistance(int[] dist,
                        bool[] sptSet)
        {
            // Initialize min value 
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < V; v++)
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }

            return min_index;
        }

        // A utility function to print 
        // the constructed distance array 
        void printSolution(int[] dist, int n)
        {
            int source = SRC + 1;

            for (int i = 0; i < V; i++)
            {
                int indice = i + 1;
                
                if (source == indice) continue;

                Console.WriteLine("{0} -> {1}     {2}", source, indice, dist[i]);
            }
        }

        // Funtion that implements Dijkstra's 
        // single source shortest path algorithm 
        // for a graph represented using adjacency 
        // matrix representation 
        public void Run(int[,] graph, int length,int src)
        {
            src = src - 1;
            V = length;
            SRC = src;

            int[] dist = new int[V]; // The output array. dist[i] 
                                     // will hold the shortest 
                                     // distance from src to i 

            // sptSet[i] will true if vertex 
            // i is included in shortest path 
            // tree or shortest distance from 
            // src to i is finalized 
            bool[] sptSet = new bool[V];

            // Initialize all distances as 
            // INFINITE and stpSet[] as false 
            for (int i = 0; i < V; i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }

            // Distance of source vertex 
            // from itself is always 0 
            dist[src] = 0;

            // Find shortest path for all vertices 
            for (int count = 0; count < V - 1; count++)
            {
                // Pick the minimum distance vertex 
                // from the set of vertices not yet 
                // processed. u is always equal to 
                // src in first iteration. 
                int u = minDistance(dist, sptSet);

                // Mark the picked vertex as processed 
                sptSet[u] = true;

                // Update dist value of the adjacent 
                // vertices of the picked vertex. 
                for (int v = 0; v < V; v++)

                    // Update dist[v] only if is not in 
                    // sptSet, there is an edge from u 
                    // to v, and total weight of path 
                    // from src to v through u is smaller 
                    // than current value of dist[v] 
                    if (!sptSet[v] && graph[u, v] != 0 &&
                         dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                        dist[v] = dist[u] + graph[u, v];
            }

            // print the constructed distance array 
            printSolution(dist, V);
        }
    }
}