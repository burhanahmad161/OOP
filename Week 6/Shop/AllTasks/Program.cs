using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllTasks.BL;
using AllTasks.UI;
using AllTasks.DL;

namespace AllTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuItemDl g = new MenuItemDl();
            while(true)
            {
                int choice = DisplayingMenu.Menu();
                if(choice == 1)
                {
                    Console.Clear();
                    DisplayingMenu.header();
                    g.AddItem(); 
                }
                else if(choice == 2)
                {
                    Console.Clear();
                    DisplayingMenu.header();
                    g.CheapestItem();
                }
                else if(choice == 3)
                {
                    Console.Clear();
                    DisplayingMenu.header();
                    g.DrinkType();
                }
                else if(choice == 4)
                {
                    Console.Clear();
                    DisplayingMenu.header();
                    g.FoodType();
                }
                else if(choice == 5)
                {
                    Console.Clear();
                    DisplayingMenu.header();
                    g.TakeOrder();
                }
                else if(choice == 6)
                {
                    Console.Clear();
                    DisplayingMenu.header();
                    g.FullFillOrder();
                }
                else if(choice == 7)
                {
                    Console.Clear();
                    DisplayingMenu.header();
                    g.DisplayList();
                }
                else if(choice == 8)
                {
                    Console.Clear();
                    DisplayingMenu.header();
                    int price = g.CalculateAmount();
                    Console.WriteLine("Your bill is: " + price);
                }
                else if(choice == 9)
                {
                    break;
                }
                Console.ReadKey();
            }
        }
    }
}
