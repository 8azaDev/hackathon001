using System;
using System.Collections.Generic;

namespace MoveMaze
{
    class Program
    {
        static HashSet<string> _Visited = new HashSet<string>();

        static void Main(string[] args)
        {
            //char[,] map = new char[8, 8]
            //{
            //    { '.', '.' , '.', '.' , '.', '.' , '.', '.'},
            //    { '.', '.' , '.', '.' , '.', '.' , '.', '.'},
            //     { '.', '.' , '.', '.' , '.', '.' , '.', '.'},
            //      { '.', '.' , '.', '.' , '.', '.' , '.', '.'},
            //       { '.', '.' , '.', '.' , '.', '.' , '.', '.'},
            //          { '.', '.' , '.', '.' , '.', '.' , '.', '.'},
            //      { '.', '.' , '.', '.' , '.', '.' , '.', '.'},
            //     { '.', '.' , '.', '.' , '.', '.' , '.', '.'}
            //};

            char[,] map = new char[3, 3]
{
                            { '.', '.' , '.'},
                            { '.', '.', '.' },
                                            { '.', '.', '.' }

            };
            Console.WriteLine(MoveTo(2, 2, map));
        }

        static int MoveTo(int m, int n, char[,] map)
        {
            var maxX = map.GetLength(0);
            var maxY = map.GetLength(1);

            if (m < 0 || m >= maxX || n < 0 || n >= maxY || map[m, n] == '#')
                return 100;

            var key = $"{m},{n}";
            Console.WriteLine(key);
            if (_Visited.Contains(key))
                return 100;

            _Visited.Add(key);

            if (m == 0 && n == 0)
            {
                return 0;
            }


            int minStep1 = m + 1 > maxX ? 100 : MoveTo(m + 1, n, map);
            int minStep2 = n + 1 > maxY ? 100 : MoveTo(m, n + 1, map);
            int minStep3 = n - 1 < 0 ? 100 : MoveTo(m, n - 1, map);
            int minStep4 = m - 1 < 0 ? 100 : MoveTo(m - 1, n, map);
            Console.WriteLine($"{minStep1},{minStep2},{minStep3},{minStep4}");
            int minStep = Math.Min(Math.Min(minStep1, minStep2), Math.Min(minStep3, minStep4)) + 1;


            //if (minStep > (m + 1) * (n + 1))in
            //    return 100;
            return minStep;
        }
    }


}

