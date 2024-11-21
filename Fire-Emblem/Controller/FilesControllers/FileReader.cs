namespace Fire_Emblem.Files;
using Fire_Emblem_View;

public class FileReader
{
    private string _teamsFolder;
    private View _view;

    public FileReader(View view, string teamsFolder)
    {
        _view = view;
        _teamsFolder = teamsFolder;
    }
    
    public string[] ReadFile()
    {
        FileSelector fileSelector = new FileSelector(_view, _teamsFolder);
        string fileChosen = fileSelector.ChooseFile();
        
        string[] fileLines = File.ReadAllLines($"{_teamsFolder}//{fileChosen}");
        return fileLines;
    }
    
}