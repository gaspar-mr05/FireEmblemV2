namespace Fire_Emblem.Models.Conditions;

public class OrConditions
{
    private List<ICondition> _orConditions = new();


    public void AddCondition(ICondition condition)
    {
        _orConditions.Add(condition);
    }
    

    public bool AreConditionsMet()
    {
        if (_orConditions.Count == 0)
            return true;
        foreach (ICondition condition in _orConditions)
        {
            if (condition.IsConditionMet())
                return true;
        }
        return false;
    } 
}