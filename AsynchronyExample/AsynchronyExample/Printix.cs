namespace AsynchronyExample;

internal class Printix
{ 
    internal void Print()
    {
        Thread.Sleep(3000);
        Console.WriteLine($"Hello! [{Thread.CurrentThread.ManagedThreadId}]");
    }

    internal async void PrintAsync()
    {
        Console.WriteLine($"Начало работы PrintAsync [{Thread.CurrentThread.ManagedThreadId}]");
        await Task.Run(Print);
        Console.WriteLine($"Конец метода PrintAsync [{Thread.CurrentThread.ManagedThreadId}]");
    }
}
