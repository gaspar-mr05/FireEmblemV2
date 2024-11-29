using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Teams;




public class Team
{
    
    private List<Unit> _unitList = new();

    public void AddUnit(Unit unit)
        => _unitList.Add(unit);

    public Unit[] GetTeam() => _unitList.ToArray();


    public void RemoveUnit(Unit unit)
        => _unitList.Remove(unit);

    public Unit GetUnit(int idUnit)
        => _unitList[idUnit];
    


    public Team GetDeadUnitsOfTeam()
    {
        Team unitsToRemove = new Team();
        foreach (Unit unit in _unitList)
        {
            if (unit.Stats.GetHp() == 0)
                unitsToRemove.AddUnit(unit);
        }
        return unitsToRemove;
    }

    public bool HasUnits()
    {
        return GetTeamSize() > 0;
    }
    
    public int GetTeamSize()
        => _unitList.Count;
    
    

    
    public bool NotDuplicatedUnitsInTeam()
    {
        List<string> uniquesCharacters = new List<string>();
        foreach (Unit unit in _unitList)
        {
            if (uniquesCharacters.Contains(unit.CharacterInfo.Name))
                return false;
            uniquesCharacters.Add(unit.CharacterInfo.Name);
        }
        return true;
    }
    

    
    
    public bool NotDuplicatedSkillsInTeam()
    {
        foreach (Unit unit in _unitList)
        {
            if (!unit.HasUniqueSkills())
                return false;
        }
        return true;
    }

    public bool LessThanThreeSkillsInTeam()
    {
        foreach (Unit unit in _unitList)
        {
            if (unit.SkillsNames.Length > 2)
                return false;
        }
        return true;
    }



}