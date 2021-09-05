using System;
using System.Threading;

namespace HomeWork_Threading_
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                // Задача 1
                Console.WriteLine("Задача №1");
                var random = new Random();
                int count = 100_000_000;

                long sum = 0;
                var numbers = new int[count];

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
                //Задача 2
                Console.WriteLine("Задача №2");
                for (int i = 1; i < 6; i++)
                {
                    JobExecutor reader = new JobExecutor(i);
                }


                Console.ReadKey();
            }
        }
    }
}


