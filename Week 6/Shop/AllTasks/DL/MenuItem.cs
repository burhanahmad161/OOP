using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllTasks.BL;
using AllTasks.UI;
using AllTasks.DL;

namespace AllTasks.DL
{
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
            MenuItem obj = new MenuItem(Name, Type, Price);
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
            for (int idx = n - 1; idx >= 0; idx--)
            {
                if (orders.Count != 0)
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
                for (int idx = 0; idx < orders.Count; idx++)
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
            for (int idx = 0; idx < ordersRate.Count; idx++)
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
}
