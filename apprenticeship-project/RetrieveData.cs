using System.Collections.Specialized;

namespace apprenticeship_project;

using System.IO;

public class RetrieveData
{
    public void Data(string option, string group, List<string> fileContent)
    {
        var lines = new List<string>();
        var groupLen = 0;
        for (var k = 0; k < group.Length; k++) groupLen++;

        for (var i = 0; i < fileContent.Count; i++)
        {
            var tmp = 0;
            var fileLine = fileContent[i];
            var semiColsCount = 0;

            for (var j = 0; j < fileLine.Length; j++)
            {
                if (fileLine[j] == ';') semiColsCount++;

                if (semiColsCount == 4 && fileLine[j] == group[tmp]) tmp++;
            }

            if (tmp == groupLen) lines.Add(fileLine);
        }

        var checkOption = false;
        while (!checkOption)
        {
            checkOption = true;

            switch (option)
            {
                case "0":
                    Console.WriteLine("Bye!");
                    break;
                case "1":
                    GetQuantity(lines);
                    break;
                case "2":
                    GetValue(lines);
                    break;
                case "3":
                    GetDate(lines);
                    break;
                case "4":
                    GetValueOfFile(fileContent);
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    checkOption = false;
                    break;
            }

            if (!checkOption)
            {
                Console.Write("Select option: ");
                option = Console.ReadLine();
                Console.WriteLine("-----------------------------------------------------");
            }
        }
    }

    private void GetQuantity(List<string> lines)
    {
        var semiColsCount = 0;
        var quantityLen = 0;

        var quantities = new int[lines.Count];

        for (var i = 0; i < lines.Count; i++)
        {
            var line = lines[i];
            for (var j = 0; j < line.Length; j++)
            {
                if (line[j] == ';') semiColsCount++;

                if (semiColsCount == 2 && line[j] != ';') quantityLen++;
            }

            var quantityCharArr = new char[quantityLen];
            var tmp = 0;
            semiColsCount = 0;

            for (var j = 0; j < line.Length; j++)
            {
                if (line[j] == ';') semiColsCount++;

                if (semiColsCount == 2 && line[j] != ';')
                {
                    quantityCharArr[tmp] = line[j];
                    tmp++;
                }
            }

            var quantityStr = new string(quantityCharArr);

            var quantity = int.Parse(quantityStr);
            quantities[i] = quantity;
        }

        var result = 0;
        foreach (var quantity in quantities) result += quantity;

        Console.WriteLine("Result: " + result);
        Console.WriteLine("-----------------------------------------------------");
    }

    private void GetValue(List<string> lines)
    {
        var semiColsCount = 0;
        var valLen = 0;

        var values = new double[lines.Count];

        for (var i = 0; i < lines.Count; i++)
        {
            var line = lines[i];
            for (var j = 0; j < line.Length; j++)
            {
                if (line[j] == ';') semiColsCount++;

                if (semiColsCount == 5 && line[j] != ';') valLen++;
            }

            var valueCharArr = new char[valLen];
            var tmp = 0;
            semiColsCount = 0;

            for (var j = 0; j < line.Length; j++)
            {
                if (line[j] == ';') semiColsCount++;

                if (semiColsCount == 5 && line[j] != ';' && line[j] != '.')
                {
                    valueCharArr[tmp] = line[j];
                    tmp++;
                }
                else if (line[j] == '.')
                {
                    valueCharArr[tmp] = ',';
                    tmp++;
                }
            }

            var valueStr = new string(valueCharArr);

            var value = double.Parse(valueStr);
            values[i] = value;
        }

        double result = 0;
        foreach (var value in values) result += value;

        Console.WriteLine("Result: " + result);
        Console.WriteLine("-----------------------------------------------------");
    }

    private void GetDate(List<string> lines)
    {
        var dates = new string[lines.Count];
        for (var i = 0; i < lines.Count; i++)
        {
            var semiColsCount = 0;
            var dateArr = new char[10];
            var tmp = 0;
            var line = lines[i];

            for (var j = 0; j < line.Length; j++)
            {
                if (line[j] == ';') semiColsCount++;

                if (semiColsCount == 3 && line[j] != ';')
                {
                    dateArr[tmp] = line[j];
                    tmp++;
                }

                if (semiColsCount > 3) break;
            }

            dates[i] = new string(dateArr);
        }

        var maxDate = new DateTime();
        var currentDate = new DateTime();
        var minDate = new DateTime();

        var iterations = true;

        foreach (var date in dates)
        {
            currentDate = DateTime.Parse(date);

            if (iterations)
            {
                maxDate = DateTime.Parse(date);
                iterations = false;
            }

            if (maxDate < currentDate)
                maxDate = currentDate;
            else
                minDate = currentDate;
        }

        Console.WriteLine("Max Date: " + maxDate.ToString("yyyy-MM-dd"));
        Console.WriteLine("Min Date: " + minDate.ToString("yyyy-MM-dd"));
        Console.WriteLine("-----------------------------------------------------");

        // /Users/mikolajsajewicz/Documents/everything to restore/my-code-base/cs/apprenticeship-project/apprenticeship-project/BASE_123_20250516.csv
        // C:\\Users\\mikol\\Desktop\\my_code_base\\projects\\apprenticeship-project\\apprenticeship-project\\BASE_123_20250516.csv
    }

    private void GetValueOfFile(List<string> fileContent)
    {
        var values = new double[fileContent.Count];
        var semiColsCount = 0;
        var valLen = 0;

        for (var i = 1; i < fileContent.Count; i++)
        {
            var line = fileContent[i];
            for (var j = 0; j < line.Length; j++)
            {
                if (line[j] == ';') semiColsCount++;

                if (semiColsCount == 5 && line[j] != ';') valLen++;
            }

            var valueCharArr = new char[valLen];
            var tmp = 0;
            semiColsCount = 0;

            for (var j = 0; j < line.Length; j++)
            {
                if (line[j] == ';') semiColsCount++;

                if (semiColsCount == 5 && line[j] != ';' && line[j] != '.')
                {
                    valueCharArr[tmp] = line[j];
                    tmp++;
                }
                else if (line[j] == '.')
                {
                    valueCharArr[tmp] = ',';
                    tmp++;
                }
            }

            var valueStr = new string(valueCharArr);
            var value = double.Parse(valueStr);
            values[i - 1] = value;
        }

        double result = 0;
        foreach (var value in values) result += value;

        Console.WriteLine("Sum of value for whole file: " + result);
        Console.WriteLine("----------------------------------------------------");
    }
}