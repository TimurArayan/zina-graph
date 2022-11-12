using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grraph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task4");
            clsGraph graph = new clsGraph(7);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(0, 3);
            graph.AddEdge(1, 0);
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 6);
            graph.AddEdge(2, 0);
            graph.AddEdge(2, 1);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 0);
            graph.AddEdge(3, 4);
            graph.AddEdge(3, 2);
            graph.AddEdge(4, 3);
            graph.AddEdge(4, 5);
            graph.AddEdge(5, 2);
            graph.AddEdge(5, 4);
            graph.AddEdge(6, 1);
            graph.PrintAdjacecnyMatrix();

            Console.WriteLine("BFS стартует с 0:");
            graph.BFS(0);
            Console.WriteLine("DFS стартует с 0:");
            graph.DFS(0);


            Console.ReadKey();

        }
        class clsGraph
        {
            private int Vertices; // количество узлов
            private List<Int32>[] adj; // смежность узлов

            public clsGraph(int v) // вывод матрицы смежности
            {
                Vertices = v;
                adj = new List<Int32>[v];
                for (int i = 0; i < v; i++)
                {
                    adj[i] = new List<Int32>();
                }

            }


            public void AddEdge(int v, int w) // добавляем грань от узла до узла
            {
                adj[v].Add(w);
            }


            public void BFS(int s)
            {
                bool[] visited = new bool[Vertices]; // флаг посещения


                Queue<int> queue = new Queue<int>(); //
                visited[s] = true;
                queue.Enqueue(s);


                while (queue.Count != 0)
                {

                    s = queue.Dequeue();
                    Console.WriteLine("next->" + s);


                    foreach (Int32 next in adj[s])
                    {
                        if (!visited[next])
                        {
                            visited[next] = true;
                            queue.Enqueue(next);
                        }
                    }

                }
            }


            public void DFS(int s)
            {
                bool[] visited = new bool[Vertices]; //проверка на посещение узла


                Stack<int> stack = new Stack<int>();
                visited[s] = true;
                stack.Push(s);

                while (stack.Count != 0)
                {
                    s = stack.Pop();
                    Console.WriteLine("next->" + s);
                    foreach (int i in adj[s])
                    {
                        if (!visited[i])
                        {
                            visited[i] = true;
                            stack.Push(i);
                        }
                    }
                }
            }

            public void PrintAdjacecnyMatrix()
            {
                for (int i = 0; i < Vertices; i++)
                {
                    Console.Write(i + ":[");
                    string s = "";
                    foreach (var k in adj[i])
                    {
                        s = s + (k + ",");
                    }
                    s = s.Substring(0, s.Length - 1);
                    s = s + "]";
                    Console.Write(s);
                    Console.WriteLine();
                }
            }
        }
    }
}
