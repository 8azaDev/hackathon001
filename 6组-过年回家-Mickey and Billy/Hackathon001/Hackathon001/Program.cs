using Hackathon001.Dijkstra;
using System;

namespace Hackathon001
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Graph graph = new Graph();

            try
            {
                graph.Init();
                RoutePlanner planner = new RoutePlanner();
                RoutePlanResult result = planner.Paln(graph.NodeList, "0", (graph.NodeList.Count - 1).ToString());
                Console.WriteLine(result.Value);
            }
            catch (Exception e)
            {
                Console.WriteLine("输入有错");
            }
            Console.ReadLine();
        }
    }
}
