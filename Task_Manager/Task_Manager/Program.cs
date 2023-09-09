using Task_Manager.Views;

namespace Task_Manager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(ViewFirst.menu + ViewFirst.makeSelection);
            Console.ReadLine();
        }
    }
}