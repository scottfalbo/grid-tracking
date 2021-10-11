using GridTracking.Critters;
using System;
using System.Collections.Generic;

namespace GridTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleUI();
        }

        static void ConsoleUI()
        {
            Map map = new Map(25, 25);
            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                long x = random.Next(0, 10);
                long y = random.Next(0, 10);
                Leviathan leviathan = new Leviathan($"whatever{x}{y}", x, y);
                map.PlotCritter(leviathan);
            }

            bool exit = false;
            while (!exit)
            {
                map.PrintMap();
                Console.WriteLine("Select an option");
                Console.WriteLine("1: Move Critters");
                Console.WriteLine("2: Exit");

                int input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        map.MoveCritters();
                        Console.Clear();
                        break;
                    case 2:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        }

    }

}
