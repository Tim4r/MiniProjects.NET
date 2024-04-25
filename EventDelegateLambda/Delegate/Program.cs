namespace Delegates;

internal class Program
{
    delegate void MessageHandler2(int num);
    static void Main()
    {
        ShowMessage(Convert.ToInt32(Console.ReadLine()), new(KyKaReKy));
    }

    // Passing a delegate as a parameter
    static void ShowMessage(int number, MessageHandler2 handler2)
    {
        handler2(number);
    }

    static void KyKaReKy(int num)
    {
        Console.WriteLine(num * 2);
        Console.WriteLine("You are a hero!");
    }
}