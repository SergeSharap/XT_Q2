using System;

namespace _2._5
{
    class Program
    {
        static void Main()
        {
            Employee employee = new Employee("Sergey", "Sharapov", "Andreevich", new DateTime(1997, 1, 8), "Programmer", 10);
            employee.ShowDetails();
            Console.ReadKey();
        }
    }
}
