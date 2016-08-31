using System;

namespace Monkey
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            n = Convert.ToInt32(Console.ReadLine());
            var total = (Math.Pow(5, n) - 4);
            Console.WriteLine("最少要" + total + "个桃子");
            var lastfen = (Math.Pow(4, n) * (total + 4) / Math.Pow(5, n)) - 4;
            Console.WriteLine(lastfen);
            Console.WriteLine("老猴子最多可以拿" + (n
                + lastfen) + "个桃子");
        }
    }
}
