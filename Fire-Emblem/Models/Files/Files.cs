namespace Fire_Emblem.Models.Files;

public class Files
{
    private Dictionary<int, string> _files = new();

    public void AddFile(int fileNumber, string fileName) => _files[fileNumber] = fileName;

    public string GetFile(int fileNumber) => _files[fileNumber];
}