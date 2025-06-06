using System;
using apprenticeship_project.Model;

namespace apprenticeship_project;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("--Data Analyse App--");
        Console.Write("Write path to your file: ");
        string path = Console.ReadLine();
        var source = new Source(@path);

        if (source.CheckFilesStructure)
        {
            Console.WriteLine("1 - Get quantity of group, 2 - Get value of group, 3 - Get date min/max of group, 4 - Get value of whole file, 0 - Exit.");
            Console.Write("Select option: ");
            string option = Console.ReadLine();
            
            foreach (var x in Source.FileContent) Console.WriteLine(x);
        }
        
        
       
        
        
        // Console.WriteLine("---------------------------------------------------------------------------------------------------------");
        // Console.Write("Write path: ");
        // string path = Console.ReadLine();
        // var path =
        //     "C:\\Users\\mikol\\Desktop\\my_code_base\\projects\\apprenticeship-project\\apprenticeship-project\\BASE_123_20250516.csv";
        // Console.WriteLine("---------------------------------------------------------------------------------------------------------");
        
        
        // Source.FileContent => List<>

    }
}