namespace Fire_Emblem.Models.Conditions;

public class ConditionsCollection
{
    private List<OrConditions> _conditions = new();


    public void AddSingleCondition(ICondition condition)
    {
        OrConditions orConditions = new OrConditions();
        orConditions.AddCondition(condition);
        _conditions.Add(orConditions);
    }

    public void AddOrConditions(OrConditions orConditions)
    {
        _conditions.Add(orConditions);
    }

    public  bool AreConditionsMet()
    {
        foreach (OrConditions orConditions in _conditions)
        {
            if (!orConditions.AreConditionsMet())
                return false;
        }
        return true;
    }

}