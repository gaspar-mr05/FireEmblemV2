namespace Fire_Emblem.Combat;

public class SelectionMessageGenerator
{
    private int _playerWhoStarts;

    public SelectionMessageGenerator(int playerWhoStarts)
    {
        _playerWhoStarts = playerWhoStarts;
    }

    public (string,string) GenerateSelectionMessages()
    {
        string attackMessage = _playerWhoStarts == 1 ? "Player 1 selecciona una opción" : "Player 2 selecciona una opción";
        string defendsMessage = _playerWhoStarts == 1 ? "Player 2 selecciona una opción" : "Player 1 selecciona una opción";
        return (attackMessage, defendsMessage);
    }
}