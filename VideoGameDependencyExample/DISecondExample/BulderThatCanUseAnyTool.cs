namespace DISecondExample;

internal class BulderThatCanUseAnyTool : IBuilder
{
    public string Name { get; set; }
    ITools tool { get; set; }
    public BulderThatCanUseAnyTool(ITools tool)
    {
        this.tool = tool;
    }
    public void SetBrick()
    {
        Console.WriteLine($"{Name} deftly picked up the instrument");
        tool.UseMe();
        Console.WriteLine("The brick is set!");
    }
}
