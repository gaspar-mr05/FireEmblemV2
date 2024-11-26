namespace Fire_Emblem.Effects;

public class PercentageEffectStatus
{
    public double Percentage;
    public double ReductionOfReduction;
    public bool Active;

    public PercentageEffectStatus()
    {
        ReductionOfReduction = 1;
        Percentage = 0;
        Active = false;
    }
}