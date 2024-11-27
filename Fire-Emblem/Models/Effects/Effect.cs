

using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Effects;



public abstract class Effect
{
    protected Unit Unit;
    public string StatName;

    public Effect(Unit unit)
    {
        Unit = unit;
    }

    public abstract void ApplyEffect();
    public abstract void RevertEffect();
    public abstract int GetPriority();

}