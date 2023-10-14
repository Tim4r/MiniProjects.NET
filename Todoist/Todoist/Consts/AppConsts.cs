namespace Todoist.Consts
{
    internal static class AppConsts
    {
        internal static class Common
        {
            internal static class Menu
            {
                public const string Start = "\tMenu\n 1. Create a task\n 2. View task list\n 3. Find the task\n 4. Change the task\n 5. Delete the task\n 6. Exit\n";
                public const string StartItemSelectable = " Make a selection by entering a number...\n";
                public const string YesNoSelectable = " 1. Yes\n 2. No\n";
            }

            internal static class NumberOf
            {
                internal const int StartItems = 6;
                internal const int YesOrNoItems = 2;
                internal const int ElementsForUpdate = 4;
            }
        }

        internal static class Suggestion
        {
            internal static class Enter
            {
                public const string NewTitle = " Enter the TITLE of your task:\n";
                public const string NewDescription = " Enter the DESCRIPTION of your task:\n";
                public const string WordForSearch = " Enter a word to search by TITLE or DESCRIPTION:";
            }
            internal static class Select
            {
                public const string Goal = " Select a number of task:\n";
                public const string CategoryOfGoal = " Select the CATEGORY to which you task will belong:";
                public const string StatusOfGoal = " Select the STATUS to which you task will belong:\n";
            }
        }

        internal static class Question
        {
            internal static class ForUpdate
            {
                public const string Title = " Do you want to update TITLE of chosen task?";
                public const string Description = " Do you want to update DESCRIPTION of chosen task?";
                public const string Category = " Do you want to update CATEGORY of chosen task?";
                public const string Status = " Do you want to update STATUS of chosen task?\n";
            }

            internal static class ForDelete
            {
                public const string Confirmation = " Are you sure you want to delete the selected item?\n";
            }
        }
    }
}
