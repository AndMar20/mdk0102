using System;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Console.WriteLine("Starting multi-threaded computation...");

        int numberOfTasks = 10;
        Task[] tasks = new Task[numberOfTasks];

        for (int i = 0; i < numberOfTasks; i++)
        {
            int taskNumber = i;
            tasks[i] = Task.Run(() => PerformComputation(taskNumber));
        }

        // Ждем завершения всех задач
        Task.WaitAll(tasks);

        Console.WriteLine("All tasks completed.");
    }

    static void PerformComputation(int taskNumber)
    {
        double result = 0;

        // Выполнение ресурсоемкой операции
        for (int i = 0; i < 1_000_000; i++)
        {
            result += Math.Sqrt(i * taskNumber) * Math.Sin(i);
        }

        Console.WriteLine($"Task {taskNumber} completed with result {result}");
    }
}
