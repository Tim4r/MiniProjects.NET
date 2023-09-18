using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Task_Manager.Connection;
using Task_Manager.Entities;
using Task_Manager.Views;

namespace Task_Manager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(ViewFirst.menu + ViewFirst.makeSelection);
            Console.ReadLine();

            using (ApplicationContext db = new ApplicationContext())
            {
                //Category UnimportantNonUrgent = new Category { Id = 1, NameCategory = "Unimportant and non - urgent matters" };

                //db.Categories.Add(UnimportantNonUrgent);
                //db.SaveChanges();
                //Console.WriteLine("Объекты успешно сохранены");

                //var Categories = db.Categories.ToList();
                //Console.WriteLine("Список объектов:");
                //foreach (var Category in Categories)
                //{
                //    Console.WriteLine($"{Category.Id}.{Category.NameCategory}");
                //}

                var builder = WebApplication.CreateBuilder(args);
            }
        }
    }
}