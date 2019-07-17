using System;

namespace Task2
{
    class Program
    {
        static void Main()
        {
            MyString myString = new MyString("Hello world!");
            Console.WriteLine(myString);
            MyString myString2 = new MyString("Oh, hi Mark");
            Console.WriteLine(myString2);
            MyString myString3 = new MyString("Hello world!");
            Console.WriteLine(myString3);

            Console.WriteLine(myString == myString2);
            Console.WriteLine(myString == myString3);

            MyString myString4 = myString + myString2;
            Console.WriteLine(myString4);

            MyString myString5 = myString4.Replace('h', 'l');
            Console.WriteLine(myString5);

            MyString myString6 = myString.Remove(5);
            Console.WriteLine(myString6);
        }
    }
}
