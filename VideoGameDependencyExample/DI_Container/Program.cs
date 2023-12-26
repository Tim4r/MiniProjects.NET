using Microsoft.Extensions.DependencyInjection;

namespace DI_Container
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var person1 = new Person() { Name = "Anatoly", Glad = new Cat() { Name = "Radik" } };
            person1.MoveToTheVisibilityZone();
            Console.WriteLine();

            var person2 = new Person() { Name = "Nikola", Glad = new Dog() { Name = "Reks" } };
            person2.MoveToTheVisibilityZone();
            Console.WriteLine();  
            
            /////////////////////////////////////////////////////////////////////////////////////////////
            
            ServiceCollection services = new ServiceCollection();

            services.AddTransient<IGlad, Cat>(cat => new Cat() { Name = "Kitty" });
            services.AddTransient<IMovement, Person>(perrson => new Person() { Name = "Rikardo", Glad = perrson.GetService<IGlad>() });

            services.AddTransient<IGlad, Dog>(dog => new Dog() { Name = "Yrgant" });
            services.AddTransient<IMovement, Person>(person => new Person() { Name = "Egor", Glad = person.GetService<IGlad>() });

            ServiceProvider provider = services.BuildServiceProvider();

            var person3 = provider.GetService<IMovement>();
            person3.MoveToTheVisibilityZone();

            var person4 = provider.GetService<IMovement>();
            person4.MoveToTheVisibilityZone();
        }
    }
}