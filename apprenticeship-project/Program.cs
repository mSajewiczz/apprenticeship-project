using System;
namespace apprenticeship_project
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            
            
            string[] groups = {"111", "882", "232", "484"};
            
            // string group = "";
            RetrieveData retrieveData = new RetrieveData();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Write group (111, 882, 232, 484): ");
            Console.ResetColor();
            string group = Console.ReadLine();

            bool found = false;
            

            for (int i = 0; i < groups.Length; i++)
            {
                for (int j = 0; j < groups.Length; j++)
                {
                    if (group == groups[j])
                    {
                        found = true;
                        retrieveData.GetData(group);
                        break;
                    }
                }
                
                if (!found)
                {
                    
                    Console.WriteLine("Group not found. Try again.");
                } 
                break;
            }
        }
        
        
    }
}