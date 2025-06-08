using System.Collections.Specialized;

namespace apprenticeship_project;

using System.IO;

public class RetrieveData
{
    public void Data(string option, string group, List<string> fileContent)
    {
        
        List<string> lines = new List<string>();
        var groupLen = 0;
        for (var k = 0; k < group.Length; k++)
        {
            groupLen++;
        }
        
        for (var i = 0; i < fileContent.Count; i++)
        {
            var tmp = 0;
            string fileLine = fileContent[i];
            int semiColsCount = 0;
            
            for(var j = 0; j < fileLine.Length; j++)
            {
                if (fileLine[j] == ';')
                {
                    semiColsCount++;
                }

                if (semiColsCount == 4 && fileLine[j] == group[tmp])
                {
                    tmp++;
                }
            }

            if (tmp == groupLen)
            {
                lines.Add(fileLine);
            }
        }
        
        //chce zrobic takie cos ze metody beda dostawac tylko te linie gdzie jest grupa zeby 
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
                    GetQuantity(lines, group);
                    break;
                case "2":
                    GetValue(fileContent, group);
                    break;
                case "3":
                    GetDate(fileContent, group);
                    break;
                case "4":
                    GetValueOfFile(fileContent);
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
                Console.WriteLine("-----------------------------------------------------");
            }
        }
    }

    private void GetQuantity(List<string> lines, string group)
    {

        foreach (var line in lines)
        {
            Console.WriteLine("LINE: " + line);
        }
        
        // var quantities = new List<int>();
        // var semiColsCount = 0;
        // var counter = 0;
        //
        // for (var i = 0; i < fileContent.Count; i++)
        // {
        //     var tmp = 0;
        //     var line = fileContent[i];
        //     var quantityArr = new char[line.Length];
        //
        //     for (var j = 0; j < line.Length; j++)
        //     {
        //         if (line[j] == ';')
        //         {
        //             semiColsCount++;
        //         }
        //         
        //         if (semiColsCount == 2 && line[j] != ';')
        //         {
        //             quantityArr[tmp] = line[j];
        //             tmp++;
        //         }
        //     }
        //
        //     var x = new string(quantityArr);
        //     quantities.Add(int.Parse(x));
        //
        //     ///Users/mikolajsajewicz/Documents/everything to restore/my-code-base/cs/apprenticeship-project/apprenticeship-project/BASE_123_20250516.csv
        //     // 
        // }
        //
        //
        // var result = 0;
        // foreach (var quantityItem in quantities) result += quantityItem;
        // Console.WriteLine("Result for group no. " + group + ": " + result);
    }

    private void GetValue(List<string> fileContent, string group)
    {
        Console.WriteLine("2 Works!");
    }

    private void GetDate(List<string> fileContent, string group)
    {
        Console.WriteLine("3 Works!");
    }

    private void GetValueOfFile(List<string> fileContent)
    {
        Console.WriteLine("4 Works!");
    }
}