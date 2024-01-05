using Microsoft.Extensions.Configuration;

namespace AppsettingJsonAndDIContainer;

internal class Test
{
    private readonly IConfiguration configuration;

    public Test(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public void TestMethod()
    {
        var dataFromJsonFile = configuration.GetSection("Name").Value;
        Console.WriteLine(dataFromJsonFile);
    }
}
