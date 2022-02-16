using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using Task1;

namespace TestProject
{
    internal static class Program
    {

        private static void DisplayArray(int[] array)
        {
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmark>();

        }
    }
}
