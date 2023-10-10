using Azure.Core;
using System.Linq.Expressions;
using System.Reflection.PortableExecutable;
using Todoist.Controllers;
using Todoist.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Todoist.Views
{
    internal static class ViewConsole
    {
        /// Common
        public const string StartMenu = "\tMenu\n 1. Create a task\n 2. View task list\n 3. Find the task\n 4. Change the task\n 5. Delete the task\n 6. Exit\n";
        public const string SuggMakeStartMenuItemSelectable = " Make a selection by entering a number...\n";
        public const string SuggMakeYesNoMenuSelectable = " 1. Yes\n 2. No\n";

        /// For Create task
        public const string SuggSelectCategoryCreateTask = " Select the category to which you task will belong:";
        public const string SuggNewTitleEntry = " Enter the TITLE of your task:\n";
        public const string SuggNewDescriptionEntry = " Enter the DESCRIPTION of your task:\n";
        public const string SuggNewCategoryEntry = " Enter the CATEGORY of your task:\n";
        public const string SuggSelectStatusCreateTask = "  Select the status of the task to which you task will belong:\n";

        /// For Search task
        public const string SuggWordSearchEntry = " Enter a word to search by title or description:";

        /// For Update task
        public const string SuggMenuItemEntryUpdateEntireTask = " Entering a number of task for update all information about task:";
        public const string TitleQuestionForUpdate = " Do you want to update TITLE of chosen task?";
        public const string DescriptionQuestionForUpdate = " Do you want to update DESCRIPTION of chosen task?";
        public const string CategoryQuestionForUpadate = " Do you want to update CATEGORY of chosen task?";
        public const string StatusQuestionForUpdate = " Do you want to update STATUS of chosen task?\n";
        public const string SuggSelectCategoryUpdateTask = " Select the CATEGORY for update your task:\n";
        public const string SuggSelectStatusUpdateTask = " Select the STASTUS for update your task:\n";

        /// Delete
        public const string SuggMenuItemEntryDeleteEntireTask = " Entering a number of task for delete all information about task:\n";
        public const string ConfirmationForDeletion = " Are you sure you want to delete the selected item?\n";

        internal static void OutputARequestToUpdateTheTitle()
        {
            Console.WriteLine($"{ViewConsole.TitleQuestionForUpdate}\n{ViewConsole.SuggMakeYesNoMenuSelectable}");
        }

        internal static void OutputARequestToUpdateTheDescription()
        {
            Console.WriteLine($"{ViewConsole.DescriptionQuestionForUpdate}\n{ViewConsole.SuggMakeYesNoMenuSelectable}");
        }

        internal static void OutputARequestToUpdateTheCategory()
        {
            Console.WriteLine($"{ViewConsole.CategoryQuestionForUpadate}\n{ViewConsole.SuggMakeYesNoMenuSelectable}");
        }

        internal static void OutputARequestToUpdateTheStatus()
        {
            Console.WriteLine($"{ViewConsole.StatusQuestionForUpdate}\n{ViewConsole.SuggMakeYesNoMenuSelectable}");
        }

        internal static string? GettingNewProperty()
        {
            string newProperty = Console.ReadLine();
            return newProperty;
        }
        //internal static Func<string?> GettingNewTitleLymbda = () => Console.ReadLine();

        internal static string GettingEmptyProperty()
        {
            return "-";
        }

        internal static void OutputingData(List<Goal> allTasks)
        {
            for (int i = 0; i < allTasks.Count; i++)
                Console.WriteLine($" {i + 1}.{allTasks[i]}\n");
        }

        internal static void OutOfTheFoundElement(string searchedElement)
        {
            Console.WriteLine(searchedElement);
        }

        internal static void OutPutTheSuggMenuItemEntryDeleteEntireTask()
        {
            Console.WriteLine(SuggMenuItemEntryDeleteEntireTask);
        }

        internal static void OutputtingTheStartingQuestionAndAcceptingTheAnswer()
        {
            Console.WriteLine(StartMenu, SuggMakeStartMenuItemSelectable);
        }
    }
}
