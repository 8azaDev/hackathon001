using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace MoveMaze
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] map = new char[10, 8]
            {
              {'.','#','#','#','#','#','#','#'},
              {'.','.','.','.','.','.','.','.'},
              {'#','#','#','#','#','#','#','.'},
              {'.','.','.','.','.','.','.','.'},
              {'.','#','#','#','#','#','#','#'},
              {'.','.','.','.','.','.','.','.'},
              {'#','#','#','#','#','#','#','.'},
              {'.','.','.','.','.','.','.','.'},
              {'.','#','#','#','#','#','#','.'},
              {'#','#','#','#','#','#','#','.'}
            };
            var maxX = map.GetLength(0);
            var maxY = map.GetLength(1);
            Console.WriteLine(MoveTo(new Point(maxX-1, maxY-1), map));
        }

        static int MoveTo(Point point, char[,] map)
        {
            var maxX = map.GetLength(0);
            var maxY = map.GetLength(1);
            var m = point.X;
            var n = point.Y;
            if (m < 0 || m >= maxX || n < 0 || n >= maxY || map[m, n] == '#' || point.HasViewed())
                return 1000000;

            if (m == 0 && n == 0)
            {
                Console.WriteLine($"路径为：{string.Join(",", point.ViewedKeys)},(0,0)");
                return 0;
            }
            var point1 = new Point(m + 1, n, point);
            int minStep1 = m + 1 >= maxX ? 100 : MoveTo(point1, map);

            var point2 = new Point(m, n + 1, point);
            int minStep2 = n + 1 >= maxY ? 100 : MoveTo(point2, map);

            var point3 = new Point(m, n - 1, point);
            int minStep3 = n - 1 < 0 ? 100 : MoveTo(point3, map);

            var point4 = new Point(m - 1, n, point);
            int minStep4 = m - 1 < 0 ? 100 : MoveTo(point4, map);
            int minStep = minStep1;
            if (minStep > minStep2)
            {
                minStep = minStep2;
            }
            if (minStep > minStep3)
            {
                minStep = minStep3;
            }
            if (minStep > minStep4)
            {
                minStep = minStep4;
            }
            return minStep + 1;
        }
    }

    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point(int x, int y, Point prePoint)
        {
            X = x;
            Y = y;
            ViewedKeys.AddRange(prePoint.ViewedKeys);
            ViewedKeys.Add(prePoint.GetKey());
        }

        public int X { get; set; }

        public int Y { get; set; }

        public List<string> ViewedKeys { get; set; } = new List<string>();

        public string GetKey()
        {
            return $"({X},{Y})";
        }

        public bool HasViewed()
        {
            return ViewedKeys.Contains(GetKey());
        }
    }

}