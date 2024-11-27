namespace Fire_Emblem.Models.Attacks;

public class AttacksEffects
{
    public int AtkEffect;
    public int DefEffect;
    public int ResEffect;

    public AttacksEffects(int atkEffect, int defEffect, int resEffect)
    {
        AtkEffect = atkEffect;
        DefEffect = defEffect;
        ResEffect = resEffect;
    }
}