using Fire_Emblem.Models.Enums;

namespace Fire_Emblem.Models.Exceptions;

public class AttackException: Exception
{
    public AttackError AttackError;

    public AttackException(string message, AttackError attackError) : base(message)
    {
        AttackError = attackError;
    }
    
}