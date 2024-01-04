using Microsoft.Extensions.DependencyInjection;

namespace DISecondExample;

internal class Program
{
    static void Main(string[] args)
    {
        ServiceCollection service = new ServiceCollection();
        service.AddTransient<ITools, Spatula>(spatula => new Spatula() {Name = "Kiano"});
        service.AddTransient<IBuilder, BulderThatCanUseAnyTool>(bulder1 => new BulderThatCanUseAnyTool(bulder1.GetService<ITools>()) {Name = "Mikhailovich"});
        ServiceProvider provider = service.BuildServiceProvider();
        var bulder1 = provider.GetService<IBuilder>();

        //BulderThatCanUseAnyTool bulder1 = new BulderThatCanUseAnyTool(new Spatula { Name = "Kiano" }) { Name = "Mikhailovich" };
        bulder1.SetBrick();
    }
}