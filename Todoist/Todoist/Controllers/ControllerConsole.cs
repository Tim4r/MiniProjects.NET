using Todoist.Views;
using Todoist.Model;
using Todoist.Entities;
using Todoist.DataAccess;
using Microsoft.EntityFrameworkCore;
using Todoist.Enum;

namespace Todoist.Controllers
{
    internal static class ControllerConsole
    {
        internal const int NumberOfStartMenuItems = 6;
        internal const int NumberOfYesOrNoItems = 2;
        internal const int NumberOfElementsForUpdate = 4;

        internal static string GetNewTitleOfGoal()
        {
            string choice;
            string newTitle;

            ViewConsole.OutputARequestToUpdateTheTitle();
            choice = ChekingValidation(Console.ReadLine(), NumberOfYesOrNoItems);
            if (choice == "1")
            {
                ViewConsole.OutputSuggEnterNewTitle();
                newTitle = ViewConsole.GettingNewProperty();
                return newTitle;
            }   
            else
            return ViewConsole.GettingEmptyProperty();
        }

        internal static string GetNewDescriptionOfGoal()
        {
            string choice;
            string newDescription;

            ViewConsole.OutputARequestToUpdateTheDescription();
            choice = ChekingValidation(Console.ReadLine(), NumberOfYesOrNoItems);
            if (choice == "1")
            {
                ViewConsole.OutputSuggEnterNewDescription();
                newDescription = ViewConsole.GettingNewProperty();
                return newDescription;
            }
            else
                return ViewConsole.GettingEmptyProperty();
        }

        internal static string GetNewCategoryOfGoal()
        {
            List<Category> categories = new List<Category>();
            string choice;

            ViewConsole.OutputARequestToUpdateTheCategory();
            choice = ChekingValidation(Console.ReadLine(), NumberOfYesOrNoItems);
            if (choice == "1")
            {
                ViewConsole.OutputSuggSelectStatusOfGoal();
                categories = GetCategories();
                ViewConsole.OutputCategories(categories);
                choice = ChekingValidation(Console.ReadLine(), categories.Count);
                int newCategoryInt = Convert.ToInt32(choice);
                return categories[newCategoryInt--].NameCategory;
            }
            else
                return ViewConsole.GettingEmptyProperty();
        }

        internal static string GetNewStatusOfGoal()
        {
            string[] statuses;
            string choice;

            ViewConsole.OutputARequestToUpdateTheStatus();
            choice = ChekingValidation(Console.ReadLine(), NumberOfYesOrNoItems);
            if (choice == "1")
            {
                ViewConsole.OutputSuggSelectStatusOfGoal();
                statuses = GetStatuses();
                OutputOfAvaliableStatuses(statuses);
                choice = ChekingValidation(Console.ReadLine(), statuses.Length);
                return ModelConsole.SearchEnumByIndex(choice);
            }
            else
                return ViewConsole.GettingEmptyProperty();
        }

        internal static void ChekingFinalAnswerForDelete(Goal searchElementGoal, string choice)
        {
            if (choice == "1")
                ModelConsole.Delete(searchElementGoal);
            //// Обработать выход
        }

        ///Вынести от сюда
        internal static void OutputOfAvaliableStatuses(string[] statuses)
        {
            for (int i = 0; i < statuses.Length; i++)
                Console.WriteLine($" {i + 1}. {statuses[i]}");
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
        ////////////////////////////////////


        internal static void AddingGoal()
        {
            List<Category> categories = GetCategories();
            string[] statuses = GetStatuses();
            int categoryId;
            string choice;

            ViewConsole.OutputSuggEnterNewTitle();                             //// Дописать ограничение на количество символов
            var title = Console.ReadLine();

            ViewConsole.OutputSuggEnterNewDescription();                       //// Дописать ограничение на количество символов
            var description = Console.ReadLine();

            ViewConsole.OutputSuggSelectStatusOfGoal();
            categories = GetCategories();
            ViewConsole.OutputCategories(categories);
            choice = ChekingValidation(Console.ReadLine(), categories.Count);
            categoryId = categories[Convert.ToInt32(choice) - 1].Id;

            ViewConsole.OutputSuggSelectStatusOfGoal();
            OutputOfAvaliableStatuses(statuses);
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
            List<Goal> goals = GetGoals();

            ViewConsole.OutputSuggEnterWordForSearch();
            string searchWord = Console.ReadLine();                                                 ///////////////Добавить ограничение на ввод символов
            var results = ModelConsole.SearchElementsByTitleAndDescription(goals, searchWord);
            ViewConsole.OutputGoals(results);
        }

        internal static void UpdatingASelectedGoal()
        {
            List<Goal> goals = GetGoals();
            List<string> updatedProperties = new List<string>();
            string newElement = "";
            string choice;

            ViewConsole.OutputSuggSelectGoalForUpdate();
            ViewConsole.OutputGoals(goals);
            choice = ChekingValidation(Console.ReadLine(), goals.Count);
            var goalForUpdate = ModelConsole.SearchElementByIndex(goals, Convert.ToInt32(choice));
            ViewConsole.OutputGoal(goalForUpdate);

            for (int counter = 0; counter < NumberOfElementsForUpdate; counter++)
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
            List <Goal> goals = GetGoals();
            string choice;

            ViewConsole.OutPutTheSuggMenuItemEntryDeleteEntireTask();
            ViewConsole.OutputGoals(goals);

            choice = ChekingValidation(Console.ReadLine(), goals.Count);

            var searchedElementGoal = ModelConsole.SearchElementByIndex(goals, Convert.ToInt32(choice));
            string searchedElementString = Convert.ToString(searchedElementGoal);

            ViewConsole.OutOfTheFoundElement(searchedElementString);

            ViewConsole.ConfirmationForDeletetion();
            choice = ChekingValidation(Console.ReadLine(), NumberOfYesOrNoItems);
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

        internal static void StartedApplication()
        {
            string choice;
            ViewConsole.OutputtingTheStartingQuestionAndAcceptingTheAnswer();
            choice = ChekingValidation(Console.ReadLine(), NumberOfStartMenuItems);
            CheckingAndImplementingTheStartMenuItem(choice);
        }
    }
}
