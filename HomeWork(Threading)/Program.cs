using System;
using System.Threading;

namespace HomeWork_Threading_
{
    class Program
    {
        static void Main(string[] args)
        {
            var randomizer = new Random();
            int count = 10000000;

            long consecutivelSum = 0;
            var consecutiveNumbers = new int[count];

            // Последовательное заполнение и среднее арифметическое для массива с count элементов
            for (int i = 0; i < count; i++)
            {
                consecutiveNumbers[i] = randomizer.Next(0, 100000);
                consecutivelSum += consecutiveNumbers[i];
            }

            long consecutiveAmount = consecutivelSum / count;
            Console.WriteLine(consecutiveAmount);

            // Параллельное заполнение и вычисления среднего арифметического для массива с count элементов
            long parallelSum = 0;
            var parallelNumbers = new int[count];
            object locker = new object();

            ThreadPool.QueueUserWorkItem(_ =>
            {
                lock (locker)
                {
                    for (int i = 0; i < count; i++)
                    {
                        parallelNumbers[i] = randomizer.Next(0, 100000);
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

