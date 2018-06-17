using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {

        static void Main(string[] args)
        {
            int v;

            System.Console.WriteLine("Enter number of vertexes");
            v = Convert.ToInt32(System.Console.ReadLine());
            int[] TWeight = new int[v];
            int[] Path = new int[v];
            int[,] Graph = new int[v, v];

            System.Console.WriteLine("ENTER EDGES BETWEEN VERTICES");
            int doo = 1; char yorno;
            while (doo != 0)
            {
                addEdge(ref Graph);
                System.Console.WriteLine("DO YOU WANT TO ADD MORE EDGES (y or n) : ");
                yorno = System.Console.ReadKey().KeyChar; System.Console.WriteLine("");
                if (yorno == 'n')
                    doo = 0;
            }


            print(Graph, v);

            List<int> a = new List<int>();
            a = StartingVertex();
            int size = a.Count;
            int initialvertexes = a.Count;
            System.Console.WriteLine(size);

            //viterbi algo
            for (int i = 0; i < size; i++)
                for (int j = 0; j < v; j++)
                {
                    if ((Graph[a[i], j] != 0) && (j != Path[a[i]]) && j != a[i])
                    {
                        if (TWeight[j] == 0)
                        { TWeight[j] = Graph[a[i], j] + TWeight[a[i]]; Path[j] = a[i]; if (!a.Contains(j)) { a.Add(j); size = a.Count; } System.Console.WriteLine("Tweight[j] in equal 0 " + TWeight[j]); }

                        else if (TWeight[j] > Graph[a[i], j] + TWeight[a[i]])
                        { TWeight[j] = Graph[a[i], j] + TWeight[a[i]]; Graph[Path[j], j] = 0; Graph[j, Path[j]] = 0; System.Console.WriteLine("Tweight[j] in equal less" + TWeight[j]); }
                        else if (TWeight[j] < Graph[a[i], j] + TWeight[a[i]])
                        { Graph[a[i], j] = 0; Graph[j, a[i]] = 0; System.Console.WriteLine("Tweight[j] in equal greater" + TWeight[j]); }
                    } System.Console.WriteLine("size: " + size); System.Console.WriteLine("i: " + i); System.Console.WriteLine("a[i]: " + a[i]); System.Console.WriteLine("j: " + j); System.Console.WriteLine("GRAPH[a[i]],j]: " + Graph[a[i], j]);
                }
            //end viterbi algo
            for (int i = 0; i < initialvertexes; i++)
            { TWeight[a[i]] = 0; }

            for (int i = 0; i < v; i++)
            { System.Console.WriteLine(TWeight[i]); }


        }

        static void print(int[,] Graph, int v)
        {
            for (int i = 0; i < v; i++)
            {
                for (int j = 0; j < v; j++)
                { System.Console.WriteLine("i: " + i + " j: " + j + " value: " + Graph[i, j]); }
            }
        }

        static void addEdge(ref int[,] Graph)
        {
            int v1; int v2; int weight;
            System.Console.WriteLine("ENTER VERTEX 1: ");
            v1 = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("ENTER VERTEX 2: ");
            v2 = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("ENTER Weight: ");
            weight = Convert.ToInt32(System.Console.ReadLine());
            Graph[v1, v2] = Graph[v2, v1] = weight;
        }

        static List<int> StartingVertex(int n = 0)
        {

            List<int> startvertex = new List<int>();
            if (n == 0)
            {
                System.Console.WriteLine("ENTER NUMBER OF STARTING VERTEXES");
                n = Convert.ToInt32(System.Console.ReadLine());


                for (int i = 0; i < n; i++)
                {
                    System.Console.WriteLine("ENTER FIRST STARTING VERTEX");
                    startvertex.Add(Convert.ToInt32(System.Console.ReadLine()));
                }

            }
            else
            {
                startvertex.Add(n);
            }


            return startvertex;

        }

    }
}

