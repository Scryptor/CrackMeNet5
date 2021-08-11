using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    class Program
    {
        internal static int nfmV;
        internal static string allPwd;
        static void Main(string[] args)
        {
            Console.WriteLine(0x1a8_357e);
            nfmV = smethod_1(Environment.Version.ToString(), 0);
            Console.WriteLine("Начат парсинг подходящих паролей");
            Stopwatch stw = new Stopwatch();
            stw.Start();
            Parallel.For(10000000, 99999999, smethod_0);
            stw.Stop();
            Console.WriteLine($"Закончено за: {stw.ElapsedMilliseconds / 1000.0} сек.");

            using (StreamWriter sw = new StreamWriter("paswds.txt"))
            {
                sw.Write(allPwd);
            }
            Console.ReadLine();
        }
        private static void smethod_0(int x, ParallelLoopState pls)
        {
            int num = x;

            int x1 = Math.DivRem(num, 10000000, out num);
            if (num % x1 != 0) return;

            int x2 = Math.DivRem(num, 1000000, out num);
            if (x2 == 0) return;
            int x3 = Math.DivRem(num, 100000, out num);
            int x4 = Math.DivRem(num, 10000, out num);
            int x5 = Math.DivRem(num, 1000, out num);
            int x6 = Math.DivRem(num, 100, out num);
            if (x3 + x6 != x2) return;

            int x7 = Math.DivRem(num, 10, out num);
            if (x7 - x6 != nfmV) return;
            int x8 = num;
            if (x4 * x8 % 2 != 0) return;

            allPwd += $"{x}\n";
        }
        private static int smethod_1(string string_0, int int_0) => int.Parse(string_0.Substring(int_0, 1));
    }
}
