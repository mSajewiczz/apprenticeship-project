using System.Collections.Specialized;

namespace apprenticeship_project;
using System.IO;

public class RetrieveData
{
    public void prepareData(string group, string option)
    {
        // Console.WriteLine("test");
        //tutaj test tego czy przy wyszukiwaniu kolejnego elementu tez on sie zaczyna od goruy 
        int lineCounter = 0;
        int counterOfLines = 0;

        String line;
        StreamReader file =
            new StreamReader(
                "C:\\Users\\mikol\\Desktop\\my_code_base\\projects\\apprenticeship-project\\apprenticeship-project\\BASE_123_20250516.csv");
        line = file.ReadLine();

        string[] lines = { "", "", "" };

        while (line != null)
        {
            if (lineCounter != 0)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    //ten if ponizej sprawdza czy dana linia ma dana grupe 

                    if (line[i] == ';' && line[i + 1] == group[0] && line[i + 2] == group[1] &&
                        line[i + 3] == group[2])
                    {
                        //tutaj ta metoda ona wyciaga:
                        //- dana linie pliku,
                        //- podana przez usera grupe

                        lines[counterOfLines] = line;

                        counterOfLines++;
                        break;
                    }
                }
            }

            line = file.ReadLine();
            lineCounter++;
        }

        file.Close();

        Sort(lines, group, option);
    }

    public void GetQuantity(string[] lines, string group)
    {
        //grupe + tablice lin gdzie sa informacje wszystkie

        string[] values = new string[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            int semiConlonsCounter = 0;
            
            string line = lines[i];

            for (int j = 0; j < line.Length; j++)
            {
                if (line[j] == ';')
                {
                    semiConlonsCounter++;
                }

                if (semiConlonsCounter == 2)
                {
                    Console.Write(line[j]);
                }
            }
            Console.WriteLine();
        }
        
    }

    public void GetValue(string[] lines, string group)
    {
        for (int i = 0; i < lines.Length; i++)
        {
            int semiConlonsCounter = 0;

            string line = lines[i];

            for (int j = 0; j < line.Length; j++)
            {
                if (line[j] == ';')
                {
                    semiConlonsCounter++;
                }

                if (semiConlonsCounter == 5)
                {
                    Console.Write(line[j]);
                }
            }

            Console.WriteLine();
        }
    }

    public void Sort(string[] lines, string group, string type)
    {
        int day, month, year;
        
        for (int i = 0; i < lines.Length; i++)
        {
            int semiConlonsCounter = 0;

            string line = lines[i];

            for (int j = 0; j < line.Length; j++)
            {
                if (line[j] == ';')
                {
                    semiConlonsCounter++;
                }

                if (semiConlonsCounter == 3)
                {
                    Console.Write(line[j]);
                }
            }

            Console.WriteLine();
        }
        
    }

}