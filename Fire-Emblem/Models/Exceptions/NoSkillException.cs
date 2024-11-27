namespace Fire_Emblem.Models.Exceptions;

public class NoSkillException: Exception
{
    public NoSkillException()
        : base("No existe esa habilidad.")
    {}
    
}