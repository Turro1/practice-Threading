using System;
using System.Threading;
using System.Diagnostics;

namespace HomeWork_Threading_
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                // Задача 1
                Console.WriteLine("Задача №1");
                Stopwatch stopwatch = new Stopwatch(); 
                Stopwatch stopwatch2 = new Stopwatch();
                var random = new Random();
                int count = 100_000_000;
                
                long sum = 0;
                var numbers = new int[count];
                stopwatch.Start();
                for (int i = 0; i < count; i++)
                {
                    numbers[i] = random.Next(0, 100_000);
                    sum += numbers[i];
                }

                long amount = sum / count;
                stopwatch.Stop();
                Console.WriteLine(amount);


                long parallelSum = 0;
                var parallelNumbers = new int[count];
                object locker = new object();
                stopwatch2.Start();
                ThreadPool.QueueUserWorkItem(_ =>
                {
                    lock (locker)
                    {
                        
                        for (int i = 0; i < count; i++)
                        {
                            parallelNumbers[i] = random.Next(0, 100_000);
                            parallelSum += parallelNumbers[i];
                        }
                        long parallelAmount = parallelSum / count;
                        
                        Console.WriteLine(parallelAmount);
                        
                    }
                    
                });
                stopwatch2.Stop();

                Console.WriteLine($"Время вычисления среднего арифметического в основном потоке: {stopwatch.ElapsedTicks / 1000}");
                Console.WriteLine($"Время вычисления среднего арифметического в паралельном потоке: {stopwatch2.ElapsedTicks / 1000}");
                //Задача 2
                Console.WriteLine("Задача №2");
                for (int i = 1; i < 6; i++)
                {
                    JobExecutor jobExecutor = new JobExecutor(i);
                }


                Console.ReadKey();
            }
        }
    }
}


