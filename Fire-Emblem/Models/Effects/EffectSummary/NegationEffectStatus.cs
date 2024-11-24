namespace Fire_Emblem.Effects;

public class NegationEffectStatus
{
    public int AmountNegated;
    public int AmountGuaranteed;
    public bool Guaranteed;
    public bool Negated;

    public NegationEffectStatus()
    {
        AmountNegated = 0;
        AmountGuaranteed = 0;
        Guaranteed = false;
        Negated = false;
    }
}