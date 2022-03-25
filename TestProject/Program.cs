using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task1;

namespace TestProject
{
    internal static class Program
    {
        private static List<int[]> moks = new List<int[]>()
        {
            new int[] { 1, 2,3,4,5,6,7,8,9},
            new int[] { 0,1,4,6},
            new int[] { -1,0,1,4,6},
            new int[] {2,3,5,7,11,13},
            new int[] { 27644437, 27644437, 27644437, 27644437, 27644437, 27644437,
                27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437,
                27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437,
                27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437,
                27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437,
                27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437,
                27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 
                27644437, 27644437, 27644437, 27644437, 1 },
        };
        private static async Task MainAsync()
        {
            for (int i = 2; i < 20; i++)
            {
                var start1 = DateTime.Now;
                foreach (var mok in moks)
                {
                    Console.WriteLine(await Prime.HasNonPrimeNumberMultiThread(mok, (byte)i)); 

                }
                var end1 = DateTime.Now;
                Console.WriteLine($"{i} потоков " + (end1 - start1));
            }
            var start = DateTime.Now;
            foreach (var mok in moks)
            {
                Console.WriteLine(Prime.HasNonPrimeNumberParallel(mok));
                

            }
            var end = DateTime.Now;
            Console.WriteLine("paralel " + (end - start));

            start = DateTime.Now;
            foreach (var mok in moks)
            {
                
                Console.WriteLine(Prime.HasNonPrimeNumberSequential(mok));
            }
            end = DateTime.Now;
            Console.WriteLine("seq " + (end - start));
        }
        static void Main(string[] args)
        {
        //BenchmarkRunner.Run<Benchmark>();
             MainAsync().GetAwaiter().GetResult();
        }
    }
}
