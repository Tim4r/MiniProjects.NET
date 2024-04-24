namespace AnonymousMethod;

internal class Program
{
    delegate void Kinsasa();

    delegate void AbraCadabra(string abra);

    delegate void MessageHandler(string message);

    delegate void MessageHandler2(int num);

    delegate int OperationPlus(int x, int y);

    delegate int OperationPlusZ(int x, int y);

    static int z = 8;

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
        MessageHandler Handler = Console.WriteLine;
        Handler("AnonymousAndParametersShorter");

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
        Console.WriteLine(result);         // 9

        // Call of an anonymous method that returns the value 'int' using an external variable
        OperationPlusZ PlusZ = delegate (int x, int y)
        {
            return x + y + z;
        };
        int result2 = PlusZ(4, 5);         
        Console.WriteLine(result2);        // 17
    }

    static void ShowMessage(int number, MessageHandler2 handler2)
    {
        handler2(number);
    }
}