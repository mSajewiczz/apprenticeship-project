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

            bool isCompleted = false;
        
            
            while (line != null)
            {
                if (lineCounter != 0)
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i] == ';' && line[i + 1] == group[0] && line[i + 2] == group[1] &&
                            line[i + 3] == group[2])
                        {
                            GetValue(line, group);
                            break;
                        }
                    }
                }
                line = file.ReadLine();
                lineCounter++;
            }
            file.Close();
            
        return group;
    }

    public void GetLine(String line)
    {
       Console.WriteLine(line);
    }

    public int GetValue(String line, string group)
    {

        int id = 0;
        
        string value ="";
        int semiColonsCount = 0;
        
        for (int i = 0; i < line.Length; i++)
        {
            if (line[i] == ';')
            {
                semiColonsCount++;
            }

            if (semiColonsCount == 5)
            {
                for (int j = i+1; j < line.Length; j++)
                {
                    Console.Write(line[j]);
                }
                break;
            }
        }
        
        Console.WriteLine();
        //zwracac ma tutaj mi te value 
        return 0;
    }
}