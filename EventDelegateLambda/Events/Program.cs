namespace Events;

delegate void Handler(string alpha, int beta);

internal class Program
{
    static event Handler Stuck;                          //!!! We could remove the keyword "event" and nothing would change

    static void Main(string[] args)
    {
        Stuck += ShowPrice;                             //Registrating method in an Event
        Stuck("Text", 100);
    }

    static void ShowPrice(string alpha, int beta)
    {
        Console.WriteLine($"alpha: {alpha} beta: {beta}");
    }
}