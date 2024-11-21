using Fire_Emblem.Teams;
using Fire_Emblem.ViewPrinter;

namespace Fire_Emblem.Files;
using Fire_Emblem_View;
public class FileSelector
{
    private Dictionary<int, string> _filesDict;
    private string[] _teamFiles;
    private FileOptionsView _fileOptionsView;

    public FileSelector(View view, string teamsFolder)
    {
        _teamFiles = Directory.GetFiles(teamsFolder);
        _fileOptionsView =  new FileOptionsView(view, _teamFiles);
        _filesDict = new Dictionary<int, string>();
        Array.Sort(_teamFiles);
    }
    
    public string ChooseFile()
    { 
        _fileOptionsView.ShowFileOptions(_filesDict);
        int fileChosenNumber = _fileOptionsView.GetFileChosen();
        return _filesDict[fileChosenNumber];

    }
}