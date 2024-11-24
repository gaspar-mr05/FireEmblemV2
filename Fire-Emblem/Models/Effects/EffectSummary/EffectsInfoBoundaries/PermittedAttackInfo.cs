using Fire_Emblem.Conditions;

namespace Fire_Emblem.Effects.EffectsInfoBoundaries;

public class PermittedAttackInfo
{
    private Dictionary<AttackType, NegationEffectStatus> _permitedAttackInfo;

    public PermittedAttackInfo()
    {
        _permitedAttackInfo = new Dictionary<AttackType, NegationEffectStatus>
        {
            { AttackType.CounterAttack, new NegationEffectStatus() },
            { AttackType.FollowUpAttack, new NegationEffectStatus() },
        };
    }

    public bool IsNegated(AttackType attackType) => _permitedAttackInfo[attackType].Negated;

    public bool IsGuaranteed(AttackType attackType) => _permitedAttackInfo[attackType].Guaranteed;

    public void NegateAttack(AttackType attackType)
    {
        _permitedAttackInfo[attackType].Negated = true;
        _permitedAttackInfo[attackType].AmountNegated += 1;
    }
    
    public void GuaranteeAttack(AttackType attackType)
    {
        _permitedAttackInfo[attackType].Guaranteed = true;
        _permitedAttackInfo[attackType].AmountGuaranteed += 1;
        
    }

    public void NegateNegation(AttackType attackType) => _permitedAttackInfo[attackType].Negated = false;

    public int GetAmountNegated(AttackType attackType) => _permitedAttackInfo[attackType].AmountNegated;
    
    public int GetAmountGuaranteed(AttackType attackType) => _permitedAttackInfo[attackType].AmountGuaranteed;
}