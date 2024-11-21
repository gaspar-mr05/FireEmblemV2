using Fire_Emblem_View;
using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;



public abstract class Effect
{
    protected Unit Unit;
    public string StatName;

    public abstract void ApplyEffect();
    public abstract void RevertEffect();
    public abstract int GetPriority();

}