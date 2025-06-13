using System.Text.RegularExpressions;

namespace apprenticeship_project.Model;

public class DataModel
{
    private readonly Regex _pattern = new(@"\ABASE_\d{3}_\d{8}\.csv$");
    private readonly string _path;
    private List<string> _fileContent = new();
    private static int tmp = 20;
    private char[] _fileNameChars = new char[tmp + 1];
    
    public Regex Pattern => _pattern;
    public string GetFileName => _getFileName();
    public bool CheckFileStruct => _checkFileStruct();
    
    
    private string _getFileName()
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
        //returns name of file as string
        return new string(_fileNameChars);
    }

    private bool _checkFileStruct()
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
        
        //returns if file struct is ok
        return structCorrect;
    }
}