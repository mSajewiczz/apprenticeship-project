using System.Text.RegularExpressions;

namespace apprenticeship_project.Model;

public class SourceCheck
{
    private readonly Regex _pattern = new(@"\ABASE_\d{3}_\d{8}\.csv$");
    private static int tmp = 20;
    private readonly string _path;
    private char[] _fileNameChars = new char[tmp + 1];
    private List<char> _groupsChar = new();
    private List<string> _fileContent = new();
    private List<string> _groups = new();
    public List<string> FileContent => _fileContent;
    public List<string> Groups => _groups;

    private bool CheckFilesStruct()
    {
        var structCorrect = false;
        var semiColsCount = 0;

        for (var k = 0; k < _fileContent.Count; k++)
        {
            semiColsCount = 0;
            var line = _fileContent[k];
            for (var j = 0; j < line.Length; j++)
                if (line[j] == ';')
                    semiColsCount++;

            if (semiColsCount == 5)
            {
                structCorrect = true;
            }
            else
            {
                structCorrect = false;
                break;
            }
        }

        if (!structCorrect)
        {
            structCorrect = false;
            return structCorrect;
        }

        for (var i = 1; i < _fileContent.Count; i++)
        {
            semiColsCount = 0;
            var size = 0;
            var line = _fileContent[i];

            char[] charGroup = { };

            for (var j = 0; j < line.Length; j++)
            {
                if (line[j] == ';') semiColsCount++;

                if (semiColsCount == 4 && line[j] != ';')
                {
                    size++;
                    _groupsChar.Add(line[j + 1]);
                }
            }

            //START YOUR WORK TOMORROW HERE!
            // for (var j = 0; j < size; j++)
            // {
            //     var splitedLine = line.Split(';');
            //     splitedLine[4] 
            // }

            charGroup = new char[size];
            var tmp2 = 0;

            semiColsCount = 0;
            for (var j = 0; j < line.Length; j++)
            {
                if (line[j] == ';') semiColsCount++;

                if (semiColsCount == 4 && line[j] != ';')
                {
                    charGroup[tmp2] = line[j];
                    tmp2++;
                }
            }

            var strGroup = new string(charGroup);
            _groups.Add(strGroup);
        }
        return structCorrect;
    }

    private string GetFileName()
    {
        for (var i = _path.Length; i > 0; i--)
            if (_path[i - 1].Equals('B'))
            {
                _fileNameChars[tmp] = _path[i - 1];
                break;
            }
            else
            {
                _fileNameChars[tmp] = _path[i - 1];
                tmp--;
            }

        return new string(_fileNameChars);
    }
    public bool CheckFilesStructure => CheckFilesStruct();
    public SourceCheck(string path)
    {
        _path = path;
        var fileName = GetFileName();

        if (_pattern.IsMatch(fileName))
            try
            {
                File.Exists(fileName);
                var file = File.ReadAllText(@_path);

                foreach (var line in file.Split('\n')) _fileContent.Add(line);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error. Wrong path to file.");
            }
        else
            Console.WriteLine("Error. Unknown filename format.");
    }
}