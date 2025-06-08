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
        List<int> quantities = new ();
        var semiColsCount = 0;
        var counter = 0;
        
        
        for (var i = 0; i < FileContent.Count; i++)
        {
            List<char> quantityArr = new ();
            string line = FileContent[i];
        
            for (var j = 0; j < line.Length; j++)
            {
                if (line[j] == ';')
                {
                    semiColsCount++;
                }
        
                if (semiColsCount == 2 && line[j] != ';')
                {
                    quantityArr.Add(line[j]);
                }
            }
            ///Users/mikolajsajewicz/Documents/everything to restore/my-code-base/cs/apprenticeship-project/apprenticeship-project/BASE_123_20250516.csv
            
            var quantityStr = quantityArr; 
            var quantity = int.Parse(quantityStr.ToArray());
            quantities.Add(quantity);
        }

        foreach (var item in quantities)
        {
            Console.WriteLine(item);
        }
        
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