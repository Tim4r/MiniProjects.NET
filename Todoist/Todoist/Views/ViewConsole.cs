using Todoist.Entities;

namespace Todoist.Views
{
    internal static class ViewConsole
    {
        internal static void Display<T>(T message)
        {
            Console.WriteLine(message);
        }

        internal static Func<string> GetInput = Console.ReadLine;

        internal static Func<string> GetEmpty = () => null;
        
        internal static void OutputGoals(List<Goal> tasks)
        {
            for (int i = 0; i < tasks.Count; i++)
                Console.WriteLine($" {i + 1}.{tasks[i]}\n");
        }

        internal static void OutputCategories(List<Category> categories)
        {
            for (int i = 0; i < categories.Count; i++)
                Console.WriteLine($" {i + 1}. {categories[i].NameCategory}");
        }

        internal static void OutputOfAvaliableStatuses(string[] statuses)
        {
            for (int i = 0; i < statuses.Length; i++)
                Console.WriteLine($" {i + 1}. {statuses[i]}");
        }
    }
}
