namespace DISecondExample;

internal class Spatula : ITools
{
    public string Name { get; set; }
    public void UseMe()
    {
        Console.WriteLine($"The {Name} started to make a little rattle!");
    }
}
