using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace HomeWork_Threading_
{
    public class JobExecutor : IJobExecutor
    {
        Thread thread;

        public JobExecutor(int maxCurrent)
        {
            thread = new Thread(new ParameterizedThreadStart(Start));
            thread.Start(maxCurrent);
        }
        public int Amount { get; }

        static Semaphore sem = new Semaphore(3, 3);
        public void Start(int maxCurrent)
        {
            
        }
        public void Stop()
        {
            
        }
        public void Add(Action action)
        {
            action();
        }

        public void Clear()
        {

        }
    }
}
