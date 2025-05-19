namespace apprenticeship_project;
using System.IO;

public class RetrieveData
{
    public string GetData(string group)
    {
        String line;
            StreamReader sr = new StreamReader("C:\\Users\\mikol\\Desktop\\my_code_base\\projects\\apprenticeship-project\\apprenticeship-project\\BASE_123_20250516.csv");
            line = sr.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                line = sr.ReadLine();
            }
            sr.Close();
        return group;
    }
}