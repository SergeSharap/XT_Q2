using System;
using System.Collections.Generic;
using System.Text;

namespace Task_5
{
    class Menu
    {
        public void Choice()
        {
            
            bool quit = false;
            do
            {
                Console.Clear();

                Console.WriteLine("Select action:" + Environment.NewLine);
                Console.WriteLine("1. Watch files"
                                  + Environment.NewLine + "2. Recovery files"
                                  + Environment.NewLine + "3. Quit"
                );

                int.TryParse(Console.ReadLine(), out int selectedItem);

                switch (selectedItem)
                {
                    case 1:
                        BeginWatchFiles();
                        break;
                    case 2:
                        BeginRecovery();
                        break;
                    case 3:
                        quit = true;
                        break;
                    default:
                        break;
                }
            } while (!quit);
        }

        private void BeginWatchFiles()
        {
            Watcher watcher = new Watcher(@"F:\Program Files\VisualStudio\Projects\Storage", @"F:\Program Files\VisualStudio\Projects\Archive", "*.txt");
            watcher.BeginWatch();
            Console.Read();
            watcher.StopWatch();
        }

        private void BeginRecovery()
        {
            int year = Input("Please enter year of recovery");
            int month = Input("Please enter month of Recovery");
            int day = Input("Please enter day of recovery");
            int hour = Input("Please enter hour of recovery");
            int minute = Input("Please enter minute of recovery");
            int second = Input("Please enter second of recovery");

            try
            {
                Recovery recovery = new Recovery(@"F:\Program Files\VisualStudio\Projects\Archive",
                    @"F:\Program Files\VisualStudio\Projects\Storage",
                    new DateTime(year, month, day, hour, minute, second));
                recovery.RunRecovery();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        private int Input(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                bool isCorrectParse = int.TryParse(Console.ReadLine(), out int n);

                if (isCorrectParse)
                    return n;
                else
                    Console.WriteLine("You entered not a number");
            }
        }
    }
}
