using System;

namespace T3_1
{
    class Program
    {


        static void Main()
        {
            Lost man = new Lost();
            string lostMan = man.GetLostMan();

            Console.WriteLine("The survivor: {0}", lostMan);
            Console.ReadKey();
        }

    }
}
