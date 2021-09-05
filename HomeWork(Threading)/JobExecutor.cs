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
        int Amount = 3;

        int IJobExecutor.Amount => throw new NotImplementedException();

        public JobExecutor(int number)
        {
            myThread = new Thread(Start);
            myThread.Name = $"Задача {number.ToString()}";
            myThread.Start();
        }
        public void Start(object maxCurrent)
        {
            while (Amount > 0)
            {
                sem.WaitOne();

                Console.WriteLine($"{Thread.CurrentThread.Name} Добавлена в очередь");

                Add();

                Stop();
                Clear();

                Amount--;
                Thread.Sleep(1000);
            }
        }
    
        public void Stop()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} Выполнена");

            
        }
        public void Add()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} В процессе");
            Thread.Sleep(1000);
            
        }

        public void Clear()
        {
            sem.Release();
        }

        public void Start(int maxCurrent)
        {
            throw new NotImplementedException();
        }

        public void Add(Action action)
        {
            throw new NotImplementedException();
        }
    }
}
