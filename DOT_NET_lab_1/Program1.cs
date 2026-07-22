using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace StudentAdmissionManagement
{
    class Student
    {
        private int studentId;
        private string studentName;
        private int age;
        private string course;
        private double admissionFee;

        public Student(int id, string name, int age, string course, double fee)
        {
         
   studentId = id;
            studentName = name;
            this.age = age;
            this.course = course;
            admissionFee = fee;
        }

        public void DisplayStudentDetails()
        {
            Console.WriteLine("\n===== Student Admission Details =====");
            Console.WriteLine("Student ID      : " + studentId);
            Console.WriteLine("Student Name    : " + studentName);
            Console.WriteLine("Age             : " + age);
            Console.WriteLine("Course          : " + course);
            Console.WriteLine("Admission Fee   : " + admissionFee);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int id, age;
            string name, course;
            double fee;

            Console.WriteLine("===== Student Admission Management System =====");

            Console.Write("Enter Student ID: ");
            id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Student Name: ");
            name = Console.ReadLine();

            Console.Write("Enter Age: ");
            age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Course: ");
            course = Console.ReadLine();

            Console.Write("Enter Admission Fee: ");
            fee = Convert.ToDouble(Console.ReadLine());

            Student student = new Student(id, name, age, course, fee);

            student.DisplayStudentDetails();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
