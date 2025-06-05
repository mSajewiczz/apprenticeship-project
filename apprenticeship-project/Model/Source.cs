using System.Text.RegularExpressions;

namespace apprenticeship_project.Model;

public class Source
{
    public Source(string path)
    {
        //BASE_[3 cyfry]_[data w formacie yyyyMMdd].csv
        //works: @"(\ABASE_)(\d{3})_(\d{8})(\.csv)$";
        
        Regex pattern = new Regex(@"\ABASE_\d{3}_\d{8}\.csv$");
        int tmp = 20;
        char[] fileNameChars = new char[tmp+1];
        for (int i = path.Length; i >= 0; i--)
        {
            //1. user podaje sciezke do pliku 
            //2. sprawdzasz czy sciezka jest po / czy po // 
            //3. szukasz BASE zeby sprawdzic regex 
            //4. wycinasz zgodny z regexem file name
        
            if (path[i-1].Equals('B'))
            {
                fileNameChars[tmp] = path[i-1];
                break;
            }
            else
            {
                fileNameChars[tmp] = path[i-1];
                tmp--;
            }
        }
        string fileName = new string(fileNameChars);
        
        Console.WriteLine("Name of file: " + fileName);
        
        if (pattern.IsMatch(fileName))
        {
            try
            {
                Console.WriteLine("ok");
                Console.WriteLine("Directory exsists: " + Directory.Exists(path));
                Console.WriteLine("File exsists: " + File.Exists(path));
                
                
                // string[] list = Directory.GetFiles(@path, "*.csv", SearchOption.AllDirectories);
                // foreach (string file in list)
                // {
                //     Console.WriteLine(file);
                // }

                Console.WriteLine(File.ReadAllText(@path));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
                throw;
            }
        }
        else
        {
            Console.WriteLine("Unknown file format. Try again.");
        }
    }
}