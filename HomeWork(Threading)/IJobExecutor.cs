using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_Threading_
{
    public interface IJobExecutor
    {
        // Кол-во задач в очереди на обработку
        int Amount { get; }

        // Запустить обработку очереди и установить максимальное кол-во параллельных задач
        void Start(object maxConcurent);

        // Остановить обработку очереди и выполнять задачи
        void Stop();

        // Добавить задачу в очередь
        void Add(Action action);

        // Очистить очередь задач
        void Clear();
    }
}