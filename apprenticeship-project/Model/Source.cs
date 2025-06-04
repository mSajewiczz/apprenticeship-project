using System.Text.RegularExpressions;

namespace apprenticeship_project.Model;

public class Source
{
    public Source(string fileName)
    {
        //BASE_[3 cyfry]_[data w formacie yyyyMMdd].csv
        //works: @"(\ABASE_)(\d{3})_(\d{8})(\.csv)$";
        
        const string pattern = @"\ABASE_\d{3}_\d{8}\.csv$";

        if (Regex.IsMatch(fileName, pattern))
        {
            try
            {
                Console.WriteLine("ok");
                var fileExists = File.Exists(fileName);
                var directoryExists = Directory.Exists(fileName);

                string[] list = Directory.GetFiles(@"c:\", "c*", SearchOption.AllDirectories);

                foreach (string file in list)
                {
                    Console.WriteLine(file);
                }

                Console.WriteLine("File exists: " + fileExists);
                Console.WriteLine("Directory exists: " + directoryExists);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        else
        {
            Console.WriteLine("Unknown file format. Try again.");
        }
    }
}