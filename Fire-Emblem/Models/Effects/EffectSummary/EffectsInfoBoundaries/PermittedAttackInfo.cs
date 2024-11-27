using Fire_Emblem.Models.Enums;

namespace Fire_Emblem.Models.Effects.EffectSummary.EffectsInfoBoundaries;

public class PermittedAttackInfo
{
    private Dictionary<AttackType, PermitedAttackStatus> _permitedAttackInfo;

    public PermittedAttackInfo()
    {
        _permitedAttackInfo = new Dictionary<AttackType, PermitedAttackStatus>
        {
            { AttackType.CounterAttack, new PermitedAttackStatus() },
            { AttackType.FollowUpAttack, new PermitedAttackStatus() },
        };
    }

    public bool IsNegated(AttackType attackType) => _permitedAttackInfo[attackType].Negated;

    public bool IsNegationNegated(AttackType attackType) => _permitedAttackInfo[attackType].NegationNegated;
    
    public bool IsGuaranteeNegated(AttackType attackType) => _permitedAttackInfo[attackType].GuaranteeNegated;

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

    public void NegateNegation(AttackType attackType)
    {
        _permitedAttackInfo[attackType].Negated = false;
        _permitedAttackInfo[attackType].NegationNegated = true;

    }
    
    public void NegateGuarantee(AttackType attackType)
    {
        _permitedAttackInfo[attackType].Guaranteed = false;
        _permitedAttackInfo[attackType].GuaranteeNegated = true;

    }

    public int GetAmountNegated(AttackType attackType) => _permitedAttackInfo[attackType].AmountNegated;
    
    public int GetAmountGuaranteed(AttackType attackType) => _permitedAttackInfo[attackType].AmountGuaranteed;
}