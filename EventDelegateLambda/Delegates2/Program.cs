namespace Delegates2;

internal class Program
{
    private delegate bool FilterDelegate(Person p);

    static void Main(string[] args)
    {
        Person person1 = new Person { Name = "Vadim", Age = 17 };
        Person person2 = new Person { Name = "Andrey", Age = 28 };
        Person person3 = new Person { Name = "Denis", Age = 12 };
        Person person4 = new Person { Name = "Alexandr", Age = 74 };
        Person person5 = new Person { Name = "Slava", Age = 43 };

        List<Person> people = new List<Person> { person1, person2, person3, person4, person5 };

        DisplayPeople("\nKids:", people, IsMinor);
        DisplayPeople("\nAdults:", people, IsAdult);
        DisplayPeople("\nSeniors:", people, IsSenior);
    }

    static void DisplayPeople(string title, List<Person> people, FilterDelegate filter) 
    { 
        Console.WriteLine(title);

        foreach (var item in people)
        {
            if (filter(item))
                Console.WriteLine("{0}, {1} years old", item.Name, item.Age);
        }
    }

    static bool IsMinor(Person p) 
    {
        return p.Age < 18;
    }

    static bool IsAdult(Person p)
    {
        return p.Age >= 18 && p.Age <= 65;
    }

    static bool IsSenior(Person p)
    {
        return p.Age > 65;
    }
}