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
                Sort(lines, group);
                break;
            case "4":
                GetWholeValue();
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

    public void Sort(string[] lines, string group)
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


            if (!isMaxFull)
            {
                max[0] = dayInt;
                max[1] = monthInt;
                max[2] = yearInt;

                isMaxFull = true;
            }
            else
            {
                bool isBigger = false;
                
                if (max[2] < yearInt)
                {
                    isBigger = true;
                } else if (max[2] == yearInt)
                {
                    if (max[1] < monthInt)
                    {
                        isBigger = true;
                    } else if (max[1] == monthInt)
                    {
                        if (max[0] < dayInt)
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
                    min[0] = max[0];
                    min[1] = max[1];
                    min[2] = max[2];

                    max[0] = dayInt;
                    max[1] = monthInt;
                    max[2] = yearInt;
                }
            }
            
            // Console.WriteLine("Date: " + dayInt + "." + monthInt + "." + yearInt);
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


    public void GetWholeValue()
    {
        StreamReader file = new StreamReader("C:\\Users\\mikol\\Desktop\\my_code_base\\projects\\apprenticeship-project\\apprenticeship-project\\BASE_123_20250516.csv");
        
        String line = file.ReadLine();
        
        
        List<string> lines = new List<string>();
        int tmp = 0;
        
        while (line != null)
        {
            if (tmp != 0)
            {
                lines.Add(line);
            }

            tmp++;
            line = file.ReadLine();
        }

        double[] allValuesFromFile = new double[lines.Count];

        for (int i = 0; i < lines.Count; i++)
        {
            int semiColsCounter = 0;
            char[] valueChar = {};
            string val = lines[i];
            int valLen = 0;
            
            for (int j = 0; j < val.Length; j++)
            {
                if (val[j] == ';')
                {
                    semiColsCounter++;
                }

                if (semiColsCounter == 5)
                {
                    if (val[j] != ';')
                    {
                        valLen++;
                    }
                }
            }
            //CHECKPOINT: getting length of value works! 
            // Console.WriteLine("Length of value no." + (i+1) + ": " + valLen);

            int tmp1 = 0;
            semiColsCounter = 0;
            
            valueChar = new char[valLen];
            for (int k = 0; k < val.Length; k++)
            {
                if (val[k] == ';')
                {
                    semiColsCounter++;
                }
            
                if (semiColsCounter == 5)
                {
                    if (val[k] != ';')
                    {
                        if (val[k] == '.')
                        {
                            valueChar[tmp1] = ',';
                        }
                        else
                        {
                            valueChar[tmp1] = val[k];
                        }
                        tmp1++;
                    }
                }
            
                if (semiColsCounter > 5)
                {
                    break;
                }
            }
            
            
            // foreach (var x in valueChar)
            // {
            //     Console.Write(x);
            // }

            string strVal = new string(valueChar);
            double numVal = double.Parse(strVal);
            
            //CHECKPOINT: getting value of each position in file works!
            
            // Console.Write("Num value: " + numVal);
            // Console.WriteLine();

            allValuesFromFile[i] = numVal;
        }

        foreach (var x in allValuesFromFile)
        {
            Console.WriteLine("Value from tab: " + x);
        }
        
        //CHECKPOINT: setting data to array and getting them to console.wrtiteline works!
        
            
        //valLen, linesCounter, 
        file.Close();
    }
}