using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllTasks.BL;
using AllTasks.UI;
using AllTasks.DL;

namespace AllTasks.UI
{
    class DisplayingMenu
    {
        public static void header()
        {
            Console.WriteLine("***********************************");
            Console.WriteLine("   Welcome to Tesha's Coffe Shop");
            Console.WriteLine("***********************************");
        }
        public static int Menu()
        {
            Console.Clear();
            int choice;
            header();
            Console.WriteLine("1. Add a Menu Item");
            Console.WriteLine("2. View Cheapest Menu in the menu");
            Console.WriteLine("3. View the Drink's Menu");
            Console.WriteLine("4. View the Food's Menu");
            Console.WriteLine("5. Add Order");
            Console.WriteLine("6. Fulfill the Order");
            Console.WriteLine("7. View the Order's List");
            Console.WriteLine("8. Total Payable Amount");
            Console.WriteLine("9. Exit");
            Console.Write("Enter your choice: ");
            choice = int.Parse(Console.ReadLine());
            return choice;
        }
    }
}
