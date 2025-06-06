using System.Text.RegularExpressions;

namespace apprenticeship_project.Model;

public class Source
{
    private readonly Regex _pattern = new Regex(@"\ABASE_\d{3}_\d{8}\.csv$");
    private static int tmp = 20;
    private char[] _fileNameChars = new char[tmp+1];
    private readonly string _path;
    private static List<string> _fileContent = new List<string>();
    private List<char> _groupsChar = new List<char>();
    private List<string> _groups = new List<string>();
    
    //static w _fileContent -> chodzi o to ze w Program.cs przy foreach nie ma konkretnego wywolania klasy tylko operacja na danej metodzie - getter do _fileContent 
    //^^^^^^^ tego nie napisalo AI :)) 

    public static List<string> FileContent
    {
        get { return _fileContent; }
    }

    private bool CheckFilesStruct()
    {
        var structCorrect = false;
        for (var i = 1; i < _fileContent.Count; i++)
        {
            var semiColsCount = 0;
            var size = 0;
            string line = _fileContent[i];
            
            char[] charGroup = {};

            for (var j = 0; j < line.Length; j++)
            {
                if (line[j] == ';')
                {
                    semiColsCount++;
                }
                
                if (semiColsCount == 4 && line[j] != ';')
                {
                    size++;
                    _groupsChar.Add(line[j+1]);
                }
            }

            charGroup = new char[size];
            var tmp2 = 0;
            
            if (semiColsCount == 5)
            {
                structCorrect = true;
            }
            else
            {
                structCorrect = false;
                break;
            }

            if (!structCorrect)
            {
                break;
            }

            semiColsCount = 0;
            for (var j = 0; j < line.Length; j++)
            {
                if (line[j] == ';')
                {
                    semiColsCount++;
                }
                
                if (semiColsCount == 4 && line[j] != ';')
                {
                    charGroup[tmp2] = line[j];
                    tmp2++;
                }
            }
            
            string strGroup = new string(charGroup);
            _groups.Add(strGroup);
            
        }
        return structCorrect;
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
        
        Console.WriteLine("-----------------------------------------------------");
        
        Console.WriteLine("Correct struct: " + CheckFilesStruct());
        
        foreach (var group in _groups)
        {
            Console.WriteLine("Group: " + group);
        }
    }
}