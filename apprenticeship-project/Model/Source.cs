using System.Text.RegularExpressions;

namespace apprenticeship_project.Model;

public class Source
{
    private Regex pattern = new Regex(@"\ABASE_\d{3}_\d{8}\.csv$");
    private static int tmp = 20;
    private char[] _fileNameChars = new char[tmp+1];
    private string path;

    private string GetFileName()
    {
        for (int i = path.Length; i >= 0; i--)
        {
            if (path[i-1].Equals('B'))
            {
                _fileNameChars[tmp] = path[i-1];
                break;
            }
            else
            {
                _fileNameChars[tmp] = path[i-1];
                tmp--;
            }
        }

        return new string(_fileNameChars);
    }
    
    public Source(string path)
    {
        //BASE_[3 cyfry]_[data w formacie yyyyMMdd].csv
        //works: @"(\ABASE_)(\d{3})_(\d{8})(\.csv)$";
        
        this.path = path;
        string fileName = GetFileName();
        
        if (pattern.IsMatch(fileName))
        {
            Console.WriteLine("Name of file: " + fileName);
            
            try
            {
                Console.WriteLine("ok");
                Console.WriteLine("Directory exsists: " + Directory.Exists(path));
                Console.WriteLine("File exsists: " + File.Exists(path));
                
                Console.WriteLine(File.ReadAllText(@path));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
                
            }
        }
        else
        {
            Console.WriteLine("Unknown file format. Try again.");
        }
    }
}