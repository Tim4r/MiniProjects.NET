using System.Globalization;
using Todoist.Controllers;

namespace Todoist
{
    internal class Program
    {
        public delegate bool FilterDelegate(Person p);
        static void Main(string[] args)
        {
            Person person1 = new Person() { Name = "Denis", Age = 18 };
            Person person2 = new Person() { Name = "Kirill", Age = 11 };
            Person person3 = new Person() { Name = "Stas", Age = 71 };
            Person person4 = new Person() { Name = "Ruslan", Age = 27 };

            List<Person> people = new List<Person> { person1, person2, person3, person4 };

            static void DisplayPeople(string title, List<Person> people, FilterDelegate filter)
            {
                Console.WriteLine(title);

                foreach (Person item in people) 
                { 
                    if (filter (item))
                        Console.WriteLine("{0}, {1} years old", item.Name, item.Age);
                }
            }

            static bool IsMinor(Person p)
            {
                return p.Age < 18;
            }

            static bool IsAdult(Person p)
            {
                return (p.Age >= 18);
            }

            static bool IsSenior(Person p)
            {
                return p.Age >= 65;
            }

            DisplayPeople("\nKids:", people, IsMinor);
            DisplayPeople("\nAdults:", people, IsAdult);
            DisplayPeople("\nSeniors:", people, IsSenior);
            DisplayPeople("\nMoThenTwentyYearsOldPeople:", people, (Person p) => p.Age > 20);

            ControllerConsole.StartedApplication();
        }
    }
}