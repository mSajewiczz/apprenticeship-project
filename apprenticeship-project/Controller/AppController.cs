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

        var message = "";

        if (pattern.IsMatch(getFileName))
        {
            checkFileStructure = dataModel.CheckFileStruct;
        }
        else
        {
            message = "Wrong file name.";
        }

        if (checkFileStructure)
        {
            
        }
        else
        {
            message = "Wrong file structure.";
        }
        
        UserInterface userInterface = new UserInterface(message);
    }
}