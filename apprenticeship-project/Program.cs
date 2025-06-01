using System;
namespace apprenticeship_project
{
    class Program
    {
        static void Main(string[] args)
        {
            RetrieveData retrieveData = new RetrieveData();

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("1 - get quantity of group, 2 - get value of group, 3 - sort group by date (min -> max), 4 - sort group by date (max -> min), 5 - get value of whole file, 0 - exit.");
            Console.Write("Select option: ");
            string option = Console.ReadLine();

            string type = "null";

            if (option == "0")
            {
                Console.WriteLine("Bye!");
            }
            else
            {
                bool showMenu = false;
                string group = "";

                while (!showMenu)
                {
                    Console.Write("Write group number (1 - 4): ");
                    group = Console.ReadLine();
            
                    switch (group)
                    {
                        case "1":
                            showMenu = true;
                            group = "111";
                            break;
                        case "2":
                            showMenu = true;
                            group = "882";
                            break;
                        case "3":
                            showMenu = true;
                            group = "232";
                            break;
                        case "4":
                            showMenu = true;
                            group = "484";
                            break;
                        default:
                            Console.WriteLine("Unknown group, try again.");
                            break;
                    }
                }
                Console.ResetColor();
                retrieveData.prepareData(group, option, type);
            }
            
            
        }
    }
}