using Microsoft.Extensions.DependencyInjection;

namespace VideoGameDependencyExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HeroThatOnlyUsesSwords hero1 = new HeroThatOnlyUsesSwords() { Name = "Ultraman"};
            hero1.Attack();
            Console.WriteLine();

            //HeroThatCanUseAnyWeapon hero2 = new HeroThatCanUseAnyWeapon(new Sword { SwordName = "Brisinger" }) { Name = "Eregon" };    --------- with using constructor
            HeroThatCanUseAnyWeapon hero2 = new HeroThatCanUseAnyWeapon() { Name = "Eregon", MyWeapon = new Sword { SwordName = "Brisinger" } };
            hero2.Attack();
            Console.WriteLine();

            HeroThatCanUseAnyWeapon hero3 = new HeroThatCanUseAnyWeapon() { Name = "Joker", MyWeapon = new Granade { Name = "The Pineapple" } };
            hero3.Attack();
            Console.WriteLine();

            HeroThatCanUseAnyWeapon hero4 = new HeroThatCanUseAnyWeapon() 
            { 
                Name = "Viktor", 
                MyWeapon = new Gun()
                { 
                    Name = "Digle", 
                    Bullets = new List<Bullet>()
                    { 
                        new Bullet { Name = "Silver Slug", GramsOfPowder = 10 },
                        new Bullet { Name = "Lead ball", GramsOfPowder = 20 },
                        new Bullet { Name = "Rusty Nail", GramsOfPowder = 3 },
                        new Bullet { Name = "Hollow Point", GramsOfPowder = 10 }
                    } 
                } 
            };
            hero4.Attack();
            hero4.Attack();
            hero4.Attack();
            hero4.Attack();
            hero4.Attack();
            hero4.Attack();
            hero4.Attack();
            Console.WriteLine();

            // configuration file 
            // in asp.net this section usually sits in a separate config file like startup.cs 
            // we will notify the contents of this startup section

            // servicecollection is the "container" of all registread dependencies
            ServiceCollection services = new ServiceCollection();

            // all new weapons will now be set to granades by default
            //services.AddTransient<IWeapon, Granade>(granade => new Granade { Name = "Exploding Pen" });     ------ some variant
            services.AddTransient<IWeapon, Sword>(sword => new Sword { SwordName = "The Sword of Gryffendor" });

            // all new heroes will be "Jonny" by default
            services.AddTransient<IHero, HeroThatCanUseAnyWeapon>(hero => new HeroThatCanUseAnyWeapon { Name = "Jonny English", MyWeapon = hero.GetService<IWeapon>() });
            // a "compile" step to assemble everything defined above
            ServiceProvider provider = services.BuildServiceProvider();

            // implement
            var hero5 = provider.GetService<IHero>(); 

            // test
            hero5.Attack();
            Console.WriteLine();
        }
    }
}