using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Application
{
    class Bill
    {
       public double FinalBill;
    }
    class product
    {
        public string itemName;
        public int itemRate;
    }
    class OrderedProduct
    {
        public string Name;
        public int Rate;
        public int Quantity;
        public OrderedProduct(string name,int rate,int quantity)
        {
            Name = name;
            Rate = rate;
            Quantity = quantity;
        }
    }
    class GivenRating
    {
        public string Name;
        public int Rating;
        public GivenRating(string name,int rating)
        {
            Name = name;
            Rating = rating;
        }
    }
    class UserLogin
    {
        public string Name;
        public string Username;
        public string Password;
        public int CardNumber;
        public int Pin;
        public UserLogin(string name, string username, string password, int cardNumber, int pin)
        {
            Name = name;
            Username = username;
            Password = password;
            CardNumber = cardNumber;
            Pin = pin;
        }
    }
    class AdminLogin
    {
        public string Name;
        public string UserName;
        public string Password;
        public AdminLogin(string name,string username,string password)
        {
            Name = name;
            UserName = username;
            Password = password;
        }
    }
    class Program
    {
        public static double bill;
        public static double FinalBill;
        public static List<UserLogin> userDetails = new List<UserLogin>();
        public static List<AdminLogin> adminDetails = new List<AdminLogin>();
        public static List<OrderedProduct> order = new List<OrderedProduct>();
        public static List<GivenRating> ratings = new List<GivenRating>();
        public static List<Bill> finalBill = new List<Bill>(); 
        public static List<int> discount_amount =  new List<int>{ 5, 10, 20, 30, 50 };
        public static List<string> discount_price = new List<string>{ "500", "1000", "1500", "2000", "3000" };
        public static List<product> p1 = new List<product>();
        static void Main(string[] args)
        {
            loadItems();
            loadData();
            loadBills();
            loadAdminData();
            loadReview();
            begin();
        }
        static void begin()
        {
            firstPage();
            Console.SetCursorPosition(64, 33);
            Console.Write("Enter any key:");
            Console.ReadKey();
            home();
            homeDeatails();
        }
        static void userLogin() ////////////////// for creating user account or signing in
        {
            bool decision;
            int choice;
            Console.SetCursorPosition(54, 38);
            Console.Write("Enter your choice:");
            
            choice = int.Parse(Console.ReadLine());
            if (choice == 2)
            {
                Console.SetCursorPosition(54, 39);
                Console.Write("Enter your new name :");
                string name = Console.ReadLine();
                Console.SetCursorPosition(54, 40);
                Console.Write("Enter your new user name: ");
                string userName = Console.ReadLine();
                Console.SetCursorPosition(54, 41);
                Console.Write("Enter your new password: ");
                string password = Console.ReadLine();
                int n = password.Length;
                if (n >= 8)
                {
                    Console.SetCursorPosition(54, 42);
                    Console.Write("Enter your credit card number:");
                        int cardNumber = int.Parse(Console.ReadLine());
                    Console.SetCursorPosition(54, 43);
                    Console.Write("Enter your credit card pin:");
                        int pin = int.Parse(Console.ReadLine());
                        decision = isvaliduser(userName);
                        if (decision == true)
                        {
                        storeInFile(name, userName, password, cardNumber, pin);
                        UserLogin b = new UserLogin(name,userName,password,cardNumber,pin);
                        userDetails.Add(b);
                        Console.SetCursorPosition(54, 44);
                        Console.WriteLine("User Created Sucessfully");
                        Console.SetCursorPosition(54, 45);
                        Console.Write("Enter any key to continue:");
                        Console.ReadKey();
                        usEr();
                        userLogin();
                        }
                        else
                        {
                        Console.SetCursorPosition(54, 44);
                        Console.WriteLine("User Already exist");
                        Console.SetCursorPosition(54, 45);
                        Console.WriteLine("Enter any key to continue:");
                            Console.ReadKey();
                            Console.Clear();
                            usEr();
                            userLogin();
                        }
                }
                else
                {
                    Console.SetCursorPosition(54, 42);
                    Console.WriteLine("Your password should contain at least 8 or more characters");
                    Console.SetCursorPosition(54, 43);
                    Console.Write("Enter any key to continue...");
                    Console.Clear();
                    usEr();
                    userLogin();
                }
            }
            else if (choice == 1)
            {
                string userName;
                string password;
                Console.SetCursorPosition(54, 39);
                Console.Write("Enter your username : ");
                userName = Console.ReadLine();
                Console.SetCursorPosition(54, 40);
                Console.Write("Enter the password : ");
                password = Console.ReadLine();
                decision = signin(userName, password);
                if (decision == true)
                {
                    Console.SetCursorPosition(54, 42);
                    Console.WriteLine("Login Sucessfully !");
                    Console.SetCursorPosition(54, 43);
                    Console.Write("Enter any key to continue:");
                    Console.Clear();
                    userFunctionalities();
                }
                else
                {
                    Console.SetCursorPosition(54, 42);
                    Console.WriteLine("Invalid Credentials !");
                    Console.SetCursorPosition(54, 43);
                    Console.Write("Enter any key to continue:");
                    Console.ReadKey();
                    usEr();
                    userLogin();
                    Console.ReadKey();
                }
            }
            else
            { 
                Console.WriteLine("Invalid choice.Try Again!");
                Console.SetCursorPosition(54, 39);
                Console.Write("Enter any key to continue...");
                Console.SetCursorPosition(54, 40);
                Console.Clear();
                Console.Clear();
                usEr();
                userLogin();
            }
        }
        static void logo() /////////////////////// header of pages
        {
            Console.WriteLine(" ______________________________________________________________________________________________________________________________________________");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|____|____________________________________________________________________________________________________________________________________|____|");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                       WELCOME TO                                                                   |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                       /$$$$$$             /$$$$$$            /$$                         /$$                                       |    |");
            Console.WriteLine("|    |                      /$$__  $$           /$$__  $$          | $$                        |__/                                       |    |");
            Console.WriteLine("|    |                     | $$  |__/  /$$$$$$ | $$  |__//$$$$$$  /$$$$$$    /$$$$$$   /$$$$$$  /$$  /$$$$$$                              |    |");
            Console.WriteLine("|    |                     | $$       |____  $$| $$$$   /$$__  $$|_  $$_/   /$$__  $$ /$$__  $$| $$ |____  $$                             |    |");
            Console.WriteLine("|    |                     | $$        /$$$$$$$| $$_/  | $$$$$$$$  | $$    | $$$$$$$$| $$  |__/| $$  /$$$$$$$                             |    |");
            Console.WriteLine("|    |                     | $$    $$ /$$__  $$| $$    | $$_____/  | $$ /$$| $$_____/| $$      | $$ /$$__  $$                             |    |");
            Console.WriteLine("|    |                     |  $$$$$$/|  $$$$$$$| $$    |  $$$$$$$  |  $$$$/|  $$$$$$$| $$      | $$|  $$$$$$$                             |    |");
            Console.WriteLine("|    |                     | ______/ |_______/|__/     |_______/   |___/   |_______/ |__/       |__/ |_______                             |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|____|____________________________________________________________________________________________________________________________________|____|");
        }
        static void payment() ////////////////////// Payement method selection
        {
            Console.Clear();
            logo();
            grid2();
            Console.SetCursorPosition(60, 20);
            Console.WriteLine(" How do you want to pay?");
            Console.SetCursorPosition(64, 22);
            Console.WriteLine("    _______ ");
            Console.SetCursorPosition(64, 23);
            Console.WriteLine(" 1-| Cash  |");
            Console.SetCursorPosition(64, 24);
            Console.WriteLine("    __________ ");
            Console.SetCursorPosition(64, 25);
            Console.WriteLine(" 2-| Credit Card |");
            Console.SetCursorPosition(64, 26);
            Console.WriteLine("    _____________ ");
            Console.SetCursorPosition(64, 27);
            Console.WriteLine(" 3-| Cancel Order |");
        }
        static void dine() /////////////////////////// Meal serving selection
        {
            Console.Clear();
            logo();
            grid2();
            Console.SetCursorPosition(60, 20);
            Console.WriteLine("How do you want your meal to be served?");
            Console.SetCursorPosition(64, 22);
            Console.WriteLine("   ___________");
            Console.SetCursorPosition(64, 23);
            Console.WriteLine("1-| Take away |");
            Console.SetCursorPosition(64, 24);
            Console.WriteLine("    _________ ");
            Console.SetCursorPosition(64, 25);
            Console.WriteLine("2-| Dine in |");
            Console.SetCursorPosition(64, 26);
            Console.WriteLine("    ________");
            Console.SetCursorPosition(64, 27);
            Console.WriteLine("3-| Delivery |");
        }
        static void grid()
        {
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                       ______________________________________________________________                               |    |");
            Console.WriteLine("|    |                                      |        .s5ssSs.                                              |                              |    |");
            Console.WriteLine("|    |                                      |           SS SS.  .s5SSSs.   .s    s.   .s    s.             |                              |    |");
            Console.WriteLine("|    |                                      |        sS SS S%S        SS.  sS    SS.  sS    SS.            |                              |    |");
            Console.WriteLine("|    |                                      |        SS :; S%S  sS    `:;  sSs.  S%S  sS    S%S            |                              |    |");
            Console.WriteLine("|    |                                      |        SS    S%S  SSSs.      SS `S.S%S  SS    S%S            |                              |    |");
            Console.WriteLine("|    |                                      |        SS    S%S  SS         SS  `sS%S  SS    S%S            |                              |    |");
            Console.WriteLine("|    |                                      |        SS    `:;  SS         SS    `:;  SS    `:;            |                              |    |");
            Console.WriteLine("|    |                                      |        SS    ;,.  SS    ;,.  SS    ;,.  SS    ;,.            |                              |    |");
            Console.WriteLine("|    |                                      |        :;    ;:'  `:;;;;;:'  :;    ;:'  `:;;;;;:'            |                              |    |");
            Console.WriteLine("|    |                                      |______________________________________________________________|                              |    |");
            Console.WriteLine("|    |                                      |                                                              |                              |    |");
            Console.WriteLine("|    |                                      |                                                              |                              |    |");
            Console.WriteLine("|    |                                      |                                                              |                              |    |");
            Console.WriteLine("|    |                                      |                                                              |                              |    |");
            Console.WriteLine("|    |                                      |                                                              |                              |    | ");
            Console.WriteLine("|    |                                      |                                                              |                              |    | ");
            Console.WriteLine("|    |                                      |                                                              |                              |    | ");
            Console.WriteLine("|    |                                      |                                                              |                              |    |");
            Console.WriteLine("|    |                                      |                                                              |                              |    | ");
            Console.WriteLine("|    |                                      |                                                              |                              |    | ");
            Console.WriteLine("|    |                                      |                                                              |                              |    | ");
            Console.WriteLine("|    |                                      |                                                              |                              |    |");
            Console.WriteLine("|    |                                      |                                                              |                              |    | ");
            Console.WriteLine("|    |                                      |                                                              |                              |    | ");
            Console.WriteLine("|    |                                      |                                                              |                              |    | ");
            Console.WriteLine("|    |                                      |                                                              |                              |    | ");
            Console.WriteLine("|    |                                      |                                                              |                              |    | ");
            Console.WriteLine("|    |                                      |                                                              |                              |    | ");
            Console.WriteLine("|    |                                      |                                                              |                              |    | ");
            Console.WriteLine("|    |                                      |                                                              |                              |    | ");
            Console.WriteLine("|    |                                      |                                                              |                              |    | ");
            Console.WriteLine("|    |                                      |______________________________________________________________|                              |    | ");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|____|____________________________________________________________________________________________________________________________________|____|");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|____|____________________________________________________________________________________________________________________________________|____|");
        }
        static void grid2()
        {
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|____|____________________________________________________________________________________________________________________________________|____|");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|____|____________________________________________________________________________________________________________________________________|____|");
        }
        static void usEr() ////////////////////////// Page for user login
        {
            Console.Clear();
            logo();
            Console.WriteLine("|    |                                                               (CUSTOMER PAGE)                                                      |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            welcomeLogo();
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                1-  Sign-in (If already a user)                                                     |    |");
            Console.WriteLine("|    |                                                2-  sign-up (If new user)                                                           |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|____|____________________________________________________________________________________________________________________________________|____|");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|____|____________________________________________________________________________________________________________________________________|____|");
        }
        static void welcomeLogo()
        {
            Console.WriteLine("|    |                                   d  d  b  d sss    d        sSSs.   sSSSs    d s   sb  d sss                                      |    |");
            Console.WriteLine("|    |                                   S  S  S  S        S       S       S     S   S  S S S  S                                          |    |");
            Console.WriteLine("|    |                                   S  S  S  S        S      S       S       S  S   S  S  S                                          |    |");
            Console.WriteLine("|    |                                   S  S  S  S sSSs   S      S       S       S  S      S  S sSSs                                     |    | ");
            Console.WriteLine("|    |                                   S  S  S  S        S      S       S       S  S      S  S                                          |    | ");
            Console.WriteLine("|    |                                   S  S  S  S        S       S       S     S   S      S  S                                          |    | ");
            Console.WriteLine("|    |                                      ss S  P sSSss  P sSSs    sss     sss     P      P  P sSSss                                    |    |");
        }
        static bool isvaliduser(string userName) ///////////////////// to check validity of username
        {
            bool flag = true;
            for (int idx = 0; idx < userDetails.Count(); idx++)
            {
                if (userDetails[idx].Name == userName)
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        static void storeInFile(string user, string userName, string password, int cardNumber, int pin) //////////// for storing users info in file
        {
            string path = "user.txt";
            StreamWriter gross = new StreamWriter(path, true);
            gross.WriteLine(user + "," + userName + "," + password + "," + cardNumber + "," + pin);
            gross.Flush();
            gross.Close();
        }
        static bool signin(string userName, string password) /////////////////// for checking sigining in
        {
            bool flag = false;
            for (int idx = 0; idx < userDetails.Count(); idx++)
            {
                if (userDetails[idx].Name == userName && userDetails[idx].Password == password)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        static void userFunctionalities() //////////////////// Functionalities of User
        {
            Console.Clear();
            logo();
            Console.WriteLine("|    |                                                               (User Menu)                                                          |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            welcomeLogo();
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                             _____________________________________                                                  |    |");
            Console.WriteLine("|    |                                            |                                     |                                                 |    |");
            Console.WriteLine("|    |                                            |         1- Check Menu               |                                                 |    |");
            Console.WriteLine("|    |                                            |         2- Buy food item            |                                                 |    |");
            Console.WriteLine("|    |                                            |         3- View Cart                |                                                 |    |");
            Console.WriteLine("|    |                                            |         4- Delete item from cart    |                                                 |    |");
            Console.WriteLine("|    |                                            |         5- Check out                |                                                 |    |");
            Console.WriteLine("|    |                                            |         6- Give a review            |                                                 |    |");
            Console.WriteLine("|    |                                            |         7- Change Theme             |                                                 |    |");
            Console.WriteLine("|    |                                            |         8- Logout                   |                                                 |    |");
            Console.WriteLine("|    |                                            |_____________________________________|                                                 |    |");
            Console.WriteLine("|    |                                               Enter 0 to return to previous page                                                   |    |");
            Console.WriteLine("|    |                                                Enter 99 to return to main menu                                                     |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|____|____________________________________________________________________________________________________________________________________|____|");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|____|____________________________________________________________________________________________________________________________________|____|");
            Console.SetCursorPosition(50,50);
            Console.Write("Enter your choice:");
            int choice;
            while (true)
            {
                choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    viewMenu();
                }
                else if (choice == 2)
                {
                    menu();
                    menuDetails();
                }
                else if (choice == 3)
                {
                    viewCart();
                }
                else if (choice == 4)
                {
                    deleteItemFromCart();
                }
                else if (choice == 5)
                {
                    calculateBill();
                }
                else if (choice == 6)
                {
                    feedBack();
                }
                else if (choice == 7)
                {
                    changeTheme();
                }
                else if (choice == 8)
                {
                    begin();
                }
                else if (choice == 0)
                {
                    usEr();
                }
                else if (choice == 99)
                {
                    begin();
                }
                else
                {
                    Console.WriteLine("Invalid choice.Try again!");
                    Console.Write("Enter any key to continue...");
                    Console.ReadKey();
                    userFunctionalities();
                }
            }
        }
        static void viewMenu() /////////////////// for checking menu
        {
            Console.Clear();
            logo();
            grid();
            for (int idx = 0; idx < p1.Count(); idx++)
            {
                int n = idx + 1;
                Console.SetCursorPosition(60, 33 + n);
                Console.WriteLine(1 + idx + "-" + p1[idx].itemName);
                Console.SetCursorPosition(80, 33 + n);
                Console.WriteLine(p1[idx].itemRate);
            }
            Console.SetCursorPosition(56, 55);
            Console.WriteLine("Enter any key to reutrn to previous section");
            Console.ReadKey();
            userFunctionalities();
        }
        static void viewCart() ///////////////////////// for viewing items present in cart
        {
            Console.Clear();
            logo();
            grid2();
            Console.SetCursorPosition(35, 25);
            Console.WriteLine("Item Name" + '\t' + '\t' + '\t' + "Item quantity");
            for (int x = 0; x < order.Count(); x++)
            {
                Console.SetCursorPosition(35, 27 + x);
                Console.WriteLine(x + 1 + "-" + order[x].Name);
                Console.SetCursorPosition(70, 27 + x);
                Console.WriteLine(order[x].Quantity);
            }
            Console.SetCursorPosition(35, 40);
            Console.WriteLine("Enter any key to return to previos section:");
            Console.ReadKey();
            userFunctionalities();
        }
        static void deleteItemFromCart() //////////////// for deleting items from cart
        {
            Console.Clear();
            logo();
            grid2();
            Console.SetCursorPosition(35, 25);
            Console.WriteLine("Item Name" + '\t' + '\t' + '\t' + "Item quantity");
            for (int x = 0; x < order.Count(); x++)
            {
                Console.SetCursorPosition(35, 27 + x);
                Console.WriteLine(x + 1 + "-" + order[x].Name);
                Console.SetCursorPosition(70, 27 + x);
                Console.WriteLine(order[x].Quantity);
            }
            int num;
            Console.SetCursorPosition(50, 40);
            Console.Write("Enter the item you want to delete:");
            num = int.Parse(Console.ReadLine());
            if (num <= order.Count())
            {
                for (int idx = num - 1; idx < order.Count(); idx++)
                {
                    order.RemoveAt(num-1);
                }
                Console.SetCursorPosition(50, 42);
                Console.Write("Enter any key to return to previos secion:");
                Console.ReadKey();
                userFunctionalities();
            }
            else
            {
                Console.WriteLine("Enter correct number...");
                Console.Write("Enter any key to continue...");
                Console.ReadKey();
                deleteItemFromCart();
            }
        }
        static void adminLogin() /////////////////////// for admin login
        {
            bool flag;
            string adminName;
            string adminPassword;
            Console.SetCursorPosition(60, 37);
            Console.Write("Enter your email:");
            adminName = Console.ReadLine();
            Console.SetCursorPosition(60, 38);
            Console.Write("Enter your password:");
            adminPassword = Console.ReadLine();
            flag = AdminSignin(adminName, adminPassword);
            if (adminName == "burhan" && adminPassword == "123")
            {
                Console.WriteLine("Access granted");
                adminFunctionalities();
            }
            else if (flag == true)
            {
                Console.WriteLine("Access granted");
                adminFunctionalities();
            }
            else
            {
                Console.SetCursorPosition(60, 40);
                Console.WriteLine("Access denied");
                Console.SetCursorPosition(60, 41);
                Console.WriteLine("Incorrect credentials.Try again!");
                Console.SetCursorPosition(60, 42);
                Console.Write("Enter any key to continue:");
                Console.ReadKey();
                admin();
                adminLogin();
            }
        }
        static bool AdminSignin(string adminName, string adminPassword) /////////////////// for checking sigining in
        {
            bool flag = false;
            for (int idx = 0; idx < adminDetails.Count(); idx++)
            {
                if (adminDetails[idx].UserName == adminName && adminDetails[idx].Password == adminPassword)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        static void admin() ////////////////////// Admin login page
        {
            Console.Clear();
            logo();
            Console.WriteLine("|    |                                                               (ADMIN PAGE)                                                         |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            welcomeLogo();
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                1-  Enter your email    : __________________________                                |    |");
            Console.WriteLine("|    |                                                2-  Enter your password : __________________________                                |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|____|____________________________________________________________________________________________________________________________________|____|");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|____|____________________________________________________________________________________________________________________________________|____|");
        }
        static void adminFunctionalities() //////////////////// Functionalities of Admin
        {
            Console.Clear();
            logo();
            Console.WriteLine("|    |                                                               (Admin Menu)                                                         |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            welcomeLogo();
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                             _____________________________________                                                  |    |");
            Console.WriteLine("|    |                                            |                                     |                                                 |    |");
            Console.WriteLine("|    |                                            |     1- Check Menu                   |                                                 |    |");
            Console.WriteLine("|    |                                            |     2- Check Given Discounts        |                                                 |    |");
            Console.WriteLine("|    |                                            |     3- Add New food item            |                                                 |    |");
            Console.WriteLine("|    |                                            |     4- Delete food item             |                                                 |    |");
            Console.WriteLine("|    |                                            |     5- Change rates of products     |                                                 |    |");
            Console.WriteLine("|    |                                            |     6- View customers rating        |                                                 |    |");
            Console.WriteLine("|    |                                            |     7- Check Users                  |                                                 |    |");
            Console.WriteLine("|    |                                            |     8- View Completed Bills         |                                                 |    |");
            Console.WriteLine("|    |                                            |     9- Add new Admin                |                                                 |    |");
            Console.WriteLine("|    |                                            |    10- View all Admins              |                                                 |    |");
            Console.WriteLine("|    |                                            |    11- Logout                       |                                                 |    |");
            Console.WriteLine("|    |                                            |_____________________________________|                                                 |    |");
            Console.WriteLine("|    |                                               Enter 0 to return to previos page                                                    |    |");
            Console.WriteLine("|    |                                                Enter 99 to return to main menu                                                     |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|____|____________________________________________________________________________________________________________________________________|____|");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|    |                                                                                                                                    |    |");
            Console.WriteLine("|____|____________________________________________________________________________________________________________________________________|____|");

            Console.SetCursorPosition(59, 49);
            string choice;
            while (true)
            {
                Console.Write("Enter your choice:");
                choice = Console.ReadLine();
                if (choice == "3")
                {
                    addingItem();
                }
                else if (choice == "1")
                {
                    checkMenu();
                }
                else if (choice == "4")
                {
                    deletingItem();
                }
                else if (choice == "5")
                {
                    changingRates();
                }
                else if (choice == "7")
                {
                    viewUsers();
                }
                else if (choice == "11")
                {
                    begin();
                }
                else if (choice == "9")
                {
                    createAdmin();
                }
                else if (choice == "10")
                {
                    viewAdmins();
                }
                else if (choice == "8")
                {
                    viewBills();
                }
                else if (choice == "0")
                {
                    admin();
                    adminLogin();
                }
                else if (choice == "2")
                {
                    discounts();
                }
                else if (choice == "99")
                {
                    begin();
                }
                else if (choice == "6")
                {
                    viewFeedback();
                }
                else
                {
                    Console.SetCursorPosition(59, 50);
                    Console.WriteLine("Invalid Input.Try again!");
                    Console.SetCursorPosition(59, 51);
                    Console.WriteLine("Enter any key to continue:");
                    Console.ReadKey();
                    adminFunctionalities();
                }
            }
        }
        static void deletingItem() ///////////////////////// Deleting any item of menu
        {
            Console.Clear();
            logo();
            grid2();
            for (int idx = 0; idx < p1.Count(); idx++)
            {
                int n = idx + 1;
                Console.SetCursorPosition(60, 20 + n);
                Console.WriteLine(n + "-" + p1[idx].itemName);
                Console.SetCursorPosition(85, 20 + n);
                Console.WriteLine(p1[idx].itemRate);
            }
            if (p1.Count() == 0)
            {
                Console.SetCursorPosition(50, 25);
                Console.WriteLine("There is no item in the menu currently.");
                Console.SetCursorPosition(55, 26);
                Console.Write("Enter any key to continue...");
                Console.ReadKey();
            }
            else
            {
                int num;
                Console.SetCursorPosition(55, 44);
                Console.Write("Enter the number of item you want to delete:");
                num = int.Parse(Console.ReadLine());
                if (num > 0 && num <= p1.Count())
                {
                    p1.RemoveAt(num - 1);
                    deleteItems_fromFile(p1);
                    Console.SetCursorPosition(57, 46);
                    Console.Write("Enter any key to return to previos secion:");
                    Console.ReadKey();
                    adminFunctionalities();
                }
                else
                {
                    Console.SetCursorPosition(55, 45);
                    Console.WriteLine("Enter correct number...");
                    Console.SetCursorPosition(55, 46);
                    Console.Write("Enter any key to continue...");
                    Console.ReadKey();
                    deletingItem();
                }
            }
        }
        static void addingItem() ///////////////////////// Adding new Item to Menu
        {
            string name;
            float price;
            Console.Clear();
            product obj = new product();
            Console.Write("Enter new food item:");
            obj.itemName = Console.ReadLine();
            Console.Write("Enter price of item:");
            obj.itemRate = int.Parse(Console.ReadLine());
            name = obj.itemName;
            price = obj.itemRate;
            if (obj.itemRate > 0)
            {
                p1.Add(obj);
                storeItems(name, price);
                Console.Write("Enter any key to return to previos secion:");
                Console.ReadKey();
                adminFunctionalities();
            }
            else
            {
                Console.WriteLine("Enter correct price:");
                Console.Write("Enter any key to continue...");
                Console.ReadKey();
                addingItem();
            }
        }
        static void changingRates() //////////////////// Changing rate of products
        {
            Console.Clear();
            logo();
            grid();
            for (int idx = 0; idx < p1.Count(); idx++)
            {
                int n = idx + 1;
                Console.SetCursorPosition(60, 33 + n);
                Console.WriteLine(n + "-" + p1[idx].itemName);
                Console.SetCursorPosition(80, 33 + n);
                Console.WriteLine(p1[idx].itemRate);
            }
            int num;
            int new_rate;
            string name;
            if (p1.Count() == 0)
            {
                Console.SetCursorPosition(50, 25);
                Console.WriteLine("There is no item in the menu currently.");
                Console.SetCursorPosition(50, 26);
                Console.Write("Enter any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.SetCursorPosition(50, 55);
                Console.Write("Enter the number of item you want to change price:");
                num = int.Parse(Console.ReadLine());
                if (num > 0 && num <= p1.Count())
                {
                    Console.SetCursorPosition(70, 50);
                    Console.Write("Enter new Name: ");
                    name = Console.ReadLine();
                    Console.SetCursorPosition(70, 51);
                    Console.Write("Enter new rate:");
                    new_rate = int.Parse(Console.ReadLine());
                    p1[num - 1].itemName = name;
                    p1[num - 1].itemRate = new_rate;
                    UpdateItems_fromFile(p1);
                    Console.SetCursorPosition(55, 52);
                    Console.Write("Enter any key to return to previos secion:");
                    Console.ReadKey();
                    adminFunctionalities();
                }
                else
                {
                    Console.SetCursorPosition(46, 48);
                    Console.WriteLine("Invalid choice");
                    Console.SetCursorPosition(46, 49);
                    Console.Write("Enter any key to continue");
                    Console.ReadKey();
                    changingRates();
                }
            }
        }
        static void checkMenu() /////////////////// for checking menu
        {
            Console.Clear();
            logo();
            grid();
            for (int idx = 0; idx < p1.Count(); idx++)
            {
                int n = idx + 1;
                Console.SetCursorPosition(60, 33 + n);
                Console.WriteLine(n + "-" + p1[idx].itemName);
                Console.SetCursorPosition(80, 33 + n);
                Console.WriteLine(p1[idx].itemRate);
            }
            Console.SetCursorPosition(56, 55);
            Console.Write("Enter any key to return to previous menu");
            Console.ReadKey();
            adminFunctionalities();
            Console.ReadKey();
        }
        static void storeItems(string name, float price) ///////////////// for storing items
        {
            string path = "data.txt";
            StreamWriter gross = new StreamWriter(path, true);
            gross.WriteLine(name + "," + price);
            gross.Flush();
            gross.Close();
        }
        static void loadItems() ////////////////// for loading items
        {
            string path = "data.txt";
            if (File.Exists(path))
            {
                StreamReader fp = new StreamReader(path);
                string word;
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
                gross.WriteLine(p1[idx].itemName + "," + p1[idx].itemRate);
                gross.Flush();
            }
            gross.Close();
        }
        static void viewUsers() /////////////////// for viewing all users
        {
            Console.Clear();
            logo();
            grid2();
            for (int idx = 0; idx < userDetails.Count(); idx++)
            {
                Console.SetCursorPosition(65, 22 + idx);
                Console.WriteLine(idx + 1 + "-" + userDetails[idx].Name);
            }
            Console.SetCursorPosition(65, 40);
            Console.Write("Enter any key to continue...");
            Console.ReadKey();
            adminFunctionalities();
        }
        static void createAdmin()
        {
            bool decision;
            string adminName;
            string admin;
            string adminPassword;
            Console.Clear();
            logo();
            grid2();
            Console.SetCursorPosition(54, 27);
            Console.Write("Enter your first name:");
            admin = Console.ReadLine();
            Console.SetCursorPosition(54, 28);
            Console.Write("Enter your username:");
            adminName = Console.ReadLine();
            Console.SetCursorPosition(54, 29);
            Console.Write("Enter the password:");
            adminPassword = Console.ReadLine();
            int n = adminPassword.Length;
            if (n >= 8)
            {
                decision = isvalidAdmin(adminName);
                if (decision == true)
                {
                    AdminLogin b = new AdminLogin(admin,adminName,adminPassword);
                    adminDetails.Add(b);
                    storeAdminData(admin, adminName, adminPassword);
                    Console.SetCursorPosition(54, 31);
                    Console.Write("Admin Created Sucessfully");
                    Console.SetCursorPosition(54, 32);
                    Console.Write("Enter any key to continue:");
                    Console.ReadKey();
                    adminFunctionalities();
                }
                else
                {
                    Console.SetCursorPosition(54, 30);
                    Console.WriteLine("Admin Already exist");
                    Console.SetCursorPosition(54, 31);
                    Console.WriteLine("Enter any key to continue:");
                    Console.ReadKey();
                    Console.Clear();
                    createAdmin();
                }
            }

            else
            {
                Console.SetCursorPosition(38, 31);
                Console.WriteLine("Your password should contain at least 8 or more characters");
                Console.SetCursorPosition(48, 32);
                Console.Write("Enter any key to continue...");
                Console.ReadKey();
                createAdmin();
            }
        }
        static bool isvalidAdmin(string adminName) ///////////////////// to check validity of adminName
        {
            bool flag = true;
            for (int idx = 0; idx < adminDetails.Count(); idx++)
            {
                if (adminDetails[idx].Name == adminName)
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        static void storeAdminData(string admin, string adminName, string adminPassword) //////////// for storing users info in file
        {
            string path = "admin.txt";
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(admin + "," + adminPassword + "," + adminName);
            file.Flush();
            file.Close();
        }
        static void loadAdminData() /////////////// for loading user's data from file
        {
            string path = "admin.txt";
            StreamReader fp = new StreamReader(path);
            string word;
            while ((word = fp.ReadLine()) != null)
            {
                string username = parsItems(word, 1);
                string password = parsItems(word, 2);
                string name = parsItems(word, 3);
                AdminLogin data = new AdminLogin(name,username,password);
                adminDetails.Add(data);
            }
            fp.Close();
        }
        static void viewAdmins() /////////////////// for viewing all users
        {
            Console.Clear();
            logo();
            grid2();
            for (int idx = 0; idx < adminDetails.Count(); idx++)
            {
                Console.SetCursorPosition(65, 22 + idx);
                Console.WriteLine(idx + 1 + "- " + adminDetails[idx].Name);
            }
            Console.SetCursorPosition(65, 40);
            Console.Write("Enter any key to continue...");
            Console.ReadKey();
            adminFunctionalities();
        }
        static void viewBills() ////////////////////// for viewing customer's bill
        {
            Console.Clear();
            logo();
            grid2();
            for (int idx = 0; idx < ratings.Count(); idx++)
            {
                Console.SetCursorPosition(50, 25 + idx);
                Console.WriteLine(idx + 1 + "-" + ratings[idx].Name + " order was of " + finalBill[idx].FinalBill + "/- rupees");
            }
            Console.SetCursorPosition(50, 40);
            Console.Write("Enter any key to continue...");
            Console.ReadKey();
            adminFunctionalities();
        }
        static void firstPage() /////////////// First page of application
        {
            Console.Clear();
            logo();
            grid2();
            Console.SetCursorPosition(60, 32);
            Console.WriteLine("Press any key to continue:");
        }
        static void menu() //////////////////////// For Displaying Menu
        {
            Console.Clear();
            logo();
            grid();
            for (int idx = 0; idx < p1.Count(); idx++)
            {
                int n = idx + 1;
                Console.SetCursorPosition(60, 33 + n);
                Console.WriteLine(n + "-" + p1[idx].itemName);
                Console.SetCursorPosition(80, 33 + n);
                Console.WriteLine(p1[idx].itemRate);
                Console.SetCursorPosition(60, 47);
                Console.WriteLine("Enter 0 to end buying");
            }
        }
        static void menuDetails() ///////////////////// for buying items
        {
            int choice = 1;
            while (choice != 0)
            {
                Console.SetCursorPosition(48, 50);
                Console.Write("Which item do you want to buy?(Enter item's number):");
                choice = int.Parse(Console.ReadLine());
                if (choice > 0 && choice <= p1.Count())
                {
                    string name = p1[choice - 1].itemName;
                    int rate = p1[choice - 1].itemRate;
                    if (choice <= p1.Count())
                    {
                        if (choice != 0)
                        {
                            Console.SetCursorPosition(48, 52);
                            Console.Write("Enter quantity:");
                            int quantity = int.Parse(Console.ReadLine());
                            OrderedProduct o = new OrderedProduct(name,rate,quantity);
                            order.Add(o);
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(53, 51);
                        Console.WriteLine("Enter correct item number...");
                        Console.SetCursorPosition(53, 52);
                        Console.Write("Enter any key to continue...");
                        Console.ReadKey();
                        menu();
                        menuDetails();
                    }
                }
            }
            userFunctionalities();
        }
        static void end() //////////////////////////// ending lines of program
        {
            Console.SetCursorPosition(60, 36);
            Console.WriteLine("Thank you for using our service!");
            Console.SetCursorPosition(60, 37);
            Console.WriteLine("Wishing you  a great day!");
            Console.SetCursorPosition(60, 38);
            Console.WriteLine(":)");
        }
        static void calculateDiscount() /////////////////////// callculating discounts
        {
            double discountBill;
            if (FinalBill <= 1000)
            {
                Console.SetCursorPosition(60, 32);
                Console.WriteLine("Your are given 5% discount...");
                discountBill = FinalBill * 5 / 100;
                FinalBill = FinalBill - discountBill;
            }
            else if (FinalBill > 1000 && FinalBill <= 1500)
            {
                Console.SetCursorPosition(60, 32);
                Console.WriteLine("Your are given 10% discount...");
                discountBill = FinalBill * 10 / 100;
                FinalBill = FinalBill - discountBill;
            }
            else if (FinalBill > 1500 && FinalBill <= 2000)
            {
                Console.SetCursorPosition(60, 32);
                Console.WriteLine("Your are given 20% discount...");
                discountBill = FinalBill * 20 / 100;
                FinalBill = FinalBill - discountBill;
            }
            else if (FinalBill > 2000 && FinalBill <= 3000)
            {
                Console.SetCursorPosition(60, 32);
                Console.WriteLine("Your are given 30% discount...");
                discountBill = FinalBill * 30 / 100;
                FinalBill = FinalBill - discountBill;
            }
            else if (FinalBill > 3000)
            {
                Console.SetCursorPosition(60, 32);
                Console.WriteLine("Your are given 40% discount...");
                discountBill = FinalBill * 40 / 100;
                FinalBill = (FinalBill) - (discountBill);
            }
        }
        static void feedBack() ////////////////////////////////// for user's feedback
        {
            Console.Clear();
            string ratingName;
            int review;
            logo();
            grid2();
            Console.SetCursorPosition(55, 30);
            Console.Write("Please enter your name:");
            ratingName = Console.ReadLine();
            Console.SetCursorPosition(55, 32);
            Console.Write("Please give us a rating for our service ;)");
            Console.SetCursorPosition(55, 33);
            Console.Write("Enter your rating from 1 to 5:");
            review = int.Parse(Console.ReadLine());
            if (review > 0 && review < 6)
            {
                GivenRating g = new GivenRating(ratingName, review);
                ratings.Add(g);
                storeReview(ratingName, review);
                loadReview();
                end();
                Console.SetCursorPosition(60, 41);
                Console.Write("Enter any key to continue...");
                Console.ReadKey();
                userFunctionalities();
            }
            else
            {
                Console.SetCursorPosition(55, 35);
                Console.Write("Please enter rating according to given range...");
                Console.SetCursorPosition(55, 36);
                Console.Write("Enter any key to continue...");
                Console.ReadKey();
                feedBack();
            }
        }
        static double calculateBill() //////////////////////// calculating bill
        {
            string choice;
            for (int idx = 0; idx < order.Count(); idx++)
            {
                Bill b = new Bill();
                bill = (order[idx].Rate) * order[idx].Quantity;
                FinalBill = (FinalBill) + bill;
                b.FinalBill = FinalBill;
                finalBill.Add(b);
                storeBills();
            }
            dine();
            Console.SetCursorPosition(60, 29);
            Console.Write("Enter your choice:");
            choice = Console.ReadLine();
            if (choice == "1")
            {
                dineFeatures();
            }
            else if (choice == "2")
            {
                dineFeatures();
            }
            else if (choice == "3")
            {
                Console.SetCursorPosition(60, 30);
                Console.Write("Enter delivery address:");
                string Address = Console.ReadLine();
                Console.SetCursorPosition(60, 31);
                Console.WriteLine("Your order has been placed.");
                Console.SetCursorPosition(60, 32);
                Console.WriteLine("Your bill is:{0}", FinalBill);
                Console.SetCursorPosition(60, 33);
                Console.WriteLine("Your order will be delievered within 30 minutes.");
                end();
                Console.SetCursorPosition(60, 40);
                Console.Write("Enter any key to continue...");
                Console.ReadKey();
                home();
                homeDeatails();
            }
            return FinalBill;
        }
        static void storeReview(string ratingName, int review) ////////////////////// for storing customer's review
        {
            string path = "rating.txt";
            StreamWriter gross = new StreamWriter(path, true);
            gross.WriteLine(ratingName + "," + review);
            gross.Flush();
            gross.Close();
        }
        static void loadReview() ////////////////////// for loading customer's review
        {
            string path = "rating.txt";
            StreamReader fp = new StreamReader(path);
            string word;
            while ((word = fp.ReadLine()) != null)
            {
                string name = parsItems(word, 1);
                int review = int.Parse((parsItems(word, 2)));
                GivenRating obj = new GivenRating(name, review);
                ratings.Add(obj);
            }
            fp.Close();
        }
        static void storeBills() ////////////////////// for storing customer's bill
        {
            string path = "bills.txt";
            StreamWriter gross = new StreamWriter(path, true);
            gross.WriteLine(FinalBill);
            gross.Flush();
            gross.Close();
        }
        static void loadBills() ////////////////////// for loading customer's bill
        {
            string path = "bills.txt";
            StreamReader fp = new StreamReader(path);
            string word;
            while ((word = fp.ReadLine()) != null)
            {
                Bill bill = new Bill();
                bill.FinalBill = float.Parse(parsItems(word, 1));
                finalBill.Add(bill);
            }
            fp.Close();
        }
        static void discounts() //////////////////////////// for checking given discounts
        {
            Console.Clear();
            logo();
            grid2();
            for (int idx = 0; idx < 5; idx++)
            {
                int n = idx + 1;
                Console.SetCursorPosition(40, 25 + n);
                Console.WriteLine(n + "'-'" + discount_amount[idx] + "% discount on total bill if purchase is above" + discount_price[idx]);
            }
            Console.SetCursorPosition(42, 36);
            Console.Write("Enter any key to return to previous menu...");
            Console.ReadKey();
            adminFunctionalities();
        }
        
        static void viewFeedback() ////////////////////////// for viewing feedback od customers
        {
            Console.Clear();
            logo();
            grid2();
            for (int idx = 0; idx < ratings.Count(); idx++)
            {
                Console.SetCursorPosition(45, 25 + idx);
                Console.WriteLine(idx + 1 + "-" + ratings[idx].Name + "'s given rating is " + ratings[idx].Rating);
            }
            Console.SetCursorPosition(45, 40);
            Console.Write("Enter any key to cotinue");
            Console.ReadKey();
            adminFunctionalities();
        }
        static void dineFeatures()
        {
            Console.Clear();
            double money = 0;
            payment();
            calculateDiscount();
            Console.SetCursorPosition(60, 31);
            Console.WriteLine("Your bill is:" + FinalBill);
            Console.SetCursorPosition(60, 29);
            Console.Write("Enter your choice:");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.SetCursorPosition(60, 33);
                Console.Write("Enter the amount of money recieved:");
                money = float.Parse(Console.ReadLine());
                if (money > FinalBill)
                {
                    money = (money) - (FinalBill);
                    Console.SetCursorPosition(60, 34);
                    Console.WriteLine("Your change is:" + money);
                    Console.SetCursorPosition(60, 36);
                    Console.WriteLine("Enter any key to continue:");
                    Console.ReadKey();
                    userFunctionalities();
                }
                else
                {
                    Console.SetCursorPosition(60, 41);
                    Console.WriteLine("Not enought money");
                    Console.SetCursorPosition(60, 42);
                    Console.WriteLine("Enter any key to continue...");
                    Console.ReadKey();
                    calculateBill();
                }
            }
            else if (choice == "2")
            {
                int card_num, pi;
                Console.SetCursorPosition(60, 33);
                Console.Write("Enter your card number:");
                card_num = int.Parse(Console.ReadLine());
                Console.SetCursorPosition(60, 34);
                Console.Write("Enter your pin:");
                pi = int.Parse(Console.ReadLine());
                for (int idx = 0; idx < userDetails.Count(); idx++)
                {
                    if (card_num == userDetails[idx].CardNumber && pi == userDetails[idx].Pin)
                    {
                        Console.SetCursorPosition(60, 35);
                        Console.WriteLine("Money recieved from your account.");
                        end();
                        Console.SetCursorPosition(60, 40);
                        Console.WriteLine("Enter any key to continue...");
                        Console.ReadKey();
                        userFunctionalities();
                    }
                    else
                    {
                        Console.WriteLine("Invalid details.Try again!");
                        calculateBill();
                    }
                }
            }
            else if (choice == "3")
            {
                menu();
                menuDetails();
            }
            else
            {
                Console.SetCursorPosition(60, 47);
                Console.WriteLine("Invalid Input");
                Console.SetCursorPosition(60, 48);
                Console.WriteLine("Press any key to continue...");
                choice = Console.ReadLine();
                menu();
                menuDetails();
            }
        }
        static void home() /////////////// Selection page for admin or user
        {
            Console.Clear();
            logo();
            grid2();
            Console.SetCursorPosition(62, 25);
            Console.WriteLine(" _______");
            Console.SetCursorPosition(60, 26);
            Console.WriteLine("1-| Admin |");
            Console.SetCursorPosition(63, 27);
            Console.WriteLine("__________");
            Console.SetCursorPosition(60, 28);
            Console.WriteLine("2-| Customer |");
        }
        static void homeDeatails()
        {
            Console.SetCursorPosition(60, 33);
            Console.Write("Enter your choice:");
            string choice;
            choice = Console.ReadLine();
            if (choice == "1")
            {
                admin();
                adminLogin();
            }
            else if (choice == "2")
            {
                usEr();
                userLogin();
            }
            else
            {
                Console.SetCursorPosition(60, 34);
                Console.WriteLine("Invalid input.");
                Console.SetCursorPosition(60, 35);
                Console.WriteLine("Enter any key to continue");
                Console.ReadKey();
                home();
                homeDeatails();
            }
        }
        static void loadData() /////////////// for loading user's data from file
        {
            string user = "user.txt";
            StreamReader fp = new StreamReader(user);
            string word;
            while ((word = fp.ReadLine()) != null)
            {

                string name = parsItems(word, 1);
                string userName = parsItems(word, 2);
                string password = parsItems(word, 3);
                int cardnumber = int.Parse(parsItems(word, 4));
                int pin = int.Parse(parsItems(word, 5));
                UserLogin obj = new UserLogin(name,userName,password,cardnumber,pin);
                userDetails.Add(obj);
            }
            fp.Close();
        }
        static void UpdateItems_fromFile(List<product> p1) ////////////////////// for deleting an item from file
        {
            string path = "data.txt";
            StreamWriter gross = new StreamWriter(path, false);
            for (int idx = 0; idx < p1.Count(); idx++)
            {
                gross.WriteLine(p1[idx].itemName + "," + p1[idx].itemRate);
                gross.Flush();
            }
            gross.Close();
        }
        static void changeTheme() ////////////////////// for changing light and dark mode
        {
            Console.Clear();
            logo();
            grid2();
            int choice;
            Console.SetCursorPosition(45, 22);
            Console.WriteLine( "********Available themes are********");
            Console.SetCursorPosition(45, 23);
            Console.WriteLine("1- Dark theme");
            Console.SetCursorPosition(45, 24);
            Console.WriteLine("2- Light theme");
            Console.SetCursorPosition(45, 26);
            Console.Write("Which theme you want to apply?");
            choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                //string foreground;
                //string background = "Black";
                //storeColor(background,foreground);
                userFunctionalities();
                //loadColor();
            }
            else if (choice == 2)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                //storeColor(color);
                userFunctionalities();
                //loadColor();
            }
            else
            {
                Console.SetCursorPosition(45, 28);
                Console.WriteLine("Invalid choice.Try again!");
                Console.SetCursorPosition(45, 29);
                Console.Write("Enter any key to continue...");
                Console.ReadKey();
                changeTheme();
                
            }
        }
        /*void storeColor(string background,string foreground) ///////////////////// for storing text color
        {
            string path = "color.txt";
            StreamWriter fp = new StreamWriter(path, true);
            Console.WriteLine( background + "," + foreground);
        }
        void loadColor() ////////////////////// for loading text colour
        {
            fstream gross;
            colors = "0";
            string word;
            gross.open("color.txt", ios::in);
            while (!gross.eof())
            {
                getline(gross, word);
                if (word == "")
                    break;
                colors = parsItems(word, 1);
                SetConsoleTextAttribute(hConsole, stoi(colors));
            }
            gross.close();
        }*/
    }
}
