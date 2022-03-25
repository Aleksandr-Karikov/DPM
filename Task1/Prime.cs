using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    public static class Prime
    {
        static Mutex mutexObj = new Mutex();
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
        public static async Task<bool> HasNonPrimeNumberMultiThread(int[] array, byte threadCount = 1)
        {
            if (threadCount < 1) throw new Exception("ThreadCount can't be less than 1");
            if (threadCount == 1) return HasNonPrimeNumberSequential(array);
            Thread[] threads = new Thread[threadCount];
            Result = false;
            queue = new ConcurrentQueue<int>(array);
            for(int i = 0; i < threadCount; i++)
            {
                threads[i] = new Thread(MultyPrime);
                threads[i].Start();
            }

            for (int i = 0; i < threadCount; i++)
            {
                threads[i].Join(); 
            }
            return Result;
        }
        static private bool Result;
        static private ConcurrentQueue<int> queue;
        static private void MultyPrime()
        {
            while (queue.TryDequeue(out int number) && !Result)
            {
                if (!IsPrime(number))
                {
                    Result = true;
                }
            }
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
