using Todoist.DataAccess;
using Todoist.Entities;
using Todoist.Enum;

namespace Todoist.Model
{
    internal class ModelConsole
    {
        internal List<Goal> GetGoals()
        {
            using (var context = new ApplicationContext())
            {
                return context.Goals.ToList();
            }
        }

        internal List<Category> GetCategories()
        {
            using (var context = new ApplicationContext())
            {
                return context.Categories.ToList();
            }
        }

        internal Func<string[]> GetStatuses = () => System.Enum.GetNames(typeof(StatusType));

        internal List<Goal> SearchElementsByTitleAndDescription(List<Goal> allTasks, string searchWord) ////В одну строчку
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

            return results;
        }

        internal Goal? SearchElementByIndex(List<Goal> allTasks, int menuItem)
        { 
            int count = allTasks.Count;
            for (int i = 0; i < count; i++)
            {
                if (i+1 == menuItem)
                    return allTasks[i];
            }
            return null;
        }

        internal string SearchEnumByIndex(string index)
        {
            int intIndex = Convert.ToInt32(index)-1;
            var elementOfEnum = (StatusType)intIndex;
            return Convert.ToString(elementOfEnum);
        }

        internal void Add(string title, string description, string status, int categoryId)
        {
            using (var context = new ApplicationContext())
            {
                var newGoal = new Goal()
                {
                    Title = title,
                    Description = description,
                    Created = DateTime.UtcNow,
                    Status = status,
                    CategoryID = categoryId,
                };

                context.Goals.Add(newGoal);
                context.SaveChanges();
            }
        }

        internal void Update(Goal goalForUpdate, List<string> newProperties)
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

        internal void Delete(Goal searchElementGoal)
        {
            using (var context = new ApplicationContext())
            {
                context.Goals.Remove(searchElementGoal);
                context.SaveChanges();
            }
        }
    }
}
