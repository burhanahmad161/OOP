using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CRUD
{
    class Program
    {
        static public int productCount = -1;
        class product
        {
            public string itemName;
            public int itemRate;
        }
        static void Main(string[] args)
        {
            List<product> p1 = new List<product>();
            loadItems(p1);
            options(p1); 
        }
        static void addingItem(List<product> p1) ///////////////////////// Adding new Item to Menu
        {
            string name;
            float price;
            Console.Clear();
            product obj = new product();
            Console.WriteLine("Enter new food item:");
            obj.itemName = Console.ReadLine();
            Console.WriteLine("Enter price of item:");
            obj.itemRate = int.Parse(Console.ReadLine());
            name = obj.itemName;
            price = obj.itemRate;
            if (obj.itemRate > 0)
            {
                storeItems(name, price);
                p1.Add(obj);
                Console.WriteLine("Enter any key to return to previos secion:");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Enter correct price:");
                Console.WriteLine("Enter any key to continue...");
                Console.ReadKey();
                addingItem(p1);
            }
        }
        static void changingRates(List<product> p1) //////////////////// Changing rate of products
        {
            Console.Clear();
            int num;
            int new_rate;
            string name;
            if (p1.Count() == 0)
            {
                Console.WriteLine("There is no item in the menu currently.");
                Console.WriteLine("Enter any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Enter the number of item you want to change price:");
                num = int.Parse(Console.ReadLine());
                if (num > 0 && num <= p1.Count())
                {
                    Console.WriteLine("Enter new Name: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter new rate:");
                    new_rate = int.Parse(Console.ReadLine());
                    p1[num - 1].itemName = name;
                    p1[num - 1].itemRate = new_rate;
                    storeItems(name,new_rate);
                    Console.WriteLine("Enter any key to return to previos secion:");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                    Console.WriteLine("Enter any key to continue");
                    Console.ReadKey();
                    changingRates(p1);
                }
            }
        }
        static void checkMenu(List<product> p1) /////////////////// for checking menu
        {
            Console.Clear();
            for (int idx = 0; idx < p1.Count(); idx++)
            {
                int n = idx + 1;
                Console.WriteLine( n + "-" + p1[idx].itemName + "          " + p1[idx].itemRate );
            }
            Console.WriteLine("Enter any key to return to previous menu");
            Console.ReadKey();
        }
        static void storeItems(string name,float price) ///////////////// for storing items
        {
            string path = "data.txt";
            StreamWriter gross = new StreamWriter(path,true);
            gross.WriteLine(name + "," + price);
            gross.Flush();
            gross.Close();
        }
        static void loadItems(List<product> p1) ////////////////// for loading items
        {
            string path = "data.txt";
            if (File.Exists(path))
            {
                StreamReader fp = new StreamReader(path);
                string word;
                productCount = 0;
                while ((word = fp.ReadLine()) != null)
                {
                    product data = new product();
                    data.itemName = parsItems(word, 1);
                    data.itemRate = int.Parse(parsItems(word, 2));
                    p1.Add(data);
                }
                    fp.Close();
            }
            else
            {
                Console.WriteLine("Not Exist");
            }
        }
        static string parsItems(string itemName, int itemRate) //////////////////// parsing function
        {
            int commaCount = 1;
            string item = "";
            for (int x = 0; x < itemName.Length; x++)
            {
                if (itemName[x] == ',')
                {
                    commaCount = commaCount + 1;
                }
                else if (commaCount == itemRate)
                {
                    item = item + itemName[x];
                }
            }
            return item;
        }
        static void deleteItems_fromFile(List<product> p1) ////////////////////// for deleting an item from file
        {
            string path = "data.txt";
            StreamWriter gross = new StreamWriter(path, false);
            for (int idx = 0; idx < p1.Count(); idx++)
            {
                gross.WriteLine( p1[idx].itemName + ","  + p1[idx].itemRate );
                gross.Flush();
            }
            gross.Close();
        }
        static int start()
        {
            Console.Clear();
            int choice;
            Console.WriteLine("1-Add item");
            Console.WriteLine("2-View Items");
            Console.WriteLine("3-Delete an Item");
            Console.WriteLine("4-Update price");
            Console.WriteLine("Enter your choice");
            choice = int.Parse(Console.ReadLine());
            return choice; 
        }
        static void options(List<product> p1)
        {
            int choice;
            while (true)
            {
                Console.Clear();
                choice = start();
                if (choice == 1)
                {
                    addingItem(p1);
                }
                else if (choice == 2)
                {
                    checkMenu(p1);
                }
                else if (choice == 3)
                {
                    deletingItem(p1);
                }
                else if (choice == 4)
                {
                    changingRates(p1);
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    Console.ReadKey();
                }
            }
        }
        static void deletingItem(List<product> p1) ///////////////////////// Deleting any item of menu
        {
            for (int idx = 0; idx < p1.Count(); idx++)
            {
                int n = idx + 1;
                Console.WriteLine(n + "-" + p1[idx].itemName + "          " + p1[idx].itemRate);
            }
            if (p1.Count() == 0)
            {
                Console.WriteLine("Enter any key to continue...");
                Console.ReadKey();
            }
            else
            {
                int num;
                Console.WriteLine("Enter the number of item you want to delete:");
                num = int.Parse(Console.ReadLine());
                if (num > 0 && num <= p1.Count())
                {
                    p1.RemoveAt(num-1);
                    deleteItems_fromFile(p1);
                    for (int idx = 0; idx < p1.Count(); idx++)
                    {
                        int n = idx + 1;
                        Console.WriteLine(n + "-" + p1[idx].itemName + "          " + p1[idx].itemRate);
                    }
                    Console.WriteLine("Enter any key to return to previos secion:");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Enter correct number...");
                    Console.WriteLine("Enter any key to continue...");
                    Console.ReadKey();
                    deletingItem(p1);
                }
            }
        }
    }
}