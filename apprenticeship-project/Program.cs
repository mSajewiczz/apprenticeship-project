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
            while (!test)
            {
                test = true;
                Console.WriteLine(
                    "1 - Get quantity of group, 2 - Get value of group, 3 - Get date min/max of group, 4 - Get value of whole file, 0 - Exit.");
                Console.Write("Select option: ");
                option = Console.ReadLine();

                switch (option)
                {
                    case "0":
                        Console.WriteLine("Bye!");
                        break;
                    case "1":
                        option = "1";
                        break;
                    case "2":
                        option = "2";
                        break;
                    case "3":
                        option = "3";
                        break;
                    case "4":
                        option = "4";
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        test = false;
                        break;
                }

                string[] groupsStrings = source.Groups.ToArray();

                Console.Write("Avaliable groups: ");
                foreach (var g in groupsStrings.Distinct())
                {
                    Console.Write(g + ", ");
                }

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
            
            RetrieveData retrieveData = new RetrieveData();
            retrieveData.Data(option, group, source.FileContent);
        }
    }
}