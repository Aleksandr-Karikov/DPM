using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace TestProject
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        private List<int[]> moks = new List<int[]>()
        {
            new int[] { 1, 2,3,4,5,6,7,8,9},
            new int[] { 0,1,4,6},
            new int[] { -1,0,1,4,6},
            new int[] {2,3,5,7,11,13},
            //new int[] { 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 1 },
        };

        [Benchmark]
        public void MultiThread()
        {
            foreach (var mok in moks)
            {
                bool rez = Prime.HasNonPrimeNumberMultiThread(mok,4);
                //Console.WriteLine("MultiThread" + rez);
            }
        }
        [Benchmark]
        public void Sequential()
        {
            foreach (var mok in moks)
            {
                bool rez = Prime.HasNonPrimeNumberSequential(mok);
            }
        }

        [Benchmark]
        public void Parallel()
        {
            foreach (var mok in moks)
            {
                bool rez = Prime.HasNonPrimeNumberParallel(mok);
            }
        }
    }
}
