using System;
namespace apprenticeship_project
{
    class Program
    {
        static void Main(string[] args)
        {
            string group;
            RetrieveData retrieveData = new RetrieveData();
            
            Console.WriteLine("Write group: ");
            group = Console.ReadLine();
            
            retrieveData.GetData(group);
        }
    }
}