using System.Text.RegularExpressions;

namespace apprenticeship_project.Model;

public class Source
{
    private readonly Regex _pattern = new Regex(@"\ABASE_\d{3}_\d{8}\.csv$");
    private static int tmp = 20;
    private char[] _fileNameChars = new char[tmp+1];
    private readonly string _path;
    private static List<string> _fileContent = new List<string>();
    
    //static w _fileContent -> chodzi o to ze w Program.cs przy foreach nie ma konkretnego wywolania klasy tylko operacja na danej metodzie - getter do _fileContent 
    //^^^^^^^ tego nie napisalo AI :)) 

    public static List<string> FileContent
    {
        get { return _fileContent; }
    }

    private string GetFileName()
    {
        for (var i = _path.Length; i >= 0; i--)
        {
            if (_path[i-1].Equals('B'))
            {
                _fileNameChars[tmp] = _path[i-1];
                break;
            }
            else
            {
                _fileNameChars[tmp] = _path[i-1];
                tmp--;
            }
        }

        return new string(_fileNameChars);
    }
    
    public Source(string path)
    {
        _path = path;
        var fileName = GetFileName();
        
        if (_pattern.IsMatch(fileName))
        {
            try
            {
                File.Exists(fileName);
                var file = File.ReadAllText(@_path);

                foreach (var line in file.Split('\n'))
                {
                    _fileContent.Add(line);    
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Error. Something went wrong.");
            }
        }
        else
        {
            Console.WriteLine("Unknown file format. Try again.");
        }
    }
}