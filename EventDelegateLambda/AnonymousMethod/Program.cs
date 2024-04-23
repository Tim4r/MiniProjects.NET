namespace AnonymousMethod;

internal class Program
{
    public delegate void Kinsasa();

    public delegate void AbraCadabra(string abra);

    delegate void MessageHandler(string message);

    delegate void MessageHandler2(int num);

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
    }

    static void ShowMessage(int number, MessageHandler2 handler2)
    {
        handler2(number);
    }
}