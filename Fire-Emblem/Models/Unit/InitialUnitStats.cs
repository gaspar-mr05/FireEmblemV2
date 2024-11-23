namespace Fire_Emblem.Models.Unit;

public class InitialUnitStats
{
    private Dictionary<Fire_Emblem.Characters.Unit, Stats> _initialUnitStats = new();

    public InitialUnitStats(Fire_Emblem.Characters.Unit attacker, Fire_Emblem.Characters.Unit defender)
    {
        _initialUnitStats[attacker] = attacker.Stats.Clone();
        _initialUnitStats[defender] = defender.Stats.Clone();
    }

    public Stats GetInitialStats(Fire_Emblem.Characters.Unit unit) => _initialUnitStats[unit];
}