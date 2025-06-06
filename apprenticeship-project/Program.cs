using System;
using apprenticeship_project.Model;

namespace apprenticeship_project
{
    class Program
    {
        static void Main(string[] args)
        {
            // RetrieveData retrieveData = new RetrieveData();
            //
            // Console.ForegroundColor = ConsoleColor.Green;
            //
            // Console.WriteLine("1 - get quantity of group, 2 - get value of group, 3 - get date min/max of group, 4 - get value of whole file, 0 - exit.");
            // Console.Write("Select option: ");
            // string option = Console.ReadLine();
            // string group = "";
            //
            // string type = "null";
            //
            // if (option == "0")
            // {
            //     Console.WriteLine("Bye!");
            // }
            // else
            // {
            //     bool showMenu = false;
            //
            //     while (!showMenu)
            //     {
            //         Console.Write("Write group number (1 - 4): ");
            //         group = Console.ReadLine();
            //
            //         switch (group)
            //         {
            //             case "1":
            //                 showMenu = true;
            //                 group = "111";
            //                 break;
            //             case "2":
            //                 showMenu = true;
            //                 group = "882";
            //                 break;
            //             case "3":
            //                 showMenu = true;
            //                 group = "232";
            //                 break;
            //             case "4":
            //                 showMenu = true;
            //                 group = "484";
            //                 break;
            //             default:
            //                 Console.WriteLine("Unknown group, try again.");
            //                 break;
            //         }
            //     }
            //     Console.ResetColor();
            //     retrieveData.prepareData(group, option);

            //C:\\Users\\mikol\\Desktop\\my_code_base\\projects\\apprenticeship-project\\apprenticeship-project\\BASE_123_20250516.csv
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            // Console.Write("Write path: ");
            // string path = Console.ReadLine();
            string path =
                "C:\\Users\\mikol\\Desktop\\my_code_base\\projects\\apprenticeship-project\\apprenticeship-project\\BASE_123_20250516.csv";
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            
            Source source = new Source(@path);
            //Source.FileContent => List<>
            // foreach (var x in Source.FileContent)
            // {
            //     //Source.FileContent jest mozliwe tylko dzieki static - bez static musisz sie odwolac wtedy do zdefiniowanego wyzej Source source (czyli wywolanego konstruktora) 
            //     Console.WriteLine(x);
            // }
            // }
        }
    }
}