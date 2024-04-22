namespace AnonymousMethod;

internal class Program
{
    public delegate void Kinsasa();

    public delegate void AbraCadabra(string abra);

    static void Main(string[] args)
    {
        Kinsasa Kuplinov = delegate ()
        {
            Console.WriteLine("AnonymousWithoutParameters");
        };
        Kuplinov();

        //////////////////////////////////////////////////////////////////////

        AbraCadabra Lololoshka = delegate (string abra)
        {
            Console.WriteLine(abra);
        };
        Lololoshka("AnonymousAndParameters");
    }
}