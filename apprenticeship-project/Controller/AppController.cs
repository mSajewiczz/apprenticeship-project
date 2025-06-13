using System.Text.RegularExpressions;
using apprenticeship_project.Model;
using apprenticeship_project.View;

namespace apprenticeship_project.Controller;

public class AppController
{
    public AppController()
    {
        DataModel dataModel = new DataModel();
        var pattern = dataModel.Pattern;
        var checkFileStructure = false;
        var getFileName = dataModel.GetFileName;
        var check = false;
        var response = "";

        if (pattern.IsMatch(getFileName))
        {
            checkFileStructure = dataModel.CheckFileStruct;
            check = true;
        }
        else
        {
            response = "Wrong file name.";
        }

        if (checkFileStructure && check)
        {
            response = "OK";
        }
        else
        {
            response = "Wrong file structure.";
        }
        
        var userInterface = new UserInterface(response);
    }
}