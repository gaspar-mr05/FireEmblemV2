namespace Fire_Emblem.Models.Effects.EffectSummary;

public class DamageEffectStatus
{
    public int Damage;
    public bool Active;

    public DamageEffectStatus()
    {
        Damage = 0;
        Active = false;
    }
}