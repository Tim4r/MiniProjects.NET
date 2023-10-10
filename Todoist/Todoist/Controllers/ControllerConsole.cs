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
        internal const int NumberOfUpdateElements = 4;

        internal static int NumberOfCategoryItems;
        internal static int NumberOfGoals;
        internal static string[] CollecionOfStatuses;
        internal static int NumberOfStatus;
        internal static string Choice;

        static List<Category> Categories;
        static List<Goal> Goals;

        static int selectedCategoryID = 0;

        internal static string GetNewTitleOfGoal()
        {
            string newTitle;
            ViewConsole.OutputARequestToUpdateTheTitle();
            ChekingValidation(NumberOfYesOrNoItems);
            if (Choice == "1")
            {
                Console.WriteLine(ViewConsole.SuggNewTitleEntry); 
                newTitle = ViewConsole.GettingNewProperty();
                return newTitle;
            }   
            else
            return ViewConsole.GettingEmptyProperty();
        }

        internal static string GetNewDescriptionOfGoal()
        {
            string newDescription;
            ViewConsole.OutputARequestToUpdateTheDescription();
            ChekingValidation(NumberOfYesOrNoItems);
            if (Choice == "1")
            {
                Console.WriteLine(ViewConsole.SuggNewDescriptionEntry);
                newDescription = ViewConsole.GettingNewProperty();
                return newDescription;
            }
            else
                return ViewConsole.GettingEmptyProperty();
        }

        internal static string GetNewCategoryOfGoal()
        {
            ViewConsole.OutputARequestToUpdateTheCategory();
            ChekingValidation(NumberOfYesOrNoItems);
            if (Choice == "1")
            {
                Console.WriteLine(ViewConsole.SuggSelectCategoryUpdateTask);
                SearchingCountOfCategory();
                for (int i = 0; i < NumberOfCategoryItems; i++)
                    Console.WriteLine($" {i + 1}. {Categories[i].NameCategory}");
                ChekingValidation(NumberOfCategoryItems);
                int newCategoryInt = Convert.ToInt32(Choice);
                return Categories[newCategoryInt--].NameCategory;
            }
            else
                return ViewConsole.GettingEmptyProperty();
        }

        internal static string GetNewStatusOfGoal()
        {
            ViewConsole.OutputARequestToUpdateTheStatus();
            ChekingValidation(NumberOfYesOrNoItems);
            if (Choice == "1")
            {
                Console.WriteLine(ViewConsole.SuggSelectStatusUpdateTask);
                OutputOfAvaliableStatuses();
                ChekingValidation(NumberOfStatus);
                return ModelConsole.SearchEnumByIndex(Choice);
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

        internal static void SearchingCountOfCategory()
        {
            using (var context  = new ApplicationContext())
            {
                Categories = context.Categories.ToList();
                NumberOfCategoryItems = Categories.Count;
            }
        }
        
        internal static void SearchingCountOfGoals()
        {
            using (var context = new ApplicationContext())
            {
                Goals = context.Goals.ToList();
                NumberOfGoals = Goals.Count;
            }
        }

        internal static void SearchingCountOfStatuses()
        {
            CollecionOfStatuses = System.Enum.GetNames(typeof(StatusType));
            NumberOfStatus = CollecionOfStatuses.Length;
        }

        internal static void OutputOfAvaliableStatuses()
        {
            for (int i = 0; i < NumberOfStatus; i++)
                Console.WriteLine($" {i + 1}. {CollecionOfStatuses[i]}");
        }



        internal static void AddingGoal()
        {
            Console.WriteLine("\n" + ViewConsole.SuggSelectCategoryCreateTask);
           
            SearchingCountOfCategory();

            for (int i = 0; i < NumberOfCategoryItems; i++)
                Console.WriteLine($" {i + 1}. {Categories[i].NameCategory}");

            ChekingValidation(NumberOfCategoryItems);
            selectedCategoryID = Categories[Convert.ToInt32(Choice) - 1].Id;

            Console.WriteLine(ViewConsole.SuggNewTitleEntry);
            var title = Console.ReadLine();

            Console.WriteLine(ViewConsole.SuggNewDescriptionEntry);
            var description = Console.ReadLine();

            Console.WriteLine(ViewConsole.SuggSelectStatusCreateTask);
            SearchingCountOfStatuses();
            OutputOfAvaliableStatuses();
            ChekingValidation(NumberOfStatus);

            string status = ModelConsole.SearchEnumByIndex(Choice);

            using (var context = new ApplicationContext())
            {
                var newGoal = new Goal()
                {
                    Title = title,
                    Description = description,
                    Created = DateTime.UtcNow,
                    Status = status,
                    CategoryID = selectedCategoryID,
                };

                context.Goals.Add(newGoal);
                context.SaveChanges();
            }
        }

        internal static void ViewGoalList()
        {
            using (var context = new ApplicationContext())
            {
                List<Category> categories = context.Categories.Include(category => category.Goals).ToList();
                foreach(Category item in categories)
                  Console.WriteLine(item);

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
        }

        internal static void FindingGoal()
        {
            Console.WriteLine(ViewConsole.SuggWordSearchEntry);
            using (var context = new ApplicationContext())
            {
                var allTasks = context.Goals.ToList();
                string searchWord = Console.ReadLine();
                var results = ModelConsole.SearchElementsByTitleAndDescription(allTasks, searchWord);
                foreach (var item in results)
                    Console.WriteLine(item);
            }
        }

        internal static void UpdatingASelectedGoal()
        {
            string newElement = "";
            List<string> UpdatedProperties = new List<string>();

            SearchingCountOfGoals();
            Console.WriteLine(ViewConsole.SuggMenuItemEntryUpdateEntireTask + "\n");
            ViewConsole.OutputingData(Goals);
            ChekingValidation(NumberOfGoals);
            var goalForUpdate = ModelConsole.SearchElementByIndex(Goals, Convert.ToInt32(Choice));
            Console.WriteLine(goalForUpdate);

            for (int counter = 0; counter < NumberOfUpdateElements; counter++)
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
                UpdatedProperties.Add(newElement);
            }
            ModelConsole.Update(goalForUpdate, UpdatedProperties);
        }

        internal static void DeletingASelectedGoal()
        {
            SearchingCountOfGoals();

            ViewConsole.OutPutTheSuggMenuItemEntryDeleteEntireTask();
            ViewConsole.OutputingData(Goals);

            ChekingValidation(NumberOfGoals);

            var searchedElementGoal = ModelConsole.SearchElementByIndex(Goals, Convert.ToInt32(Choice));
            string searchedElementString = Convert.ToString(searchedElementGoal);

            ViewConsole.OutOfTheFoundElement(searchedElementString);

            Console.WriteLine(ViewConsole.ConfirmationForDeletion + ViewConsole.SuggMakeYesNoMenuSelectable);
            ChekingValidation(NumberOfYesOrNoItems);
            ChekingFinalAnswerForDelete(searchedElementGoal, Choice);
        }



        internal static bool Validation(string testedItem, int numberOfElementsMenu)
        {
            if (!String.IsNullOrEmpty(testedItem) && uint.TryParse(testedItem, out uint res) && Convert.ToInt32(testedItem) != 0 && Convert.ToInt32(testedItem) <= numberOfElementsMenu)
                return true;
            return false;
        }

        internal static void ChekingValidation(int numberOfElementsMenu)
        {
            while (!Validation(Choice = Console.ReadLine(), numberOfElementsMenu))
                Console.WriteLine("Please, enter a valid value!:)\n");
        }

        internal static void CheckingAndImplementingTheStartMenuItem()
        {
            if (Choice == "1")
                AddingGoal();

            else if (Choice == "2")
                ViewGoalList();

            else if (Choice == "3")
                FindingGoal();

            else if (Choice == "4")
                UpdatingASelectedGoal();

            else if (Choice == "5")
                DeletingASelectedGoal();

            else if (Choice == "6")
                Environment.Exit(0);
        }

        internal static void StartedApplication()
        {
            ViewConsole.OutputtingTheStartingQuestionAndAcceptingTheAnswer();
            ChekingValidation(NumberOfStartMenuItems);
            CheckingAndImplementingTheStartMenuItem();
        }
    }
}
