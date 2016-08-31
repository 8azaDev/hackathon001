using ImVader;
using System;
using System.IO;

namespace hackathon001
{
    class Program
    {
        static void Main(string[] args)
        {
            //从文件输入
            var path = Path.Combine(Directory.GetCurrentDirectory(), "data.txt");
            var g = InputGraphFromFile(path);

            //从控制台输入
            //var g = InputGraphFromConsole();

            var shortestPathList = g.GetShortestPathesList();
            //0-终点的最短路径
            var length = shortestPathList[0, g.VertexCount - 1];
            Console.WriteLine(length);
        }

        public static DirectedListGraph<Vertex<string>, WeightedEdge> InputGraphFromConsole()
        {
            string line1 = Console.ReadLine();
            var edgeCount = Convert.ToInt32(line1.Split(' ')[0]);
            var vertexCount = Convert.ToInt32(line1.Split(' ')[1]);
            DirectedListGraph<Vertex<string>, WeightedEdge> g = new DirectedListGraph<Vertex<string>, WeightedEdge>();
            for (int i = 0; i < vertexCount; i++)
            {
                g.AddVertex(new Vertex<string>(i.ToString()));
            }

            for (var i = 0; i < g.VertexCount; i++)
            {
                var line = Console.ReadLine();
                var parts = line.Split(' ');
                g.AddEdge(new WeightedEdge(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2])));
            }
            return g;
        }

        public static DirectedListGraph<Vertex<string>, WeightedEdge> InputGraphFromFile(string path)
        {
            string[] lines = File.ReadAllLines(path);
            string line1 = lines[0];
            var edgeCount = Convert.ToInt32(line1.Split(' ')[0]);
            var vertexCount = Convert.ToInt32(line1.Split(' ')[1]) + 1;
            DirectedListGraph<Vertex<string>, WeightedEdge> g = new DirectedListGraph<Vertex<string>, WeightedEdge>();
            for (int i = 0; i < vertexCount; i++)
            {
                g.AddVertex(new Vertex<string>(i.ToString()));
            }

            for (var i = 1; i < lines.Length; i++)
            {
                var line = lines[i];
                var parts = line.Split(' ');
                g.AddEdge(new WeightedEdge(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2])));
            }
            return g;
        }
    }
}

