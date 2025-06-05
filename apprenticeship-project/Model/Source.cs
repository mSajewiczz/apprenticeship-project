using System.Text.RegularExpressions;

namespace apprenticeship_project.Model;

public class Source
{
    public Source(string fileName)
    {
        //BASE_[3 cyfry]_[data w formacie yyyyMMdd].csv
        //works: @"(\ABASE_)(\d{3})_(\d{8})(\.csv)$";
        
        Regex pattern = new Regex(@"\ABASE_\d{3}_\d{8}\.csv$");

        if (pattern.IsMatch(fileName))
        {
            try
            {
                Console.WriteLine("ok");
                
                string[] list = Directory.GetFiles(@"C:\Users\mikol\Desktop\my_code_base\projects\apprenticeship-project\apprenticeship-project\", "*.csv", SearchOption.AllDirectories);
                foreach (string file in list)
                {
                    Console.WriteLine(file);
                }
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