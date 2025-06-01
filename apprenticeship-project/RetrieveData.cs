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

        GetQuantity(lines, group);
    }

    public void GetQuantity(string[] lines, string group)
    {
        //grupe + tablice lin gdzie sa informacje wszystkie
        
        //char[] -> string -> double 
        int tmp = 0; //to jest to id do arraya charow 
        
        for (int i = 0; i < lines.Length; i++)
        {
            char[] array;
            int quantityLen = 0;
            int quantityNum = 0;
            
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
                    quantityLen++;
                }
            }
            
            
            array = new char[quantityLen];
            
            for (int j = 0; j < line.Length; j++)
            {
                if (line[j] == ';')
                {
                    semiConlonsCounter++;
                }

                if (semiConlonsCounter == 2)
                {
                    if (line[j] != ';')
                    {
                        array[tmp] = line[j];
                        tmp++;
                    }
                  
                }
            }
            
            string quantity = new string(array);
            quantityNum = int.Parse(quantity);
            Console.WriteLine(quantityNum);
            tmp = 0;
        }
        
       
       // for (int i = 0; i < lines.Length; i++)
       // {
       //     int semiConlonsCounter = 0;
       //     string line = lines[i];

           // for (int j = 0; j < line.Length; j++)
           // {
           //     if (line[j] == ';')
           //     {
           //         semiConlonsCounter++;
           //     }
           //
           //     if (semiConlonsCounter == 2)
           //     {
           //         if (line[j] != ';')
           //         {
           //             array[tmp] = line[j];
           //             tmp++;
           //         }
           //        
           //     }
           // }
           
           // string quantity = new string(array);
           
           // if (quantityNum == 0)
           // {
           //     quantityNum = int.Parse(quantity);
           //     array = new char[quantityLen];
           // }
           // else
           // {
           //     int curr = int.Parse(quantity);
           //     quantityNum = quantityNum + curr;
           // }
           
           // Console.WriteLine(quantityNum);
       // }
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