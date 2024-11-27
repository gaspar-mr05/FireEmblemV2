namespace Fire_Emblem.Models.Units;

public class InitialUnitStats
{
    private Dictionary<Unit, Stats> _initialUnitStats = new();

    public InitialUnitStats(Unit attacker, Unit defender)
    {
        _initialUnitStats[attacker] = attacker.Stats.Clone();
        _initialUnitStats[defender] = defender.Stats.Clone();
    }

    public Stats GetInitialStats(Unit unit) => _initialUnitStats[unit];
}