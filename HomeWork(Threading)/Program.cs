using System;
using System.Threading;

namespace HomeWork_Threading_
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                var random = new Random();
                int count = 100_000_000;

                long sum = 0;
                var  numbers = new int[count];

                for (int i = 0; i < count; i++)
                {
                    numbers[i] = random.Next(0, 100_000);
                    sum += numbers[i];
                }

                long amount = sum / count;
                Console.WriteLine(amount);


                long parallelSum = 0;
                var parallelNumbers = new int[count];
                object locker = new object();

                ThreadPool.QueueUserWorkItem(_ =>
                {
                    lock (locker)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            parallelNumbers[i] = random.Next(0, 100_000);
                            parallelSum += parallelNumbers[i];
                        }
                    }
                    Thread.Sleep(0);
                });
                ThreadPool.QueueUserWorkItem(_ =>
                {
                    lock (locker)
                    {
                        long parallelAmount = parallelSum / count;
                        Console.WriteLine(parallelAmount);
                    }
                    Thread.Sleep(0);
                });

                Console.ReadKey();
            }
        }
    }
}


