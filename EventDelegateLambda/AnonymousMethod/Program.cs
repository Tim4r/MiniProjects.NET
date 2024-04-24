namespace AnonymousMethod;

internal class Program
{
    delegate void Kinsasa();

    delegate void AbraCadabra(string abra);

    delegate void MessageHandler(string message);

    delegate void MessageHandler2(int num);

    delegate int OperationPlus(int x, int y);

    static void Main(string[] args)
    {
        // Without parameters
        Kinsasa Kuplinov = delegate ()
        {
            Console.WriteLine("AnonymousWithoutParameters");
        };
        Kuplinov();

        // With string parameter
        AbraCadabra Lololoshka = delegate (string abra)
        {
            Console.WriteLine(abra);
        };
        Lololoshka("AnonymousAndParameters");

        // With string parameter, but shorter
        MessageHandler handler = Console.WriteLine;
        handler("AnonymousAndParametersShorter");

        // Passing an anonymous method as a argument
        ShowMessage(Convert.ToInt32(Console.ReadLine()), delegate (int num)
        {
            Console.WriteLine(num*2);
            Console.WriteLine("You are a hero!");
        });

        // Call of an anonymous method that returns the value 'int'
        OperationPlus Plus = delegate (int x, int y)
        {
            return x + y;
        };
        int result = Plus(4, 5);
        Console.WriteLine(result);
    }

    static void ShowMessage(int number, MessageHandler2 handler2)
    {
        handler2(number);
    }
}