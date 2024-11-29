namespace Fire_Emblem.Models.Attacks;

public class AttacksEffectsInfo
{
    public int AtkEffect;
    public int DefEffect;
    public int ResEffect;

    public AttacksEffectsInfo(int atkEffect, int defEffect, int resEffect)
    {
        AtkEffect = atkEffect;
        DefEffect = defEffect;
        ResEffect = resEffect;
    }
}