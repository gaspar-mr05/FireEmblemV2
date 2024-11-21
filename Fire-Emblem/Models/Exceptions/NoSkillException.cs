namespace Fire_Emblem.Exceptions;

public class NoSkillException: Exception
{
    public NoSkillException()
        : base("No existe esa habilidad.")
    {}
    
}