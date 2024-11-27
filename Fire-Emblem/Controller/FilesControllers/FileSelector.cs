using Fire_Emblem_View;
using Fire_Emblem.Models.Files;
using Fire_Emblem.Views;


namespace Fire_Emblem.Controller.FilesControllers;

public class FileSelector
{
    private Files _files;
    private string[] _teamFiles;
    private FileOptionsView _fileOptionsView;

    public FileSelector(View view, string teamsFolder)
    {
        _teamFiles = Directory.GetFiles(teamsFolder);
        _fileOptionsView =  new FileOptionsView(view, _teamFiles);
        _files = new Files();
        Array.Sort(_teamFiles);
    }
    
    public string ChooseFile()
    { 
        _fileOptionsView.ShowFileOptions(_files);
        int fileChosenNumber = _fileOptionsView.GetFileChosen();
        return _files.GetFile(fileChosenNumber);

    }
}