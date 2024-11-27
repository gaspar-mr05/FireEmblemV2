using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Effects.NormalEffects;

public abstract class NormalEffect: Effect
{

    protected int Change;

    public NormalEffect(Unit unit, string statName, int change) : base(unit)
    {

        StatName = statName;
        Change = change;

    }




    public override int GetPriority() => 1;


}