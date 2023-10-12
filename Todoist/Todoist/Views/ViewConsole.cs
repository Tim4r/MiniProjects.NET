using Todoist.Entities;

namespace Todoist.Views
{
    internal static class ViewConsole
    {
        /// Common
        public const string StartMenu = "\tMenu\n 1. Create a task\n 2. View task list\n 3. Find the task\n 4. Change the task\n 5. Delete the task\n 6. Exit\n";
        public const string SuggMakeStartMenuItemSelectable = " Make a selection by entering a number...\n";
        private const string SuggMakeYesNoMenuSelectable = " 1. Yes\n 2. No\n";

        /// For Create task
        private const string SuggEnterNewTitle = " Enter the TITLE of your task:\n";
        private const string SuggEnterNewDescription = " Enter the DESCRIPTION of your task:\n";

        /// For Search task
        private const string SuggEnterWordForSearch = " Enter a word to search by TITLE or DESCRIPTION:";

        /// For Update task
        private const string SuggSelectGoalForUpdate = " Select a number of task to update its information:";
        public const string TitleQuestionForUpdate = " Do you want to update TITLE of chosen task?";
        public const string DescriptionQuestionForUpdate = " Do you want to update DESCRIPTION of chosen task?";
        public const string CategoryQuestionForUpadate = " Do you want to update CATEGORY of chosen task?";
        public const string StatusQuestionForUpdate = " Do you want to update STATUS of chosen task?\n";
        private const string SuggSelectCategoryOfGoal = " Select the CATEGORY to which you task will belong:";
        private const string SuggSelectStatusOfGoal = " Select the STATUS to which you task will belong:\n";

        /// Delete
        public const string SuggMenuItemEntryDeleteEntireTask = " Entering a number of task for delete all information about task:\n";
        private const string ConfirmationForDeletion = " Are you sure you want to delete the selected item?\n";


        /// EnterFromFind
        internal static void OutputSuggEnterWordForSearch()
        {
            Console.WriteLine(SuggEnterWordForSearch);
        }

        /// EnterOfNew
        internal static void OutputSuggEnterNewTitle()
        {
            Console.WriteLine(SuggEnterNewTitle);
        }
        internal static void OutputSuggEnterNewDescription()
        {
            Console.WriteLine(SuggEnterNewDescription);
        }

        /// SelectFromExist
        internal static void OutputSuggSelectCategoryOfGoal()
        {
            Console.WriteLine(SuggSelectCategoryOfGoal);
        }
        internal static void OutputSuggSelectStatusOfGoal()
        {
            Console.WriteLine(SuggSelectStatusOfGoal);
        }
        internal static void OutputSuggSelectGoalForUpdate()
        {
            Console.WriteLine(SuggSelectGoalForUpdate + "\n");
        }

        internal static void ConfirmationForDeletetion()
        {
            Console.WriteLine(ConfirmationForDeletion + SuggMakeYesNoMenuSelectable);
        }



        internal static void OutputARequestToUpdateTheTitle()
        {
            Console.WriteLine($"{TitleQuestionForUpdate}\n{SuggMakeYesNoMenuSelectable}");
        }

        internal static void OutputARequestToUpdateTheDescription()
        {
            Console.WriteLine($"{DescriptionQuestionForUpdate}\n{SuggMakeYesNoMenuSelectable}");
        }

        internal static void OutputARequestToUpdateTheCategory()
        {
            Console.WriteLine($"{CategoryQuestionForUpadate} \n {SuggMakeYesNoMenuSelectable}");
        }

        internal static void OutputARequestToUpdateTheStatus()
        {
            Console.WriteLine($"{StatusQuestionForUpdate} \n {SuggMakeYesNoMenuSelectable}");
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

        internal static void OutputGoal(Goal goal)
        {
            Console.WriteLine(goal);
        }

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
