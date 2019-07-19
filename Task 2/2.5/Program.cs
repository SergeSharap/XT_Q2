using System;

namespace _2._5
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee("Sergey", "Sharapov", "Andreevich", new DateTime(1997, 1, 8), "Programist", 10);
            employee.ShowDetails();
            Console.ReadKey();
        }
    }
}
