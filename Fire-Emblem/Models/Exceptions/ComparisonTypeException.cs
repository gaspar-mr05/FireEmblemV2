namespace Fire_Emblem.Models.Exceptions;

public class ComparisonTypeException: Exception
{
    public ComparisonTypeException()
        : base("No existe ese tipo de comparación")
    {}
    
}