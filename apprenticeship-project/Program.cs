using System;
using apprenticeship_project.Model;

namespace apprenticeship_project;

internal class Program
{
    private static void Main(string[] args)
    {
        var path = @"C:\\Users\\mikol\\Desktop\\my_code_base\\projects\\apprenticeship-project\\apprenticeship-project\\BASE_123_20250516.csv";
        var source = new Source(@path);

        
        List<string> lines = new List<string>();
        var checkFileStruct = source.CheckFilesStructure;
        var fileContent = source.FileContent;
        var group = "";
        
        if (checkFileStruct)
        {
            Console.WriteLine("Group: ");
            group = Console.ReadLine();
            

            for (var i = 0; i < fileContent.Count; i++)
            {
                var splitedFileContent = fileContent[i].Split(';');
                if (splitedFileContent[4] == group)
                {
                 lines.Add(fileContent[i]);   
                }
            }

            foreach (var line in lines)
            {
                Console.WriteLine("Linia: " + line);
            }
        }

        LineModel lineModel = new LineModel("");
        
        Console.WriteLine("Group: " + lineModel.Group);
        Console.WriteLine("Date: " + lineModel.Date);
        Console.WriteLine("Value: " + lineModel.Value);
        Console.WriteLine("Quantity: " + lineModel.Quantity);
        

        // Console.WriteLine("--Data Analyse App--");
        // Console.Write("Write path to your file: ");
        // var path = Console.ReadLine();
        // var source = new Source(@path);
        // string option = "", group = "";
        // var groupOk = false;
        // var test = false;
        //
        // if (source.CheckFilesStructure)
        // {
        //     var groupsStrings = source.Groups.ToArray();
        //
        //     while (!test)
        //     {
        //         test = true;
        //         Console.Write("Avaliable groups: ");
        //         foreach (var g in groupsStrings.Distinct()) Console.Write(g + ", ");
        //
        //         Console.Write("\nSelect group: ");
        //         group = Console.ReadLine();
        //         Console.WriteLine("-----------------------------------------------------");
        //
        //         for (var i = 0; i < source.Groups.Count; i++)
        //             if (group == source.Groups[i])
        //                 groupOk = true;
        //
        //         if (!groupOk)
        //         {
        //             test = false;
        //             Console.WriteLine("Group not found.");
        //         }
        //     }
        //
        //     Console.WriteLine(
        //         "1 - Get quantity of group, 2 - Get value of group, 3 - Get date min/max of group, 4 - Get value of whole file, 0 - Exit.");
        //     Console.Write("Select option: ");
        //     option = Console.ReadLine();
        //     Console.WriteLine("-----------------------------------------------------");
        //
        //     var retrieveData = new RetrieveData();
        //     retrieveData.Data(option, group, source.FileContent);
        // }
    }
}