using System.Collections.Specialized;

namespace apprenticeship_project;
using System.IO;

public class RetrieveData
{
    public string GetLine(string group)
    {
        int lineCounter = 0;
        
        String line;
            StreamReader file = new StreamReader("C:\\Users\\mikol\\Desktop\\my_code_base\\projects\\apprenticeship-project\\apprenticeship-project\\BASE_123_20250516.csv");
            line = file.ReadLine();
            
            //tu jest ten header
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
        return group;
    }

    public int GetValue()
    {
        
        return 0;
    }
}