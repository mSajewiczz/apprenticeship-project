using System.Collections.Specialized;

namespace apprenticeship_project;

using System.IO;

public class RetrieveData
{
    public void Data(string option, string group, List<string> FileContent)
    {
        var checkOption = false;

        while (!checkOption)
        {
            checkOption = true;

            switch (option)
            {
                case "0":
                    Console.WriteLine("Bye!");
                    break;
                case "1":
                    GetQuantity(FileContent, group);
                    break;
                case "2":
                    GetValue(FileContent, group);
                    break;
                case "3":
                    GetDate(FileContent, group);
                    break;
                case "4":
                    GetValueOfFile(FileContent);
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    checkOption = false;
                    break;
            }
            
            if (!checkOption)
            {
                Console.Write("Select option: ");
                option = Console.ReadLine();
            }
        }
    }

    private void GetQuantity(List<string> FileContent, string group)
    {
        Console.WriteLine("1 Works!");
    }

    private void GetValue(List<string> FileContent, string group)
    {
        Console.WriteLine("2 Works!");
    }

    private void GetDate(List<string> FileContent, string group)
    {
        Console.WriteLine("3 Works!");
    }

    private void GetValueOfFile(List<string> FileContent)
    {
        Console.WriteLine("4 Works!");
    }
}