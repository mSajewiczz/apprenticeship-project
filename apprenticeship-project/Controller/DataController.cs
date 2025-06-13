using apprenticeship_project.Model;

namespace apprenticeship_project.Controller;

public class DataController
{
    public DataController()
    {
        Console.WriteLine("--CSV files analyse app--");
        Console.Write("Write path to your file: ");
        var path = Console.ReadLine();

        var source = new SourceCheck(@path);
        var lines = new List<string>();
        var linesModel = new List<LineModel>();
        var linesModelAll = new List<LineModel>();
        var checkFileStruct = source.CheckFilesStructure;
        var fileContent = source.FileContent;

        if (checkFileStruct)
        {
            Console.Write("Group: ");
            var group = "";
            group = Console.ReadLine();

            // for (var i = 0; i < fileContent.Count; i++)
            // {
            //     var splitedFileContent = fileContent[i].Split(';');
            //     if (splitedFileContent[4] == group) lines.Add(fileContent[i]);
            // }

            var counter = 0;
            foreach (var line in fileContent)
            {
                if (counter > 0) lines.Add(line);

                counter++;
            }

            for (var i = 0; i < lines.Count; i++)
            {
                var line = lines[i];
                var lineModel = new LineModel(line);

                linesModel.Add(lineModel);
            }

            // GetQuantity(linesModel, group);
            // GetValue(linesModel, group);
            // GetDate(linesModel, group);
            GetValueOfFile(linesModel);
        }
        else
        {
            Console.WriteLine("Unknown file structure.");
        }
    }

    private void GetQuantity(List<LineModel> lines, string group)
    {
        var result = 0.0;

        foreach (var line in lines) result += line.Quantity;

        Console.WriteLine("Group: " + group + ", quantity: " + result);
    }

    private void GetValue(List<LineModel> lines, string group)
    {
        var result = 0.0;

        foreach (var line in lines) result += line.Value;

        Console.WriteLine("Group: " + group + ", value: " + result);
    }

    private void GetDate(List<LineModel> lines, string group)
    {
        var maxDate = new DateTime();
        var minDate = new DateTime();

        for (var i = 0; i < lines.Count; i++)
        {
            if (i == 0) maxDate = lines[i].Date;

            if (maxDate < lines[i].Date)
                maxDate = lines[i].Date;
            else
                minDate = lines[i].Date;
        }

        Console.WriteLine("Group: " + group);
        Console.WriteLine("Max date: " + maxDate.ToString("yyyy-MM-dd"));
        Console.WriteLine("Min date: " + minDate.ToString("yyyy-MM-dd"));
    }

    private void GetValueOfFile(List<LineModel> lines)
    {
        var result = 0.0;
        foreach (var line in lines) result += line.Value;

        Console.WriteLine("Value for whole file: " + Math.Round(result, 2));
    }
}