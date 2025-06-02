using System.Collections.Specialized;

namespace apprenticeship_project;
using System.IO;

public class RetrieveData
{
    public void prepareData(string group, string option)
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
        List<string> date = new List<string>();
        

        for (int i = 0; i < lines.Length; i++)
        {
            int semiColsCount = 0;
            string line = lines[i];

            char[] dateArr = new char[10];
            int tmp = 0;

            for (int j = 0; j < line.Length; j++)
            {
                if (line[j] == ';')
                {
                    semiColsCount++;
                }

                if (semiColsCount == 3)
                {
                    if (line[j] != ';')
                    {
                        dateArr[tmp] = line[j];
                        tmp++;
                    }
                }

                if (semiColsCount > 3)
                {
                    break;
                }
            }

            string dateStr = new string(dateArr);
            date.Add(dateStr);
        }
        
        bool isEmpty = false;

        string max = "";
        string min = "";
        
        max = date[0];
        
        for (int i = 0; i < date.Count; i++)
        {
            string lineVal = date[i];
            for (int j = 0; j < lineVal.Length; j++)
            {
                if (max[0] < lineVal[0])
                {
                    max = lineVal;
                    break;
                }
                else if (max[1] < lineVal[1])
                {
                    max = lineVal;
                    break;
                }
                else if (max[2] < lineVal[2])
                {
                    max = lineVal;
                    break;
                }
                else if (max[3] < lineVal[3])
                {
                    max = lineVal;
                    break;
                }
                else if (max[5] < lineVal[5])
                {
                    max = lineVal;
                    break;
                }
                else if (max[6] < lineVal[6])
                {
                    max = lineVal;
                    break;
                }
                else if (max[8] < lineVal[8])
                {
                    max = lineVal;
                    break;
                }
                else if (max[9] < lineVal[9] && max[8] < lineVal[8])
                {
                    max = lineVal;
                    break;
                }
                else
                {
                    min = lineVal;
                    break;
                }
            }
        }

        Console.WriteLine("Max: " + max);
        Console.WriteLine("Min: " + min);
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
            string strVal = new string(valueChar);
            double numVal = double.Parse(strVal);

            allValuesFromFile[i] = numVal;
        }

        double sum = 0; 
        foreach (var val in allValuesFromFile)
        {
            sum += val;
        }
        
        Console.WriteLine("Sum of value of whole file: " + Math.Round(sum, 2));
        file.Close();
    }
}