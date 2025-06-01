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
                Sort(lines, group, type);
                break;
            case "4":
                Sort(lines, group, type);
                break;
            case "5":
                GetValue(lines, group);
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
                    semiColsCount++;
                }
                
                if (semiColsCount == 2)
                {
                        if (line[j] != ';')
                        {
                            lengthOfQuantity++;
                        }
                } else if (semiColsCount > 2)
                {
                    break;
                }
            }
            
            semiColsCount = 0;
            
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
            
            string test = new string(array);
            int testValInt = int.Parse(test);
            
            tabOfAllQuantities[i] = testValInt;
        }

        int sum = 0;
        
        for(int l = 0; l < tabOfAllQuantities.Length; l++)
        {
            sum = sum + tabOfAllQuantities[l];
        }
        
        Console.WriteLine("Quantity for group no. " + group + " is: " + sum);
    }

    public void GetValue(string[] lines, string group)
    {
        int linesLen = lines.Length;
        
        double[] tabOfAllValues = new double[linesLen];
        
        for (int i = 0; i < linesLen; i++)
        {
            string line = lines[i];
            int lengthOfQuantity = 0;
            int semiColsCount = 0;
            
            for (int j = 0; j < line.Length; j++)
            {
                if (line[j] == ';')
                {
                    semiColsCount++;
                }
                
                if (semiColsCount == 5)
                {
                    if (line[j] != ';')
                    {
                        lengthOfQuantity++;
                    }
                } else if (semiColsCount > 5)
                {
                    break;
                }
            }
            
            semiColsCount = 0;
            
            char[] array = new char[lengthOfQuantity];
            int tmp = 0;

            for (int k = 0; k < line.Length; k++)
            {
                if (line[k] == ';')
                {
                    semiColsCount++;
                }
                
                if (semiColsCount == 5)
                {
                    if (line[k] != ';')
                    {
                        if (line[k] == '.')
                        {
                            array[tmp] = ',';
                        }
                        else
                        {
                            array[tmp] = line[k];
                        }
                        tmp++;
                    }
                    
                } else if (semiColsCount > 5)
                {
                    break;
                }
            }
            
            string test = new string(array);
            double testValInt = double.Parse(test);
            tabOfAllValues[i] = testValInt;
        }

        double sum = 0;
        
        for(int l = 0; l < tabOfAllValues.Length; l++)
        {
            sum = sum + tabOfAllValues[l];
        }
        
        Console.WriteLine("Value for group no. " + group + " is: " + sum);
    }

    public void Sort(string[] lines, string group, string type)
    {
        int linesLen = lines.Length;
        int[] tabOfAllDates = new int[linesLen * 3];
        
         char[] year = new char[4];
         char[] day = new char[2];
         char[] month = new char[2];

         bool isMaxFull = false;
         // bool isMinFull = false;
         
         int[] max = new int[3];
         int[] min = new int[3];
         
        
        for (int i = 0; i < linesLen; i++)
        {
            string line = lines[i];
            int semiColsCount = 0;
            int dashCount = 0;
            
            int tmp1 = 0;
            int tmp2 = 0;
            int tmp3 = 0;


            for (int k = 0; k < line.Length; k++)
            {
                if (line[k] == ';')
                {
                    semiColsCount++;
                }
                
                if (semiColsCount == 3)
                {
                    if (line[k] != ';')
                    {
                        if (line[k] == '-')
                        {
                            dashCount++;
                        }

                        if (dashCount == 0)
                        { 
                            year[tmp1] = line[k];
                            tmp1++;
                            
                        }
                        if (dashCount == 1)
                        {
                            if (line[k] != '-')
                            {
                                month[tmp2] = line[k];
                                tmp2++;    
                            }
                        }
                        if (dashCount == 2)
                        {
                            if (line[k] != '-')
                            {
                                day[tmp3] = line[k];
                                tmp3++;   
                            }
                        }
                    }
                    
                } else if (semiColsCount > 3)
                {
                    break;
                }
            }

            int yearInt = int.Parse(year);
            int monthInt = int.Parse(month);
            int dayInt = int.Parse(day);

            // Console.WriteLine("Date: " + dayInt + "." + monthInt + "." + yearInt);

            if (isMaxFull == false)
            {
                max[i] = dayInt;
                max[i+1] = monthInt;
                max[i+2] = yearInt;

                isMaxFull = true;
            }
            else
            {
                bool isBigger = false;

                for (int w = 0; w < 3; w++)
                {
                    if (max[w+2] < yearInt)
                    {
                        isBigger = true;
                    }
                    else
                    {
                        if (max[w + 1] < monthInt)
                        {
                            isBigger = true;
                        }
                        else
                        {
                            if (max[w] < dayInt)
                            {
                                isBigger = true;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    if (isBigger)
                    {
                        min[i] = max[i];
                        min[i+1] = max[i+1];
                        min[i+2] = max[i+2];
                        
                        max[i] = dayInt;
                        max[i+1] = monthInt;
                        max[i+2] = yearInt;
                    }
                }
            }
        }
        
        
        Console.Write("Max date: ");
        foreach (var maxVal in max)
        {
            Console.Write(maxVal + ".");
        }

        Console.WriteLine();
        
        Console.Write("Min date: ");
        foreach (var minVal in min)
        {
            Console.Write(minVal + ".");
        }
    }

}