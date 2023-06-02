using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task
{
    class Program
    {
        public static string[] adminNames = new string[1000];
        public static string[] adminPasswords = new string[1000];
        public static int adminCount;
        public static string adminn = "admin.txt";
        class students
        {
            public string name;
            public int roll_no;
            public float cgpa;
            public string department;
            public char isHostelide;
        }
        class product
        {
            public int id;
            public string name;
            public float price;
            public string category;
            public string brandName;
            public string country;
        }
        class credentials
        {
            public string username;
            public string password;
        }
        static void Main(string[] args)
        {
            // task2();
            // challenge1();
            challenge2();
        }
        static void task1()
        {
            /// First
            students s1 = new students();
            s1.name = "Burhan";
            s1.roll_no = 191;
            s1.cgpa = 3.6F;
            Console.WriteLine("Name:{0} Roll no: {1} CGPA: {2}", s1.name, s1.roll_no, s1.cgpa);
            Console.Read();
            /// Second
            students s2 = new students();
            s2.name = "Bilal";
            s2.roll_no = 170;
            s2.cgpa = 3.7F;
            Console.WriteLine("Name:{0} Roll no: {1} CGPA: {2}", s2.name, s2.roll_no, s2.cgpa);
            Console.Read();
            /// Third
            Console.WriteLine("Enter name: ");
            s1.name = Console.ReadLine();
            Console.WriteLine("Enter Roll number: ");
            s1.roll_no = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter CGPA: ");
            s1.cgpa = float.Parse(Console.ReadLine());
            Console.WriteLine("Name:{0} Roll no: {1} CGPA: {2}", s1.name, s1.roll_no, s1.cgpa);
            Console.Read();
            //// Four
            Console.WriteLine("Enter name: ");
            s2.name = Console.ReadLine();
            Console.WriteLine("Enter Roll number: ");
            s2.roll_no = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter CGPA: ");
            s2.cgpa = float.Parse(Console.ReadLine());
            Console.WriteLine("Name:{0} Roll no: {1} CGPA: {2}", s1.name, s1.roll_no, s1.cgpa);
            Console.Read();

        }
        static void task2()
        {
            students[] s = new students[10];
            char option;
            int count = 0;
            do
            {
                option = menu();
                if (option == '1')
                {
                    s[count] = addStudent();
                    count++;
                }
                else if (option == '2')
                {
                    viewStudent(s, count);
                }
                else if (option == '3')
                {
                    topStudent(s, count);
                }
                else if (option == '4')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice");

                }
            } while (option != '4');
            Console.WriteLine("Press enter to exit...");
            Console.Read();
        }
        static char menu()
        {
            Console.Clear();
            char choice;
            Console.WriteLine("Enter 1 for adding a student");
            Console.WriteLine("Enter 2 for view student");
            Console.WriteLine("Enter 3 for top three student");
            Console.WriteLine("Enter 4 to exit");
            choice = char.Parse(Console.ReadLine());
            return choice;
        }
        static students addStudent()
        {
            Console.Clear();
            students s1 = new students();
            Console.WriteLine("Enter name: ");
            s1.name = Console.ReadLine();
            Console.WriteLine("Enter Roll number: ");
            s1.roll_no = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter CGPA: ");
            s1.cgpa = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Department: ");
            s1.department = Console.ReadLine();
            Console.WriteLine("Is Hostelite(y || n): ");
            s1.isHostelide = char.Parse(Console.ReadLine());
            return s1;
        }
        static void viewStudent(students[] s,int count)
        {
            Console.Clear();
            for(int i=0;i<count;i++)
            {
                Console.WriteLine("Name:{0}  Roll number: {1}  CGPA: {2}  Department:{3}  isHostelide: {4}", s[i].name, s[i].roll_no, s[i].cgpa, s[i].department, s[i].isHostelide);
            }
            Console.WriteLine("Enter any key to continue");
            Console.ReadKey();
        }
        static void topStudent(students[] s,int count)
        {
            Console.Clear();
            if(count==0)
            {
                Console.WriteLine("No record");
            }
            else if(count == 1)
            {
                viewStudent(s, 1);
            }
            else if(count == 2)
            {
                for(int x = 0; x < 2 ; x++)
                {
                    int index = largest(s, x, count);
                    students temp = s[index];
                    s[index] = s[x];
                    s[x] = temp;
                }
                viewStudent(s, 2);
            }
            else
            {
                for (int x = 0; x < 3 ; x++)
                {
                    int index = largest(s, x, count);
                    students temp = s[index];
                    s[index] = s[x];
                    s[x] = temp;
                }
                viewStudent(s, 3);
            }

        }
        static int largest(students[] s, int start, int end)
        {
            int index = start;
            float large = s[start].cgpa;
            for(int idx = start ; idx < end; idx++)
            {
                if(large < s[idx].cgpa)
                {
                    large = s[idx].cgpa;
                    index = idx;
                }
            }
            return index;
        }
        static void challenge1()
        {
            product[] p = new product[10];
            char option;
            float tag;
            int count = 0;
            do
            {
                option = front();
                if (option == '1')
                {
                    p[count] = addProduct();
                    count++;
                }
                else if (option == '2')
                {
                    viewProducts(p, count);
                }
                else if (option == '3')
                {
                   tag = Worth(p, count);
                   Console.WriteLine("Total Worth is:{0}",tag);
                   Console.WriteLine("Press enter to exit...");
                   Console.Read();
                }
                else if (option == '4')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice");

                }
            } while (option != '4');
            Console.WriteLine("Press enter to exit...");
            Console.Read();
        }
          static char front()
        {
            Console.Clear();
            char choice;
            Console.WriteLine("Enter 1 for adding a product");
            Console.WriteLine("Enter 2 for view product");
            Console.WriteLine("Enter 3 to view total store worth");
            Console.WriteLine("Enter 4 to exit");
            choice = char.Parse(Console.ReadLine());
            return choice;
        }
        static product addProduct()
        {
            Console.Clear();
            product p1 = new product();
            Console.WriteLine("Enter product name: ");
            p1.name = Console.ReadLine();
            Console.WriteLine("Enter product id: ");
            p1.id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter price: ");
            p1.price = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Category: ");
            p1.category = Console.ReadLine();
            Console.WriteLine("Enter brand name: ");
            p1.brandName = Console.ReadLine();
            Console.WriteLine("Enter Country: ");
            p1.country = Console.ReadLine();
            return p1;
        }
        static void viewProducts(product[] p, int count)
        {
            Console.Clear();
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Name:{0}  ID: {1}  Price: {2}  Category:{3}  Brand Name: {4}  Country:{5}", p[i].name, p[i].id, p[i].price, p[i].category, p[i].brandName, p[i].country);
            }
            Console.WriteLine("Enter any key to continue");
            Console.ReadKey();
        }
        static float Worth(product[] p,int count)
        {
            float total = 0;
            for(int x = 1; x < count; x++)
            {
                total = total + p[x].price;
            }
            return total;
        }
        static void challenge2()
        {
            Console.Clear();
            char choice;
            Console.WriteLine("Enter 1 for sign up");
            Console.WriteLine("Enter 2 for sign in");
            choice = char.Parse(Console.ReadLine());
            if( choice == '1')
            {
                adminLogin();
            }
            else if(choice=='2')
            {
                createAdmin();
            }
        }
        static bool AdminSignin(string adminName, string adminPassword) /////////////////// for checking sigining in
        {
            bool flag = false;
            for (int idx = 0; idx < adminCount; idx++)
            {
                if (adminNames[idx] == adminName && adminPasswords[idx] == adminPassword)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        static bool isvalidAdmin(string adminName) ///////////////////// to check validity of adminName
        {
            bool flag = true;
            for (int idx = 0; idx < adminCount; idx++)
            {
                if (adminNames[idx] == adminName)
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }

        static void AdminSignUpArray(string adminName, string adminPassword) ///////////// for storing users information
        {

            adminNames[adminCount] = adminName;
            adminPasswords[adminCount] = adminPassword;
            adminCount++;
        }

        static void storeAdminData(string adminn, string adminName, string adminPassword) //////////// for storing users info in file
        {

            StreamWriter file = new StreamWriter(adminn, false);
            file.WriteLine(adminName + "," + adminPassword);
            file.Close();
            file.Flush();
        }
        static void loadAdminData(string adminn) /////////////// for loading user's data from file
        {
            StreamReader fp = new StreamReader(adminn);
            string word;
            adminCount = 0;
            while ((word = fp.ReadLine()) != null)
            {
                if (adminCount > 10000)
                {
                    break;
                }
                adminNames[adminCount] = parsItems(word, 1);
                adminPasswords[adminCount] = parsItems(word, 2);
                adminCount++;
            }
            fp.Close();
        }
        static void viewAdmins() /////////////////// for viewing all users
        {
            Console.Clear();
            for (int idx = 0; idx < adminCount; idx++)
            {
                Console.WriteLine(idx + 1 + "-" + adminNames[idx]);
            }
            Console.WriteLine("Enter any key to continue...");
            Console.ReadKey();
        }
        static void createAdmin()
        {
            credentials c1 = new credentials();
            bool decision;
            bool flag;
            Console.Clear();
            Console.WriteLine("Enter your username:");
            c1.username = Console.ReadLine();
            Console.WriteLine("Enter the password:");
            c1.password = Console.ReadLine();
            storeAdminData(adminn, c1.username, c1.password);
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
        static void adminLogin() /////////////////////// for admin login
        {
            bool flag;
            string adminName;
            string adminPassword;
            Console.WriteLine("Enter your email:");
            adminName = Console.ReadLine();
            Console.WriteLine("Enter your password:");
            adminPassword = Console.ReadLine();
            flag = AdminSignin(adminName, adminPassword);
            if (adminName == "burhan" && adminPassword == "123")
            {
                Console.WriteLine("Access granted");
            }
            else if (flag == true)
            {
                Console.WriteLine("Access granted");

            }
            else
            {
                Console.WriteLine("Access denied");
                Console.WriteLine("Incorrect credentials.Try again!");
                Console.WriteLine("Enter any key to continue:");
                Console.ReadKey();
                adminLogin();
            }
        }

    }

}
