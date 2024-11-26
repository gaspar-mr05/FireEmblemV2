using Fire_Emblem.Characters;
using Fire_Emblem.Effects.EffectsInfoBoundaries;

namespace Fire_Emblem.Effects;

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