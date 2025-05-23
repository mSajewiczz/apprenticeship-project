namespace apprenticeship_project;
using System.IO;

public class RetrieveData
{
    public string GetData(string group)
    {
        int lineCounter = 0;
        
        String line;
            StreamReader file = new StreamReader("C:\\Users\\mikol\\Desktop\\my_code_base\\projects\\apprenticeship-project\\apprenticeship-project\\BASE_123_20250516.csv");
            line = file.ReadLine();
            while (line != null)
            {
                if (lineCounter != 0)
                {
                    // Console.WriteLine(line); //tu cale zdania sa

                    for (int i = 0; i < line.Length; i++)
                    {
                        // Console.WriteLine(line[i]);

                        if (line[i] == ';' && line[i+1] == group[0] && line[i+2] == group[1] && line[i+3] == group[2])
                        {
                            Console.WriteLine("ok");
                        }
                        
                        
                        
                        //tutaj lecisz znakami 
                    }
                }
                
                line = file.ReadLine();
                lineCounter++;
                
            }
            file.Close();
            
            
        return group;
    }
}