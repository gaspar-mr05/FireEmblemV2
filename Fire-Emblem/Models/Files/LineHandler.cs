namespace Fire_Emblem.Models.Files;

public class LineHandler
{
    private string _line;
    public LineHandler(string line)
    {
        _line = line;
    }
    
    public (string, string[]) HandleLine()
    {
        int startPharentesesIndex = _line.IndexOf("(");
        if (startPharentesesIndex == -1) return (_line.Trim(), Array.Empty<string>());
    
        int endPharentesisIndex = _line.IndexOf(")");
        string name = _line[..startPharentesesIndex].Trim();
        string[] skills = _line[(startPharentesesIndex + 1)..endPharentesisIndex].Trim().Split(",");
        return (name, skills);
    }
    
}