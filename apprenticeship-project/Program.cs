using System;
using apprenticeship_project.Model;

namespace apprenticeship_project;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("--Data Analyse App--");
        Console.Write("Write path to your file: ");
        var path = Console.ReadLine();
        var source = new Source(@path);
        string option = "", group = "";
        var groupOk = false;
        var test = false;

        if (source.CheckFilesStructure)
        {
            var groupsStrings = source.Groups.ToArray();

            while (!test)
            {
                test = true;
                Console.Write("Avaliable groups: ");
                foreach (var g in groupsStrings.Distinct()) Console.Write(g + ", ");

                Console.Write("\nSelect group: ");
                group = Console.ReadLine();

                for (var i = 0; i < source.Groups.Count; i++)
                    if (group == source.Groups[i])
                        groupOk = true;

                if (groupOk)
                {
                    Console.WriteLine("OK");
                }
                else
                {
                    test = false;
                    Console.WriteLine("Group not found.");
                }
            }
            
            Console.WriteLine(
                "1 - Get quantity of group, 2 - Get value of group, 3 - Get date min/max of group, 4 - Get value of whole file, 0 - Exit.");
            Console.Write("Select option: ");
            option = Console.ReadLine();

            var retrieveData = new RetrieveData();
            retrieveData.Data(option, group, source.FileContent);
        }
    }
}