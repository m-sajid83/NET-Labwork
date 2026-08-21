using System;

namespace ConsoleApp2
{
    interface IEmployee
    {
        void CalculateSalary();
        void Display();
    }

    class Employee : IEmployee
    {
        public int EmpId;
        public string EmpName;
        public double BasicPay;
        public double DA;
        public double HRA;
        public double Salary;

        public Employee(int id, string name, double basic)
        {
            EmpId = id;
            EmpName = name;
            BasicPay = basic;
        }

        public virtual void CalculateSalary()
        {
        }

        public virtual void Display()
        {
            Console.WriteLine("\nEmployee ID : " + EmpId);
            Console.WriteLine("Employee Name : " + EmpName);
            Console.WriteLine("Basic Pay : " + BasicPay);

            if (DA > 0 || HRA > 0)
            {
                Console.WriteLine("DA : " + DA);
                Console.WriteLine("HRA : " + HRA);
            }

            Console.WriteLine("Total Salary : " + Salary);
        }
    }

    class FullTimeEmployee : Employee
    {
        public FullTimeEmployee(int id, string name, double basic)
            : base(id, name, basic)
        {
        }

        public override void CalculateSalary()
        {
            DA = BasicPay * 0.50;
            HRA = BasicPay * 0.20;
            Salary = BasicPay + DA + HRA;
        }
    }

    class PartTimeEmployee : Employee
    {
        public PartTimeEmployee(int id, string name, double basic)
            : base(id, name, basic)
        {
        }

        public override void CalculateSalary()
        {
            Salary = BasicPay;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Employee ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Basic Salary: ");
            double basic = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\n1. Full Time");
            Console.WriteLine("2. Part Time");
            Console.Write("Enter Choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            IEmployee emp;

            if (choice == 1)
            {
                emp = new FullTimeEmployee(id, name, basic);
            }
            else if (choice == 2)
            {
                emp = new PartTimeEmployee(id, name, basic);
            }
            else
            {
                Console.WriteLine("Invalid Choice! Please enter only 1 or 2.");
                Console.ReadKey();
                return;
            }

            emp.CalculateSalary();
            emp.Display();

            Console.ReadKey();
        }
    }
}