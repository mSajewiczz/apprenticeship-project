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

            Console.WriteLine("Write group (111, 882, 232, 484): ");
            string group = Console.ReadLine();

            for (int i = 0; i < groups.Length; i++)
            {
                for (int j = 0; j < groups.Length; j++)
                {
                    if (group == groups[j])
                    {
                    
                        retrieveData.GetData(group);
                        break;
                    
                        //nested loop musui tu byc zeby przeleciec tab caly 
                    }
                    else
                    {
                        Console.WriteLine("Group not found. Try again.");
                        break;
                    }
                }
            }
        }
        
        
    }
}