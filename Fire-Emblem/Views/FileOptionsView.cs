using Fire_Emblem_View;
using Fire_Emblem.Models.Files;

namespace Fire_Emblem.Views;



public class FileOptionsView
{
    private View _view;
    private string[] _teamFiles;


public FileOptionsView(View view, string[] teamFiles)
    {

        _view = view;
        _teamFiles = teamFiles;

    }
    public void ShowFileOptions(Files files)
    {
        _view.WriteLine("Elige un archivo para cargar los equipos");
        int fileNumber = 0;
        foreach (string file in _teamFiles)
        {
            string fileName = Path.GetFileName(file);
            _view.WriteLine($"{fileNumber}: {fileName}");
            files.AddFile(fileNumber, fileName);
            fileNumber += 1;
        }
    }

    public int GetFileChosen()
    {
        try
        {
            int fileChosenNumber = int.Parse(_view.ReadLine());
            return fileChosenNumber;
        }
        catch (InvalidInputRequestException)
        {
            ShowInvalidInput();
            return -1;
        }
        
    }


    private void ShowInvalidInput()
    {
        _view.WriteLine("Input inválido");
    }
}