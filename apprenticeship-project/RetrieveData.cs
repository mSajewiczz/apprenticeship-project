using System.Collections.Specialized;

namespace apprenticeship_project;
using System.IO;

public class RetrieveData
{
    public void prepareData(string group, string option, string type)
    {
        int lineCounter = 0;
        int counterOfLines = 0;

        String line;
        StreamReader file = new StreamReader("C:\\Users\\mikol\\Desktop\\my_code_base\\projects\\apprenticeship-project\\apprenticeship-project\\BASE_123_20250516.csv");
        line = file.ReadLine();

        string[] lines = {};
        int tmp = 0;

        while (line != null)
        {
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == ';' && line[i + 1] == group[0] && line[i + 2] == group[1] &&
                        line[i + 3] == group[2])
                    {
                        counterOfLines++;
                    }
                }
                
            line = file.ReadLine();
            lineCounter++;
        }
        file.Close();

        lines = new string[counterOfLines];

        String line2;
        StreamReader file2 = new StreamReader("C:\\Users\\mikol\\Desktop\\my_code_base\\projects\\apprenticeship-project\\apprenticeship-project\\BASE_123_20250516.csv");
        line2 = file2.ReadLine();
        while (line2 != null)
        {
            for (int i = 0; i < line2.Length; i++)
            {
                if (line2[i] == ';' && line2[i + 1] == group[0] && line2[i + 2] == group[1] &&
                    line2[i + 3] == group[2])
                {
                    lines[tmp] = line2;
                    tmp++;
                }
            }
            line2 = file2.ReadLine();
            lineCounter++;
        }
        file.Close();

        switch (option)
        {
            case "1":
                GetQuantity(lines, group); 
                break;
            case "2":
                GetValue(lines, group);
                break;
            case "3":
                break;
            case "4":
                break;
            case "5":
                break;
        }
    }

    public void GetQuantity(string[] lines, string group)
    {
        int linesLen = lines.Length;
        
        int[] tabOfAllQuantities = new int[linesLen];
        
        for (int i = 0; i < linesLen; i++)
        {
            string line = lines[i];
            int lengthOfQuantity = 0;
            int semiColsCount = 0;
            
            for (int j = 0; j < line.Length; j++)
            {
                if (line[j] == ';')
                {
                    //tutaj liczysz ile ; juz wystapilo
                    semiColsCount++;
                }
                
                if (semiColsCount == 2)
                {
                        //tutaj masz dlugosc danej wartosci
                        if (line[j] != ';')
                        {
                            lengthOfQuantity++;
                        }
                } else if (semiColsCount > 2)
                {
                    //przerwanie po odczytaniu dlugosci
                    break;
                }
            }
            
            semiColsCount = 0;
            // Console.WriteLine("Quantity len: " + lengthOfQuantity);
            
            char[] array = new char[lengthOfQuantity];
            int tmp = 0;

            for (int k = 0; k < line.Length; k++)
            {
                if (line[k] == ';')
                {
                    semiColsCount++;
                }
                
                if (semiColsCount == 2)
                {
                    if (line[k] != ';')
                    {
                        array[tmp] = line[k];
                        tmp++;
                    }
                    
                } else if (semiColsCount > 2)
                {
                    break;
                }
            }

            // Console.Write("Value of char arr: ");
            // foreach (var val in array)
            // {
            //     Console.Write(val);
            // }
            
            // Console.WriteLine();

            string test = new string(array);
            int testValInt = int.Parse(test);
            
            tabOfAllQuantities[i] = testValInt;
        }

        int sum = 0;
        
        for(int l = 0; l < tabOfAllQuantities.Length; l++)
        {
            sum = sum + tabOfAllQuantities[l];
        }

        // Console.WriteLine("tabOfAllQuantities.Length: " + tabOfAllQuantities.Length);
        Console.WriteLine("Quantity for group no. " + group + ": " + sum);
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
        string year = "0000";
        
        for (int i = 0; i < lines.Length; i++)
        {
            
            char[] arr = year.ToCharArray();
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
                    
                    arr[j] = line[j+1];
                }
            }
            
            year = new string(arr);

            Console.WriteLine(year);
        }
        
    }

}