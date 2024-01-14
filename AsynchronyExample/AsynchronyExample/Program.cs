namespace AsynchronyExample;

internal class Program
{
    static void Main(string[] args)
    {
        Printix printix = new Printix();
        printix.PrintAsync();

        Console.WriteLine($"Продолжаем работу в методе Main [{Thread.CurrentThread.ManagedThreadId}]");
        Thread.Sleep(5000);
        Console.WriteLine($"Завершаем работу Main [{Thread.CurrentThread.ManagedThreadId}]");
    }
}