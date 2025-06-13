using System;
using apprenticeship_project.Model;

namespace apprenticeship_project;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("--CSV files analyse app--");
        Console.Write("Write path to your file: ");
        var path = Console.ReadLine();
        
        var source = new Source(@path);
        var lines = new List<string>();
        var linesModel = new List<LineModel>();
        var checkFileStruct = source.CheckFilesStructure;
        var fileContent = source.FileContent;

        if (checkFileStruct)
        {
            Console.WriteLine("Group: ");
            var group = Console.ReadLine();
            
            for (var i = 0; i < fileContent.Count; i++)
            {
                var splitedFileContent = fileContent[i].Split(';');
                if (splitedFileContent[4] == group) lines.Add(fileContent[i]);
            }

            for (var i = 0; i < lines.Count; i++)
            {
                var line = lines[i];
                var lineModel = new LineModel(line);

                linesModel.Add(lineModel);
            }

            foreach (var line in linesModel)
                Console.WriteLine("Group: " + line.Group + ", value: " + line.Value + ", quantity: " + line.Quantity +
                                  ", date: " + line.Date);
        }
        else
        {
            Console.WriteLine("Unknown file structure.");
        }
    }
}