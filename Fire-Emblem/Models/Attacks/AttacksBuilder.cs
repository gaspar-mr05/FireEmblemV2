namespace Fire_Emblem.Combat;

public class AttacksBuilder
{
    private RoundInfo _roundInfo;

    public AttacksBuilder(RoundInfo roundInfo)
    {
        _roundInfo = roundInfo;
    }

    public (AttackExecutor, AttackExecutor, AttackExecutor) BuildAttacks()
    {
        AttackExecutor firstAttackExecutor = new FirstAttackExecutor(_roundInfo);
        AttackExecutor counterAttackExecutor = new CounterAttackExecutor(_roundInfo);
        AttackExecutor followUpAttackExecutor = new FollowUpAttackExecutor(_roundInfo);
        return (firstAttackExecutor, counterAttackExecutor, followUpAttackExecutor);
    }
}