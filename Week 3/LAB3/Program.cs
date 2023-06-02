using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB3
{
    class student
    {
        public student()
        {
            Console.WriteLine("Default Constructor Called ");
            sname = "Jill";
            matricMarks = 1032;
            fscMarks = 996;
            ecatMarks = 219;
            aggregate = 86.5F;
        }
        public string sname;
        public float matricMarks;
        public float fscMarks;
        public float ecatMarks;
        public float aggregate;
    }
    class parameterized
    {
        public parameterized(string n, float m, float f, float e, float a)
        {
            sname = n;
            matricMarks = m;
            fscMarks = f;
            ecatMarks = e;
            aggregate = a;
        }
        public parameterized(string n)
        {
            sname = n;
        }
        public string sname;
        public float matricMarks;
        public float fscMarks;
        public float ecatMarks;
        public float aggregate;

    }

    class students
    {
        public students()
        {
            Console.WriteLine("Console Constructor");
        }
        public students(students s)
        {
            sname = s.sname;
            matricMarks = s.matricMarks;
            fscMarks = s.fscMarks;
            ecatMarks = s.ecatMarks;
            aggregate = s.aggregate;
        }
        public string sname;
        public float matricMarks;
        public float fscMarks;
        public float ecatMarks;
        public float aggregate;
    }
    class product
    {
        public product(string n, char c, float p, int sq, int msq)
        {
            name = n;
            category = c;
            price = p;
            StockQuantity = sq;
            minStockQuantity = msq;
        }
        public product(string n)
        {
            name = n;
        }
        public product()
        {
        }
        public product(product p)
        {
            name = p.name;
            category = p.category;
            price = p.price;
            StockQuantity = p.StockQuantity;
            minStockQuantity = p.minStockQuantity;
        }
        List<string> cart = new List<string>();
        public string name;
        public char category;
        public float price;
        public int StockQuantity;
        public int minStockQuantity;

        public void loading()
        {
            string record;
            StreamReader file = new StreamReader("cart.txt");
            while ((record = file.ReadLine()) != null)
            {
                cart.Add(record);
            }
            file.Close();

        }
        public void storeInFile(product p)
        {
            StreamWriter file = new StreamWriter("cart.txt", true);
            file.WriteLine("{0},{1},{2},{3},{4}", p.name, p.category, p.price, p.StockQuantity, p.minStockQuantity);
            file.Close();
        }
        public void viewFromCart()
        {
            foreach (string record in cart)
            {
                Console.WriteLine("Name :{0} Category :{1} Price :{2} StockQuantity :{3} MinimumStockLimit :{4}", parsing(record, 1), parsing(record, 2), parsing(record, 3), parsing(record, 4), parsing(record, 5));
            }
            Console.ReadKey();
            Console.Clear();
        }
        public void highestPrice()
        {
            int count = 0;
            int temp = 1;
            int largest = int.Parse(parsing(cart[0], 3));
            foreach (string record in cart)
            {
                if (largest < int.Parse(parsing(cart[count], 3)))
                {
                    largest = int.Parse(parsing(cart[count], 3));
                    temp = count;
                }
                count++;
            }
            Console.WriteLine("The product with highest price is given below");
            Console.WriteLine("Name :{0} Category :{1} Price :{2} StockQuantity :{3} MinimumStockLimit :{4}", parsing(cart[temp], 1), parsing(cart[temp], 2), parsing(cart[temp], 3), parsing(cart[temp], 4), parsing(cart[temp], 5));
            Console.ReadKey();
            Console.Clear();
        }
        public void saleTax()
        {
            int count = 0;
            float totalTax = 0;
            foreach (string record in cart)
            {
                if (parsing(cart[count], 2) == "g" || parsing(cart[count], 2) == "G")
                {
                    totalTax = totalTax + (float)(int.Parse(parsing(cart[count], 3)) * int.Parse(parsing(cart[count], 4)) * 0.1);
                }
                else if (parsing(cart[count], 2) == "f" || parsing(cart[count], 2) == "F")
                {
                    totalTax = totalTax + (float)(int.Parse(parsing(cart[count], 3)) * int.Parse(parsing(cart[count], 4)) * 0.05);
                }
                else
                {
                    totalTax = totalTax + (float)(int.Parse(parsing(cart[count], 3)) * int.Parse(parsing(cart[count], 4)) * 1.5);
                }
                count++;
            }
            Console.WriteLine("Sales Tax of all the products is : {0}", totalTax);
            Console.ReadKey();
            Console.Clear();
        }
        public void productsToBeOrdered()
        {
            int stock;
            int minimum;
            int count = 0;
            bool check = false;
            Console.WriteLine("Products to be ordered are : ");
            foreach (string record in cart)
            {
                stock = int.Parse(parsing(cart[count], 4));
                minimum = int.Parse(parsing(cart[count], 5));
                if (stock < minimum)
                {
                    Console.WriteLine("Name :{0} Category :{1} Price :{2} StockQuantity :{3} MinimumStockLimit :{4}", parsing(record, 1), parsing(record, 2), parsing(record, 3), parsing(record, 4), parsing(record, 5));
                    check = true;
                }
                count++;
            }
            if (check == false)
                Console.WriteLine("None");
            Console.ReadKey();
            Console.Clear();
        }
        public string parsing(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
    }
    class clockType
    {

        public int hours;
        public int minutes;
        public int seconds;
        public clockType()
        {
            hours = 0;
            seconds = 0;
            minutes = 0;
        }
        public clockType(int m,int s,int h)
        {
            hours = h;
            seconds = s;
            minutes = m;
        }
        public clockType(int m, int h)
        {
            hours = h;
            minutes = m;
        }
        public clockType(int h)
        {
            hours = h;
        }
        public void inreaseSeconds()
        {
            seconds++;
        }
        public void inreaseMinutes()
        {
            minutes++;
        }
        public void inreaseHours()
        {
            hours++;
        }
        public void printTime()
        {
            Console.WriteLine(hours + " " + minutes + " " + seconds);
        }
        public bool isEqual(int h,int s,int m)
        {
            if(hours==h && minutes==m && seconds==s )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool isEqual(clockType temp)
        {
            if (hours == temp.hours && minutes == temp.minutes && seconds == temp.seconds)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int elapsedTime(clockType time)
        {
            int total_sec; 
            time.hours = time.hours * 3600;
            time.minutes = time.minutes * 60;
            total_sec = time.minutes + time.hours + time.seconds;
            return total_sec;
        }
        public int remainingTime(int seconds,int time)
        {
            if(seconds > time)
            time = seconds - time;
            if (time > seconds)
            time = time - seconds;
            return time;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // challenge0();
            // task1();
            // task2();
            // task3();
            // challenge1();
            challenge2();
        }
        static void challenge0()
        {
            // default constructor
            clockType empty_time = new clockType();
            Console.WriteLine("Empty Time:");
            empty_time.printTime();
            // parametarized constructor (one parameter)
            clockType hour_time = new clockType();
            Console.WriteLine("Hour Time:");
            hour_time.printTime();
            // parametarized constructor (one parameter)
            clockType minute_time = new clockType();
            Console.WriteLine("Minute Time:");
            minute_time.printTime();
            // parametarized constructor (one parameter)
            clockType full_time = new clockType(8);
            Console.WriteLine("Full Time:");
            full_time.printTime();
            // increment second
            full_time.inreaseSeconds();
            Console.WriteLine("Full Time(Increment Seconds):");
            full_time.printTime();
            // increment minutes
            full_time.inreaseMinutes();
            Console.WriteLine("Full Time(Increment MInutes):");
            full_time.printTime();
            // increment hours
            full_time.inreaseHours();
            Console.WriteLine("Full Time(Increment Hours):");
            full_time.printTime();
            // check if equal
            bool flag = full_time.isEqual(9, 11, 11);
            Console.WriteLine("Flag: "+ flag);
            // check if equal with object
            clockType cmp = new clockType(10, 12, 1);
            flag = full_time.isEqual(cmp);
            Console.WriteLine("Object Flag: " + flag);
            Console.ReadKey();
        }
        static void Task1()
        {
            student s1 = new student();
            Console.WriteLine(s1.sname);
            Console.WriteLine(s1.matricMarks);
            Console.WriteLine(s1.fscMarks);
            Console.WriteLine(s1.ecatMarks);
            Console.WriteLine(s1.aggregate);
            Console.ReadKey();
        }
        static void Task2()
        {
            student s1 = new student();
            Console.Read();
        }
        static void Task3()
        {
            student s1 = new student();
            Console.Write(s1.sname);
            Console.Read();
        }
        static void Task4()
        {
            student s1 = new student();
            Console.WriteLine(s1.sname);
            Console.WriteLine(s1.matricMarks);
            Console.WriteLine(s1.fscMarks);
            Console.WriteLine(s1.ecatMarks);
            Console.WriteLine(s1.aggregate);
            Console.Read();
        }
        static void Task5()
        {
            student s1 = new student();
            Console.WriteLine(s1.sname);
            Console.WriteLine(s1.matricMarks);
            Console.WriteLine(s1.fscMarks);
            Console.WriteLine(s1.ecatMarks);
            Console.WriteLine(s1.aggregate);

            student s2 = new student();
            Console.WriteLine(s2.sname);
            Console.WriteLine(s2.matricMarks);
            Console.WriteLine(s2.fscMarks);
            Console.WriteLine(s2.ecatMarks);
            Console.WriteLine(s2.aggregate);

            Console.Read();
        }
        static void Task6()
        {
            parameterized s1 = new parameterized("John");
            Console.WriteLine(s1.sname);
            parameterized s2 = new parameterized("Jack");
            Console.WriteLine(s2.sname);

            Console.ReadKey();
        }
        static void Task7()
        {
            parameterized s1 = new parameterized("John", 1032, 996, 219, 86);
            Console.WriteLine(s1.sname);
            Console.WriteLine(s1.matricMarks);
            Console.WriteLine(s1.fscMarks);
            Console.WriteLine(s1.ecatMarks);
            Console.WriteLine(s1.aggregate);
            parameterized s2 = new parameterized("Jack", 1002, 1096, 229, 87);
            Console.WriteLine(s2.sname);
            Console.WriteLine(s2.matricMarks);
            Console.WriteLine(s2.fscMarks);
            Console.WriteLine(s2.ecatMarks);
            Console.WriteLine(s2.aggregate);

            Console.ReadKey();
        }

        static void task1()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            for(int i=0; i < numbers.Count ; i++)
            {
                Console.WriteLine(numbers[i]);
            }
            Console.ReadKey();
        }
        static void task2()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach(int i in numbers)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
        static void task3()
        {
            students s1 = new students();
            s1.sname = "JACK";
            students s2 = new students();
            Console.WriteLine(s1.sname);
            Console.WriteLine(s2.sname);
            Console.ReadKey();
        }
        static void challenge1()
        {
            clockType t1 = new clockType();
            int total_time;
            int remaining_time;
            int final_time;
            int final_hours;
            int final_mins;
            int final_sec;
            Console.WriteLine("Enter Hours:");
            t1.hours = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Minutes:");
            t1.minutes = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Seconds:");
            t1.seconds = int.Parse(Console.ReadLine());
            total_time = t1.elapsedTime(t1);
            Console.WriteLine("Elapse Time: "+total_time);
            int daySeconds = 86400;
            remaining_time = t1.remainingTime(daySeconds, total_time);
            Console.WriteLine("Remaining Time: "+remaining_time);
            final_time = total_time - remaining_time;
            Console.WriteLine("Difference in Clock: "+final_time);
            final_hours = final_time % 3600;
            final_mins = final_hours / 3600;
            final_mins = final_mins % 60;
            final_sec = final_mins % 60;
            Console.WriteLine("Hours : {0} Minutes : {1}  Seconds : {2}",final_hours,final_mins,final_sec);
            Console.ReadKey();
        }
        static int challengeTask2()
        {
            while (true)
            {
                product p = new product();
                p.loading();
                int option = menu();
                Console.Clear();
                if (option == 1)
                {
                    addProduct();
                }
                else if (option == 2)
                {
                    p.viewFromCart();
                }
                else if (option == 3)
                {
                    p.highestPrice();
                }
                else if (option == 4)
                {
                    p.saleTax();
                }
                else if (option == 5)
                {
                    p.productsToBeOrdered();
                }
                else
                    return 0;
            }
        }
        static int menu()
        {
            int option;
            Console.WriteLine("1 for Adding Product");
            Console.WriteLine("2 for viewing all Products");
            Console.WriteLine("3 for finding product with highest unit price");
            Console.WriteLine("4 to view sales tax of all Products");
            Console.WriteLine("5 for products to be ordered(less than threshold)");
            Console.Write("Enter your choice : ");
            option = int.Parse(Console.ReadLine());

            return option;
        }
        static void addProduct()
        {
            string choice = Console.ReadLine();
            Console.Write("Enter the name of product : ");
            string name = Console.ReadLine();
            Console.Write("Enter the category of product : ");
            char category = char.Parse(Console.ReadLine());
            Console.Write("Enter the price of product : ");
            float price = float.Parse(Console.ReadLine());
            Console.Write("Enter the stock quantity of product : ");
            int quantity = int.Parse(Console.ReadLine());
            Console.Write("Enter the minimum stock quantity of product : ");
            int minQuantity = int.Parse(Console.ReadLine());
            product p = new product(name, category, price, quantity, minQuantity);
            p.storeInFile(p);
            p.loading();
            Console.ReadKey();
            Console.Clear();
        }
    }
}



