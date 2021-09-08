
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace HomeWork_Threading_
{
    public class JobExecutor : IJobExecutor
    {
        // создаем семафор
        static Semaphore sem = new Semaphore(3, 3);
        Thread myThread;
        int Amount { get; set; } = 3;

        int IJobExecutor.Amount => throw new NotImplementedException();

        //int IJobExecutor.Amount => throw new NotImplementedException();

        public JobExecutor(int number)
        {
            myThread = new Thread(Start);
            myThread.Name = $"Задача {number.ToString()}";
            myThread.Start();
        }
        public void Start(object maxConcurent)
        {
            while (Amount > 0)
            {
                sem.WaitOne();

                Console.WriteLine($"{Thread.CurrentThread.Name} Добавлена в очередь");

                Console.WriteLine($"{Thread.CurrentThread.Name} Выполняется");

                Amount--;
                Thread.Sleep(1000);
            }
        }

        public void Stop()
        {
            sem.Close();
            Console.WriteLine($"{Thread.CurrentThread.Name} остановлена");
        }
        public void Add(Action action)
        {
            Amount++;
            while (Amount > 0)
            {
                sem.WaitOne();

                Console.WriteLine($"новая {Thread.CurrentThread.Name} Добавлена в очередь");

                Console.WriteLine($"{Thread.CurrentThread.Name} Выполняется");

                Amount--;
                Thread.Sleep(1000);
            }

        }

        public void Clear()
        {
            sem.Release();
        }
    }
}