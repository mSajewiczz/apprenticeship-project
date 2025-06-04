using System.Text.RegularExpressions;

namespace apprenticeship_project.Model;

public class Source
{
    public Source(string fileName)
    {
        //BASE_[3 cyfry]_[data w formacie yyyyMMdd].csv
        //works: @"(\ABASE_)"
        
        string pattern = @"(\ABASE_)(\d{3})_(\d{8})(\.csv)$";

        if (Regex.IsMatch(fileName, pattern))
        {
            Console.WriteLine("ok");
            
        }
        else
        {
            Console.WriteLine("Unknown file format");
        }
    }
}