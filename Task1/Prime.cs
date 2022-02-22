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

        private static bool IsThreadsOnline(Thread[] threads)
        {
            foreach (Thread thread in threads)
            {
                if (thread.ThreadState == ThreadState.Running) return true;
            }
            return false;
        }

        private static void DisplayArray(int[] array)
        {
            Console.WriteLine("lenth " + array.Length);
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
        public static bool HasNonPrimeNumberMultiThread(int[] array, byte threadCount = 1)
        {
            if (threadCount < 1) throw new Exception("ThreadCount can't be less than 1");
            if (threadCount == 1) return HasNonPrimeNumberSequential(array);

            bool result = false;
            var step = array.Length / threadCount;
            var remainder = array.Length % threadCount;

            Thread[] threads = new Thread[threadCount];
            threads[0] = new Thread(() => {
                if (HasNonPrimeNumberSequential(Helper.SubArray(array, 0, step + remainder)))  result = true;
            });
            threads[0].Start();

            for (int i = 1; i < threadCount; i++)
            {
                var newArray = Helper.SubArray(array, i * step + remainder, step);
                threads[i] = new Thread(() => {
                    if (HasNonPrimeNumberSequential(newArray)) result = true;
                });
                threads[i].Start();
            }
            while (IsThreadsOnline(threads))
            {
                
            }
            return result;
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
