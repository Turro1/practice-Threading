using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace HomeWork_Threading_
{
    public class JobExecutor //: IJobExecutor
    {
        // создаем семафор
        static Semaphore sem = new Semaphore(3, 3);
        Thread myThread;
        int count = 3;// счетчик чтения

        public JobExecutor(int number)
        {
            myThread = new Thread(Start);
            myThread.Name = $"Задача {number.ToString()}";
            myThread.Start();
        }
        public void Start(object maxCurrent)
        {
            while (count > 0)
            {
                sem.WaitOne();

                Console.WriteLine($"{Thread.CurrentThread.Name} Добавлена в очередь");

                Add();

                Stop();
                Clear();

                count--;
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
    }
}
