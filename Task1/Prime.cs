using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    public static class Prime
    {
        public static bool HasNonPrimeNumberSequential(int[] array)
        {

            foreach(int i in array)
            {
               // Console.WriteLine(i +" " +IsPrime(i).ToString());
                if (!IsPrime(i)) return true;

            }
            return false;
        }


        public static bool IsPrime(int num)
        {
            if (num <= 1) return false;

            for (int i = 2;i<= num/2; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }



        public static bool HasNonPrimeNumberMultiThread(int[] array, byte threadCount = 1)
        {
            if (threadCount < 1) throw new Exception("ThreadCount can't be less than 1");
            if (threadCount == 1) return HasNonPrimeNumberSequential(array);
            bool rezult = false;
            //Thread[] threads = new Thread[threadCount];
            //for (int i = 0; i < threadCount; i++)
            //{
            //    threads[i] = new Thread((num) =>
            //    {
            //        if (!IsPrime((int)num)) rezult = true;
            //        rezult = false;
            //    });
            //}

            for (int i = 0; i < array.Length; i ++)
            {
                ThreadPool.QueueUserWorkItem((stateInfo) =>
                {
                    if (!IsPrime(i)) rezult = true;
                });
                if (rezult) return true;
            }


            if (rezult) return true;
            return false;
        }
        public static bool HasNonPrimeNumberParallel(int[] array)
        {
            ParallelLoopResult result = Parallel.ForEach<int>(array, (num, pls) =>
            {
                if (!IsPrime(num))
                {
                    pls.Break();
                }
            });
            if (!result.IsCompleted)
                return true;
            return false;
        }
    }
}
