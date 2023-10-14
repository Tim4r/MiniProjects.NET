using Todoist.Views;
using Todoist.Model;
using Todoist.Entities;
using Todoist.DataAccess;
using Microsoft.EntityFrameworkCore;
using Todoist.Consts;

namespace Todoist.Controllers
{
    internal static class ControllerConsole
    {
        internal static string GetNewTitleOfGoal()
        {
            string choice;
            string newTitle;

            ViewConsole.Display($"{AppConsts.Question.ForUpdate.Title}\n{AppConsts.Common.Menu.YesNoSelectable}");
            choice = ChekingValidation(Console.ReadLine(), AppConsts.Common.NumberOf.YesOrNoItems);
            if (choice == "1")
            {
                ViewConsole.Display(AppConsts.Suggestion.Enter.NewTitle);
                newTitle = ViewConsole.GetInput();
                return newTitle;
            }   
            else
            return ViewConsole.GetEmpty();
        }

        internal static string GetNewDescriptionOfGoal()
        {
            string choice;
            string newDescription;

            ViewConsole.Display($"{AppConsts.Question.ForUpdate.Description}\n{AppConsts.Common.Menu.YesNoSelectable}");
            choice = ChekingValidation(Console.ReadLine(), AppConsts.Common.NumberOf.YesOrNoItems);
            if (choice == "1")
            {
                ViewConsole.Display(AppConsts.Suggestion.Enter.NewDescription);
                newDescription = ViewConsole.GetInput();
                return newDescription;
            }
            else
                return ViewConsole.GetEmpty();
        }

        internal static string GetNewCategoryOfGoal()
        {
            List<Category> categories = new List<Category>();
            string choice;
            ViewConsole.Display($"{AppConsts.Question.ForUpdate.Category} \n {AppConsts.Common.Menu.YesNoSelectable}");
            choice = ChekingValidation(Console.ReadLine(), AppConsts.Common.NumberOf.YesOrNoItems);
            if (choice == "1")
            {
                ViewConsole.Display(AppConsts.Suggestion.Select.StatusOfGoal);
                categories = ModelConsole.GetCategories();
                ViewConsole.OutputCategories(categories);
                choice = ChekingValidation(Console.ReadLine(), categories.Count);
                int newCategoryInt = Convert.ToInt32(choice);
                return categories[newCategoryInt--].NameCategory;
            }
            else
                return ViewConsole.GetEmpty();
        }

        internal static string GetNewStatusOfGoal()
        {
            string[] statuses;
            string choice;

            ViewConsole.Display($"{AppConsts.Question.ForUpdate.Status} \n {AppConsts.Common.Menu.YesNoSelectable}");
            choice = ChekingValidation(Console.ReadLine(), AppConsts.Common.NumberOf.YesOrNoItems);
            if (choice == "1")
            {
                ViewConsole.Display(AppConsts.Suggestion.Select.StatusOfGoal);
                statuses = ModelConsole.GetStatuses();
                ViewConsole.OutputOfAvaliableStatuses(statuses);
                choice = ChekingValidation(Console.ReadLine(), statuses.Length);
                return ModelConsole.SearchEnumByIndex(choice);
            }
            else
                return ViewConsole.GetEmpty();
        }

        internal static void ChekingFinalAnswerForDelete(Goal searchElementGoal, string choice)
        {
            if (choice == "1")
                ModelConsole.Delete(searchElementGoal);
            //// Обработать выход
        }

        ///Вынести от сюда
        
        ////////////////////////////////////


        internal static void AddingGoal()
        {
            List<Category> categories = ModelConsole.GetCategories();
            string[] statuses = ModelConsole.GetStatuses();
            int categoryId;
            string choice;

            ViewConsole.Display(AppConsts.Suggestion.Enter.NewTitle);                          //// Дописать ограничение на количество символов
            var title = Console.ReadLine();

            ViewConsole.Display(AppConsts.Suggestion.Enter.NewDescription);                    //// Дописать ограничение на количество символов
            var description = Console.ReadLine();

            ViewConsole.Display(AppConsts.Suggestion.Select.StatusOfGoal);
            categories = ModelConsole.GetCategories();
            ViewConsole.OutputCategories(categories);
            choice = ChekingValidation(Console.ReadLine(), categories.Count);
            categoryId = categories[Convert.ToInt32(choice) - 1].Id;

            ViewConsole.Display(AppConsts.Suggestion.Select.StatusOfGoal);
            ViewConsole.OutputOfAvaliableStatuses(statuses);
            choice = ChekingValidation(Console.ReadLine(), statuses.Length);
            string status = ModelConsole.SearchEnumByIndex(choice);

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

        internal static void ViewGoalList()
        {
            List<Category> categories;

            using (var context = new ApplicationContext())
            {
                categories = context.Categories.Include(category => category.Goals).ToList();
            }
            ViewConsole.OutputCategories(categories);

            //var goals = context.Goals.ToList();
            //var categories = context.Categories.ToList();

            //foreach (Category category in categories)
            //{
            //    category.Goals = new List<Goal>();
            //    foreach (Goal goal in goals)
            //    {
            //        if (goal.CategoryID == category.Id)
            //        {
            //            category.Goals.Add(goal);
            //        }
            //    }
            //}

            //foreach (Category category in categories)
            //    foreach (Goal goal in category.Goals)
            //        Console.WriteLine("NameCategory: " + category.NameCategory + " " + goal);

            //foreach(Goal goal in goals)
            //    Console.WriteLine(goal);
        }

        internal static void FindingGoal()
        {
            List<Goal> goals = ModelConsole.GetGoals();

            ViewConsole.Display(AppConsts.Suggestion.Enter.WordForSearch);
            string searchWord = Console.ReadLine();                                                 ///////////////Добавить ограничение на ввод символов
            var results = ModelConsole.SearchElementsByTitleAndDescription(goals, searchWord);
            ViewConsole.OutputGoals(results);
        }

        internal static void UpdatingASelectedGoal()
        {
            List<Goal> goals = ModelConsole.GetGoals();
            List<string> updatedProperties = new List<string>();
            string newElement = "";
            string choice;

            ViewConsole.Display(AppConsts.Suggestion.Select.Goal + "\n");
            ViewConsole.OutputGoals(goals);
            choice = ChekingValidation(Console.ReadLine(), goals.Count);
            var goalForUpdate = ModelConsole.SearchElementByIndex(goals, Convert.ToInt32(choice));
            ViewConsole.Display(goalForUpdate);

            for (int counter = 0; counter < AppConsts.Common.NumberOf.ElementsForUpdate; counter++)
            {
                switch (counter)
                {
                    case 0:
                        newElement = GetNewTitleOfGoal();
                        break;
                    case 1:
                        newElement = GetNewDescriptionOfGoal();
                        break;
                    case 2:
                        newElement = GetNewCategoryOfGoal();
                        break;
                    case 3:
                        newElement = GetNewStatusOfGoal();
                        break;
                }
                updatedProperties.Add(newElement);
            }
            ModelConsole.Update(goalForUpdate, updatedProperties);
        }

        internal static void DeletingASelectedGoal()
        {
            List <Goal> goals = ModelConsole.GetGoals();
            string choice;

            ViewConsole.Display(AppConsts.Suggestion.Select.Goal);
            ViewConsole.OutputGoals(goals);

            choice = ChekingValidation(Console.ReadLine(), goals.Count);

            var searchedElementGoal = ModelConsole.SearchElementByIndex(goals, Convert.ToInt32(choice));
            ViewConsole.Display(searchedElementGoal);

            ViewConsole.Display(AppConsts.Question.ForDelete.Confirmation + AppConsts.Common.Menu.YesNoSelectable);
            choice = ChekingValidation(Console.ReadLine(), AppConsts.Common.NumberOf.YesOrNoItems);
            ChekingFinalAnswerForDelete(searchedElementGoal, choice);
        }



        internal static bool Validation(string testedItem, int numberOfElementsMenu)
        {
            if (!String.IsNullOrEmpty(testedItem) && uint.TryParse(testedItem, out uint res) && Convert.ToInt32(testedItem) != 0 && Convert.ToInt32(testedItem) <= numberOfElementsMenu)
                return true;
            return false;
        }

        internal static string ChekingValidation(string choice, int numberOfElementsMenu)
        {
            while (!Validation(choice, numberOfElementsMenu))
            {
                Console.WriteLine("Please, enter a valid value!:)\n");
                choice = Console.ReadLine();
            }
            return choice;
        }

        internal static void CheckingAndImplementingTheStartMenuItem(string choice)
        {
            if (choice == "1")
                AddingGoal();

            else if (choice == "2")
                ViewGoalList();

            else if (choice == "3")
                FindingGoal();

            else if (choice == "4")
                UpdatingASelectedGoal();

            else if (choice == "5")
                DeletingASelectedGoal();

            else if (choice == "6")
                Environment.Exit(0);
        }

        internal static void StartApplication()
        {
            string choice;
            ViewConsole.Display(AppConsts.Common.Menu.Start + AppConsts.Common.Menu.StartItemSelectable);
            choice = ChekingValidation(Console.ReadLine(), AppConsts.Common.NumberOf.StartItems);
            CheckingAndImplementingTheStartMenuItem(choice);
        }
    }
}
