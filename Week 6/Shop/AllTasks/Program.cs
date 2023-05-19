using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllTasks
{
    class Program
    {
        class MenuItem
        {
             public string Name;
             public string Type;
             public int Price;
             public MenuItem(string name,string type,int price)
            {
                Name = name;
                Type = type;
                Price = price;
            }
        }
        class CoffeShop
        {
           static string ShopName;
        }
        class MenuItemDl
        {
           static List<MenuItem> Items = new List<MenuItem>();
           static List<string> orders = new List<string>();
           static List<int> ordersRate = new List<int>();
            public MenuItem AddItem()
            {
                Console.WriteLine("Enter name of item: ");
                 string Name = Console.ReadLine();
                Console.WriteLine("Enter type of item: ");
                string Type = Console.ReadLine();
                Console.WriteLine("Enter price of item: ");
                int Price = int.Parse(Console.ReadLine());
                MenuItem obj = new MenuItem(Name,Type,Price);
                Items.Add(obj);
                return obj;
            }
            public void TakeOrder()
            {
                Console.Write("Enter the item you want to buy: ");
                string OrderName = Console.ReadLine();

                for (int idx = 0; idx < Items.Count(); idx++)
                {
                   
                    if (OrderName == Items[idx].Name)
                    { 
                        orders.Add(OrderName);
                        ordersRate.Add(Items[idx].Price);
                    }
                    else
                    {
                        Console.WriteLine("The item is not currently available on the menu");
                        Console.ReadKey();
                        break;
                    }
                }
            }
            public void FullFillOrder()
            {
                int n = orders.Count();
                for (int idx = n-1; idx >= 0; idx--)
                {
                    if(orders.Count != 0)
                    {
                        Console.WriteLine("The " + orders[idx] + " is ready");
                        orders.RemoveAt(idx);
                        ordersRate.RemoveAt(idx);
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("All orders have been completed");
                        Console.ReadKey();
                        break;
                    }
                }
            }
            public void DisplayList()
            {                
                if (orders.Count != 0)
                {
                    for(int idx=0 ; idx < orders.Count ; idx++)
                    {
                        Console.WriteLine(idx + 1 + "-" + orders[idx] + "\t" + ordersRate[idx]);
                    }
                }
                else
                {
                    Console.WriteLine("There is currently no items in the menu");
                    Console.ReadKey();
                }
            }
            public int CalculateAmount()
            {
                int money = 0;
                for(int idx = 0; idx < ordersRate.Count; idx++)
                {
                    money = 0 + ordersRate[idx];
                }
                return money;
            }
            public void CheapestItem()
            {
              Items = Items.OrderBy(o => o.Price).ToList();
                if (Items.Count != 0)
                {
                    Console.WriteLine("Cheapest item in the menu is");
                    Console.WriteLine(Items[0].Name + "\t" + "\t" + Items[0].Price);
                }
            }
            public void DrinkType()
            {
                List<string> obj = new List<string>();
                string name = "drink";
                for(int idx = 0; idx<Items.Count();idx++)
                if(name == Items[idx].Type)
                    {
                        obj.Add(Items[idx].Name);
                    }
                foreach(string x in obj)
                {
                    Console.WriteLine(x);
                }
            }
            public void FoodType()
            {
                List<string> obj = new List<string>();
                string name = "food";
                for (int idx = 0; idx < Items.Count(); idx++)
                    if (name == Items[idx].Type)
                    {
                        obj.Add(Items[idx].Name);
                    }
                foreach (string x in obj)
                {
                    Console.WriteLine(x);
                }
            }
        }
        static void Main(string[] args)
        {
            MenuItemDl g = new MenuItemDl();
            while(true)
            {
                int choice = Menu();
                if(choice == 1)
                {
                    Console.Clear();
                    header();
                    g.AddItem(); 
                }
                else if(choice == 2)
                {
                    Console.Clear();
                    header();
                    g.CheapestItem();
                }
                else if(choice == 3)
                {
                    Console.Clear();
                    header();
                    g.DrinkType();
                }
                else if(choice == 4)
                {
                    Console.Clear();
                    header();
                    g.FoodType();
                }
                else if(choice == 5)
                {
                    Console.Clear();
                    header();
                    g.TakeOrder();
                }
                else if(choice == 6)
                {
                    Console.Clear();
                    header();
                    g.FullFillOrder();
                }
                else if(choice == 7)
                {
                    Console.Clear();
                    header();
                    g.DisplayList();
                }
                else if(choice == 8)
                {
                    Console.Clear();
                    header();
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
        static int Menu()
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
        static void header()
        {
            Console.WriteLine("***********************************");
            Console.WriteLine("   Welcome to Tesha's Coffe Shop");
            Console.WriteLine("***********************************");
        }
        /*static void add()
        {
            List<string> o = new List<string>();
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
        }/*
    }
}
