using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using Task1;

namespace TestProject
{
    internal static class Program
    {
        private static List<int[]> moks = new List<int[]>()
        {
            //new int[] { 1, 2,3,4,5,6,7,8,9},
            //new int[] { 0,1,4,6},
            //new int[] { -1,0,1,4,6},
            //new int[] {2,3,5,7,11,13},
            new int[] { 27644437, 27644437, 27644437, 27644437, 27644437, 27644437,
                27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437,
                27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437,
                27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437,
                27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437,
                27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437,
                27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 
                27644437, 27644437, 27644437, 27644437, 1 },
        };

        static void Main(string[] args)
        {
            //BenchmarkRunner.Run<Benchmark>();
            var start = DateTime.Now;
            foreach (var mok in moks)
            {
                Prime.HasNonPrimeNumberMultiThread(mok, 4);
               
            }
            var end = DateTime.Now;
            Console.WriteLine((end - start));
            start = DateTime.Now;
            foreach (var mok in moks)
            {
                Prime.HasNonPrimeNumberMultiThread(mok, 8);
            }
            end = DateTime.Now;
            Console.WriteLine((end - start));
            start = DateTime.Now;
            foreach (var mok in moks)
            {
                Prime.HasNonPrimeNumberMultiThread(mok, 12);

            }
            end = DateTime.Now;
            Console.WriteLine((end - start));

            start = DateTime.Now;
            foreach (var mok in moks)
            {
                Prime.HasNonPrimeNumberMultiThread(mok, 16);

            }
            end = DateTime.Now;
            Console.WriteLine((end - start));
            start = DateTime.Now;
            foreach (var mok in moks)
            {
                Prime.HasNonPrimeNumberMultiThread(mok, 20);

            }
            end = DateTime.Now;
            Console.WriteLine((end - start));
            start = DateTime.Now;
            foreach (var mok in moks)
            {
                Prime.HasNonPrimeNumberMultiThread(mok, 24);

            }
            end = DateTime.Now;
            Console.WriteLine((end - start));
            start = DateTime.Now;
            foreach (var mok in moks)
            {
                Prime.HasNonPrimeNumberMultiThread(mok, 28);

            }
            end = DateTime.Now;
            Console.WriteLine((end - start));
            start = DateTime.Now;
            foreach (var mok in moks)
            {
                Prime.HasNonPrimeNumberMultiThread(mok, 32);

            }
            end = DateTime.Now;
            Console.WriteLine((end - start));
            start = DateTime.Now;
            foreach (var mok in moks)
            {
                Prime.HasNonPrimeNumberMultiThread(mok, 36);

            }
            end = DateTime.Now;
            Console.WriteLine((end - start));
            start = DateTime.Now;
            foreach (var mok in moks)
            {
                Prime.HasNonPrimeNumberMultiThread(mok, 40);

            }
            end = DateTime.Now;
            Console.WriteLine((end - start));
        }
    }
}
