using Todoist.Controllers;
using Todoist.DataAccess;
using Todoist.Entities;
using Todoist.Enum;

namespace Todoist.Model
{
    internal static class ModelConsole
    {
        internal static List<Goal> SearchElementsByTitleAndDescription(List<Goal> allTasks, string searchWord) 
        {
            List<Goal> results = new List<Goal>();

            foreach (var item in allTasks)
            {
                string[] undiveidedTitle = item.Title.Split(' ');
                string[] undividedDescription = item.Description.Split(' ');

                foreach (string oneWordTitle in undiveidedTitle)
                {
                    if (oneWordTitle == searchWord)
                        results.Add(item);
                }

                foreach (string oneWordDescription in undividedDescription)
                {
                    if (oneWordDescription == searchWord)
                        results.Add(item);
                }
            }

            if (results.Count == 0)
            {
                Console.WriteLine("\n Nothing was found for your request! Please, repeat again...\n");
                ControllerConsole.FindingGoal();
            }

            return results;
        }

        internal static Goal? SearchElementByIndex(List<Goal> allTasks, int menuItem)
        { 
            int count = allTasks.Count;
            for (int i = 0; i < count; i++)
            {
                if (i+1 == menuItem)
                    return allTasks[i];
            }
            return null;
        }

        internal static string SearchEnumByIndex(string index)
        {
            int intIndex = Convert.ToInt32(index)-1;
            var elementOfEnum = (StatusType)intIndex;
            return Convert.ToString(elementOfEnum);
        }

        internal static void Update(Goal goalForUpdate, List<string> newProperties)
        {
            if (newProperties[0] != null)
                goalForUpdate.Title = newProperties[0];
            if (newProperties[1] != null)
                goalForUpdate.Description = newProperties[1];
            if (newProperties[2] != null)
               goalForUpdate.CategoryID = Convert.ToInt32(newProperties[2]);
            if (newProperties[3] != null)
                goalForUpdate.Status = newProperties[3];
            using (var context = new ApplicationContext())
                context.SaveChanges();
        }

        internal static void Delete(Goal searchElementGoal)
        {
            using (var context = new ApplicationContext())
            {
                context.Goals.Remove(searchElementGoal);
                context.SaveChanges();
            }
        }

        internal static List<Goal> GetGoals()
        {
            using (var context = new ApplicationContext())
            {
                return context.Goals.ToList();
            }
        }

        internal static List<Category> GetCategories()
        {
            using (var context = new ApplicationContext())
            {
                return context.Categories.ToList();
            }
        }

        internal static string[] GetStatuses()
        {
            return System.Enum.GetNames(typeof(StatusType));
        }
    }
}
