namespace Fire_Emblem.Models.Effects.EffectSummary;

public class PermitedAttackStatus
{
    public int AmountNegated;
    public int AmountGuaranteed;
    public bool Guaranteed;
    public bool Negated;
    public bool NegationNegated;
    public bool GuaranteeNegated;

    public PermitedAttackStatus()
    {
        AmountNegated = 0;
        AmountGuaranteed = 0;
        Guaranteed = false;
        Negated = false;
        NegationNegated = false;
        GuaranteeNegated = false;




    }
}