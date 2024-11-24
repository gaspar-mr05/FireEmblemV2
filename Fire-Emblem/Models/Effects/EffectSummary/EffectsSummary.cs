using Fire_Emblem.Conditions;
using Fire_Emblem.Effects.EffectsInfoBoundaries;

namespace Fire_Emblem.Effects;

public class EffectsSummary
{
    public NormalEffectInfo BonusesInfo = new();
    public NormalEffectInfo PenaltiesInfo = new();
    public NormalEffectInfo FirstAttackBonusesInfo = new();
    public NormalEffectInfo FirstAttackPenaltiesInfo = new();
    public NormalEffectInfo FollowUpBonusesInfo = new();
    public NormalEffectInfo FollowUpPenaltiesInfo = new();
    public NeutralizationEffectInfo BonusNeutralizationsInfo = new();
    public NeutralizationEffectInfo PenaltyNeutralizationsInfo = new();
    public DamageEffectInfo ExtraDamageInfo = new();
    public DamageEffectInfo AbsoluteDamageReductionInfo = new();
    public PercentageDamageEffectInfo PercentageDamageReductionInfo = new();
    public PercentageEffectStatus ActiveHealingInfo = new();
    public DamageEffectInfo OutOfCombatDamageInfo = new();
    public PermittedAttackInfo PermitedAttackInfo = new();
    


}

