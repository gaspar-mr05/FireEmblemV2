namespace Fire_Emblem.Models.Exceptions;

public class NoRoundInfoException: Exception
{

    public NoRoundInfoException()
        : base("No hay información de la ronda")

    {}

}