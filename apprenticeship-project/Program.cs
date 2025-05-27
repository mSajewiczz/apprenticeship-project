using System;
namespace apprenticeship_project
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] groups = {"111", "882", "232", "484"};
            RetrieveData retrieveData = new RetrieveData();

            Console.ForegroundColor = ConsoleColor.Green;
            
            Console.WriteLine("Get product value (write group 1 - 4): ");
            
            Console.ResetColor();
            string group = Console.ReadLine();

            switch (group)
            {
                case "1":
                    group = "111";
                    break;
                case "2":
                    group = "882";
                    break;
                case "3":
                    group = "232";
                    break;
                case "4":
                    group = "484";
                    break;
                default: 
                    Console.WriteLine("Unknown group");
                    break;
            }
            
            for (int i = 0; i < groups.Length; i++)
            {
                for (int j = 0; j < groups.Length; j++)
                {
                    if (group == groups[j])
                    {
                        retrieveData.prepareData(group);
                        break;
                    }
                }
                break;
            }
        }
    }
}