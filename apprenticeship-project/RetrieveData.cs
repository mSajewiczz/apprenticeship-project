using System.Collections.Specialized;

namespace apprenticeship_project;
using System.IO;

public class RetrieveData
{
    public string prepareData(string group)
    {
        int lineCounter = 0;
        
        String line;
            StreamReader file = new StreamReader("C:\\Users\\mikol\\Desktop\\my_code_base\\projects\\apprenticeship-project\\apprenticeship-project\\BASE_123_20250516.csv");
            line = file.ReadLine();
        
            
            // while (line != null)
            // {
            //     if (lineCounter != 0)
            //     {
            //         for (int i = 0; i < line.Length; i++)
            //         {
            //             if (line[i] == ';' && line[i + 1] == group[0] && line[i + 2] == group[1] &&
            //                 line[i + 3] == group[2])
            //             {
            //                 Console.WriteLine(line);
            //             }
            //         }
            //     }
            //     line = file.ReadLine();
            //     lineCounter++;
            // }
            // file.Close();
            
            GetLine(group, line, file);
        return group;
    }

    public void GetLine(string group, String line, StreamReader file)
    {
        int lineCounter = 0;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(line);
        Console.ResetColor();
        
        while (line != null)
        {
            if (lineCounter != 0)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == ';' && line[i + 1] == group[0] && line[i + 2] == group[1] &&
                        line[i + 3] == group[2])
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            line = file.ReadLine();
            lineCounter++;
        }
        file.Close();
    }

    public int GetValue()
    {
        Console.WriteLine("To get value write number of group (1 - 4): ");
        
        
        //zwracac ma tutaj mi te value 
        return 0;
    }
}