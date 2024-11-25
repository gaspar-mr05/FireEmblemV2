using System.Diagnostics;
using System.Security.Cryptography;
using System.Text.Unicode;
using Fire_Emblem.Characters;
using Fire_Emblem.Combat;
using Fire_Emblem.Effects;
using Fire_Emblem.Effects.DamageEffects;
using Fire_Emblem.Effects.NegationEffects;
using Fire_Emblem.Exceptions;
using Fire_Emblem.Models;
using Fire_Emblem.Models.Effects.DamageEffects;
using Fire_Emblem.Models.Effects.OutOfCombatDamageEffects;
using Fire_Emblem.Models.Skills;

namespace Fire_Emblem.Conditions;

public class SkillBuilder
{
    private string _skillName;
    private RoundInfo _roundInfo;

    public SkillBuilder(RoundInfo roundInfo, string skillName)
    {
        _roundInfo = roundInfo;
        _skillName = skillName;
    }

    public Skill BuildSkill(Unit unit, Unit rival)
    {
        EffectsConditionsCollection effectsConditions = new EffectsConditionsCollection();
        ConditionsCollection conditions = new ConditionsCollection();
        ConditionsCollection extraConditions = new ConditionsCollection();
        Weapons weapons = new Weapons();
        if (_skillName == "Fair Fight")
            
        {
            conditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 6),conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(rival, "Atk", 6),conditions);
        }
        else if (_skillName == "HP +15")
        {
            
        }
        else if (_skillName == "Will to Win")
        {
            conditions.AddSingleCondition(new HpRespectPercentage(unit, 0.5, ComparisonType.Less, _roundInfo));
            conditions.AddSingleCondition(new CombatStart(_roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 8), conditions);
        }
        else if (_skillName == "Single-Minded")
        {
            conditions.AddSingleCondition(new RecentRival(unit, rival));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 8), conditions);
        }
        else if (_skillName == "Ignis")
        {
            effectsConditions.AddEffectConditions(new FirstAttackBonusEffect(unit, "Atk", 
                (int)Math.Floor(Convert.ToDouble(unit.CharacterInfo.Atk) * 0.5)), conditions);

        }

        else if (_skillName == "Perceptive")
        {
            conditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Spd", 12  +  
                    Convert.ToInt32(unit.CharacterInfo.Spd) / 4),
                conditions);
        }

        else if (_skillName == "Tome Precision")
        {
            weapons.AddWeapons(["Magic"]);
            conditions.AddSingleCondition(new UnitUseWeaponType(unit, weapons));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 6), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Spd", 6), conditions);

        }

        else if (_skillName == "Attack +6")
        {
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 6), conditions);
        }
        else if (_skillName == "Speed +5")
        {
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Spd", 5), conditions);
        }
        else if (_skillName == "Defense +5")
        {
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Def", 5), conditions);
        }
        else if (_skillName == "Wrath")
        {
            conditions.AddSingleCondition(new FullHp(unit, ComparisonType.NotFullHp));
            conditions.AddSingleCondition(new CombatStart(_roundInfo));
            effectsConditions.AddEffectConditions(new WrathEffect(unit, "Atk"), conditions);
            effectsConditions.AddEffectConditions(new WrathEffect(unit, "Spd"), conditions);


        }
        else if (_skillName == "Resolve")
        {
            conditions.AddSingleCondition(new HpRespectPercentage(unit, 0.75, ComparisonType.Less, _roundInfo));
            conditions.AddSingleCondition(new CombatStart(_roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Def", 7), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Res", 7), conditions);

        }
        else if (_skillName == "Resistance +5")
        {
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Res", 5), conditions);
        }
        else if (_skillName == "Atk/Def +5")
        {
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 5), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Def", 5), conditions);

        }
        else if (_skillName == "Atk/Res +5")
        {
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 5), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Res", 5), conditions);
        }

        else if (_skillName == "Spd/Res +5")
        {
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Spd", 5), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Res", 5), conditions);
        }
        else if (_skillName == "Deadly Blade")
        {
            weapons.AddWeapons(["Sword"]);
            conditions.AddSingleCondition(new UnitUseWeaponType(unit, weapons));
            conditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 8), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Spd", 8), conditions);

        }
        else if (_skillName == "Death Blow")
        {
            conditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 8), conditions);
        }
        else if (_skillName == "Armored Blow")
        {
            conditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Def", 8), conditions);

        }
        else if (_skillName == "Darting Blow")
        {
            conditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Spd", 8), conditions);
        }
        else if (_skillName == "Warding Blow")
        {
            conditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Res", 8), conditions);
        }

        else if (_skillName == "Swift Sparrow")
        {
            conditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 6), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Spd", 6), conditions);

        }
        else if (_skillName == "Sturdy Blow")
        {
            conditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 6), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Def", 6), conditions);
        }

        else if (_skillName == "Mirror Strike")
        {
            conditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 6), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Res", 6), conditions);
        }

        else if (_skillName == "Steady Blow")
        {
            conditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Spd", 6), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Def", 6), conditions);
        }
        else if (_skillName == "Bracing Blow")
        {
            conditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Def", 6), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Res", 6), conditions);
        }

        else if (_skillName == "Swift Strike")
        {
            conditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Spd", 6), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Res", 6), conditions);
        }

        else if (_skillName == "Brazen Atk/Spd")
        {
            conditions.AddSingleCondition(new HpRespectPercentage(unit, 0.8, ComparisonType.Less, _roundInfo));
            conditions.AddSingleCondition(new CombatStart(_roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 10), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Spd", 10), conditions);
        }
        else if (_skillName == "Brazen Atk/Def")
        {
            conditions.AddSingleCondition(new HpRespectPercentage(unit, 0.8, ComparisonType.Less, _roundInfo));
            conditions.AddSingleCondition( new CombatStart(_roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 10), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Def", 10), conditions);
        }
        else if (_skillName == "Brazen Atk/Res")
        {
            conditions.AddSingleCondition(new HpRespectPercentage(unit, 0.8, ComparisonType.Less, _roundInfo));
            conditions.AddSingleCondition(new CombatStart(_roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 10), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Res", 10), conditions);
        }
        else if (_skillName == "Brazen Spd/Def")
        {
            conditions.AddSingleCondition(new HpRespectPercentage(unit, 0.8, ComparisonType.Less, _roundInfo));
            conditions.AddSingleCondition(new CombatStart(_roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Spd", 10), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Def", 10), conditions);
        }
        else if (_skillName == "Brazen Spd/Res")
        {
            conditions.AddSingleCondition(new HpRespectPercentage(unit, 0.8, ComparisonType.Less, _roundInfo));
            conditions.AddSingleCondition(new CombatStart(_roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Spd", 10), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Res", 10), conditions);
        }
        else if (_skillName == "Brazen Def/Res")
        {
            conditions.AddSingleCondition(new HpRespectPercentage(unit, 0.8, ComparisonType.Less, _roundInfo));
            conditions.AddSingleCondition(new CombatStart(_roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Def", 10), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Res", 10), conditions);
        }
        else if (_skillName == "Fire Boost")
        {
            conditions.AddSingleCondition(new StatComparison(unit, rival, "HP", "HP", 3, ComparisonType.Greater));
            conditions.AddSingleCondition(new CombatStart(_roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 6), conditions);

        }
        else if (_skillName == "Wind Boost")
        {
            conditions.AddSingleCondition(new StatComparison(unit, rival, "HP", "HP", 3, ComparisonType.Greater));
            conditions.AddSingleCondition(new CombatStart(_roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Spd", 6), conditions);
        }
        else if (_skillName == "Earth Boost")
        {
            conditions.AddSingleCondition(new StatComparison(unit, rival, "HP", "HP", 3, ComparisonType.Greater));
            conditions.AddSingleCondition(new CombatStart(_roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Def", 6), conditions);
        }
        else if (_skillName == "Water Boost")
        {
            conditions.AddSingleCondition(new StatComparison(unit, rival, "HP", "HP", 3, ComparisonType.Greater));
            conditions.AddSingleCondition(new CombatStart(_roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Res", 6), conditions);
        }
        else if (_skillName == "Chaos Style")
        {
            conditions.AddSingleCondition(new PhysicVsMagic(unit, rival));
            conditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Spd", 3), conditions);
        }
        else if (_skillName == "Blinding Flash")
        {
            conditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Spd", 4), conditions);
        }
        else if (_skillName == "Not *Quite*")
        {
            conditions.AddSingleCondition(new UnitStartCombat(rival, _roundInfo));
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Atk", 4), conditions);
        }
        else if (_skillName == "Stunning Smile")
        {
            conditions.AddSingleCondition(new MaleUnit(rival));
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Spd", 8), conditions);
        }
        else if (_skillName == "Disarming Sigh")
        {
            conditions.AddSingleCondition(new MaleUnit(rival));
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Atk", 8), conditions);
        }
        else if (_skillName == "Charmer")
        {
            conditions.AddSingleCondition(new RecentRival(unit, rival));
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Atk", 3), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Spd", 3), conditions);

        }
        else if (_skillName == "Luna")
        {
            effectsConditions.AddEffectConditions(new FirstAttackPenaltyEffect(rival, "Def", 
                Convert.ToInt32(rival.CharacterInfo.Def) / 2), conditions);
            effectsConditions.AddEffectConditions(new FirstAttackPenaltyEffect(rival, "Res", 
                Convert.ToInt32(rival.CharacterInfo.Res) / 2), conditions);

        }
        else if (_skillName == "Belief in Love")
        {
            OrConditions orConditions = new OrConditions();
            orConditions.AddCondition(new FullHp(rival, ComparisonType.FullHp));
            orConditions.AddCondition(new UnitStartCombat(rival, _roundInfo));
            conditions.AddOrConditions(orConditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Atk", 5), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Def", 5), conditions);
            
        }
        else if (_skillName == "Beorc's Blessing")
        {
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Atk"), conditions);
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Spd"), conditions);
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Def"), conditions);
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Res"), conditions);
            
        }
        else if (_skillName == "Agnea's Arrow")
        {
            effectsConditions.AddEffectConditions(new PenaltyNeutralizationEffect(unit, "Atk"), conditions);
            effectsConditions.AddEffectConditions(new PenaltyNeutralizationEffect(unit, "Spd"), conditions);
            effectsConditions.AddEffectConditions(new PenaltyNeutralizationEffect(unit, "Def"), conditions);
            effectsConditions.AddEffectConditions(new PenaltyNeutralizationEffect(unit, "Res"), conditions);

        }
        else if (_skillName == "Soulblade")
        {
            weapons.AddWeapons(["Sword"]);
            conditions.AddSingleCondition(new UnitUseWeaponType(unit, weapons));
            
            conditions.AddSingleCondition(new UnitUseWeaponType(unit, weapons));
            effectsConditions.AddEffectConditions(new SoulbladeEffect(rival, "Def"), conditions);
            effectsConditions.AddEffectConditions(new SoulbladeEffect(rival, "Res"), conditions);

        }
        else if (_skillName == "Sandstorm")
        {
            effectsConditions.AddEffectConditions(new SandstormEffect(unit, "Atk"), conditions);
        }
        else if (_skillName == "Sword Agility")
        {
            weapons.AddWeapons(["Sword"]);
            conditions.AddSingleCondition(new UnitUseWeaponType(unit, weapons));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Spd", 12), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(unit, "Atk", 6), conditions);
        }
        else if (_skillName == "Lance Power")
        {
            weapons.AddWeapons(["Lance"]);
            conditions.AddSingleCondition(new UnitUseWeaponType(unit, weapons));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 10), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(unit, "Def", 10), conditions);
        }
        else if (_skillName == "Sword Power")
        {
            weapons.AddWeapons(["Sword"]);
            conditions.AddSingleCondition(new UnitUseWeaponType(unit, weapons));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 10), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(unit, "Def", 10), conditions);
        }
        else if (_skillName == "Bow Focus")
        {
            weapons.AddWeapons(["Bow"]);
            conditions.AddSingleCondition(new UnitUseWeaponType(unit, weapons));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 10), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(unit, "Res", 10), conditions);
        }
        else if (_skillName == "Lance Agility")
        {
            weapons.AddWeapons(["Lance"]);
            conditions.AddSingleCondition(new UnitUseWeaponType(unit, weapons));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Spd", 12), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(unit, "Atk", 6), conditions);
        }
        else if (_skillName == "Axe Power")
        {
            weapons.AddWeapons(["Axe"]);
            conditions.AddSingleCondition(new UnitUseWeaponType(unit, weapons));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 10), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(unit, "Def", 10), conditions);
        }
        else if (_skillName == "Bow Agility")
        {
            weapons.AddWeapons(["Bow"]);
            conditions.AddSingleCondition(new UnitUseWeaponType(unit, weapons));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Spd", 12), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(unit, "Atk", 6), conditions);
        }
        else if (_skillName == "Sword Focus")
        {
            weapons.AddWeapons(["Sword"]);
            conditions.AddSingleCondition(new UnitUseWeaponType(unit, weapons));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 10), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(unit, "Res", 10), conditions);

        }
        else if (_skillName == "Close Def")
        {
            weapons.AddWeapons(["Sword", "Axe", "Lance"]);
            conditions.AddSingleCondition(new UnitUseWeaponType(rival, weapons));
            conditions.AddSingleCondition(new UnitStartCombat(rival, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Def", 8), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Res", 8), conditions);
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Atk"), conditions);
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Spd"), conditions);
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Def"), conditions);
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Res"), conditions);
        }
        else if (_skillName == "Distant Def")
        {
            weapons.AddWeapons(["Magic", "Bow"]);
            conditions.AddSingleCondition(new UnitUseWeaponType(rival, weapons));
            conditions.AddSingleCondition(new UnitStartCombat(rival, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Def", 8), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Res", 8), conditions);
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Atk"), conditions);
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Spd"), conditions);
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Def"), conditions);
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Res"), conditions);

        }
        else if (_skillName == "Lull Atk/Spd")
        {
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Atk", 3), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Spd", 3), conditions);
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Atk"), conditions);
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Spd"), conditions);


        }
        else if (_skillName == "Lull Atk/Def")
        {
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Atk", 3), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Def", 3), conditions);
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Atk"), conditions);
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Def"), conditions);
        }
        else if (_skillName == "Lull Atk/Res")
        {
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Atk", 3), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Res", 3), conditions);
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Atk"), conditions);
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Res"), conditions);
        }
        else if (_skillName == "Lull Spd/Def")
        {
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Spd", 3), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Def", 3), conditions);
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Spd"), conditions);
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Def"), conditions);
        }
        else if (_skillName == "Lull Spd/Res")
        {
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Spd", 3), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Res", 3), conditions);
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Spd"), conditions);
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Res"), conditions);
        }
        else if (_skillName == "Lull Def/Res")
        {
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Def", 3), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Res", 3), conditions);
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Def"), conditions);
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Res"), conditions);
        }
        else if (_skillName == "Fort. Def/Res")
        {
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Def", 6), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Res", 6), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(unit, "Atk", 2), conditions);

        }
        else if (_skillName == "Life and Death")
        {
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 6), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Spd", 6), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(unit, "Def", 5), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(unit, "Res", 5), conditions);
            
            
        }
        else if (_skillName == "Solid Ground")
        {
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 6), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Def", 6), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(unit, "Res", 5), conditions);

        }

        else if (_skillName == "Still Water")
        {
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 6), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Res", 6), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(unit, "Def", 5), conditions);

        }
        else if (_skillName == "Dragonskin")
        {
            OrConditions orConditions = new OrConditions();
            orConditions.AddCondition(new HpRespectPercentage(rival, 0.75, ComparisonType.Greater, _roundInfo));
            orConditions.AddCondition( new UnitStartCombat(rival, _roundInfo));
            conditions.AddOrConditions(orConditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 6), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Spd", 6), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Def", 6), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Res", 6), conditions);
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Atk"), conditions);
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Spd"), conditions);
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Def"), conditions);
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Res"), conditions);

            

        }
        else if (_skillName == "Light and Dark")
        {
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Atk", 5), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Def", 5), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Res", 5), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Spd", 5), conditions);

            effectsConditions.AddEffectConditions(new PenaltyNeutralizationEffect(unit, "Atk"), conditions);
            effectsConditions.AddEffectConditions(new PenaltyNeutralizationEffect(unit, "Spd"), conditions);
            effectsConditions.AddEffectConditions(new PenaltyNeutralizationEffect(unit, "Def"), conditions);
            effectsConditions.AddEffectConditions(new PenaltyNeutralizationEffect(unit, "Res"), conditions);
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Atk"), conditions);
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Spd"), conditions);
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Def"), conditions);
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Res"), conditions);
            
        }
        else if (_skillName == "Dragon Wall")
        {
            conditions.AddSingleCondition(new StatComparison(unit, rival, "Res", "Res", 0, 
            ComparisonType.StrictlyGreater));
            effectsConditions.AddEffectConditions(new StatDifferenceDamageReduction(unit, rival, "Res", 
                    EffectDuration.FullRound, 4), 
                conditions);
        }
        else if (_skillName == "Dodge")
        {
            conditions.AddSingleCondition(new StatComparison(unit, rival, "Spd", "Spd", 0, 
            ComparisonType.StrictlyGreater));
            effectsConditions.AddEffectConditions(new StatDifferenceDamageReduction(unit, rival, "Spd", 
                    EffectDuration.FullRound, 4), 
                conditions);
        
        }
        else if (_skillName == "Golden Lotus")
        {
            weapons.AddWeapons(["Sword", "Lance", "Axe", "Bow"]);
            extraConditions.AddSingleCondition(new UnitUseWeaponType(rival, weapons));
            effectsConditions.AddEffectConditions(new PercentageDamageReduction(unit, 0.5, EffectDuration.FirstAttack), 
                extraConditions);
        }
        else if (_skillName == "Gentility")
        {
            effectsConditions.AddEffectConditions(new AbsoluteDamageReduction(unit, 5, EffectDuration.FullRound), extraConditions);
        }
        
        else if (_skillName == "Bow Guard")
        {
            weapons.AddWeapons(["Bow"]);
            extraConditions.AddSingleCondition(new UnitUseWeaponType(rival, weapons));
            effectsConditions.AddEffectConditions(new AbsoluteDamageReduction(unit, 5,EffectDuration.FullRound), 
                extraConditions);
        }
        
        else if (_skillName == "Arms Shield")
        {
            extraConditions.AddSingleCondition(new UnitHasAdvantage(unit, rival));
            effectsConditions.AddEffectConditions(new AbsoluteDamageReduction(unit, 7, EffectDuration.FullRound), 
                extraConditions);
        }
        
        else if (_skillName == "Axe Guard")
        {
            weapons.AddWeapons(["Axe"]);
            extraConditions.AddSingleCondition(new UnitUseWeaponType(rival, weapons));
            effectsConditions.AddEffectConditions(new AbsoluteDamageReduction(unit, 5, EffectDuration.FullRound),
                extraConditions);
        }
        
        else if (_skillName == "Magic Guard")
        {
            weapons.AddWeapons(["Magic"]);
            extraConditions.AddSingleCondition(new UnitUseWeaponType(rival, weapons));
            effectsConditions.AddEffectConditions(new AbsoluteDamageReduction(unit, 5, EffectDuration.FullRound),
                extraConditions);
        }
        
        else if (_skillName == "Lance Guard")
        {
            
            weapons.AddWeapons(["Lance"]);
            
            extraConditions.AddSingleCondition(new UnitUseWeaponType(rival, weapons));
            effectsConditions.AddEffectConditions(new AbsoluteDamageReduction(unit, 5, EffectDuration.FullRound),
                extraConditions);
        }
        
        else if (_skillName == "Sympathetic")
        {
            extraConditions.AddSingleCondition(new UnitStartCombat(rival, _roundInfo));
            extraConditions.AddSingleCondition(new HpRespectPercentage(unit, 0.5, ComparisonType.Less, _roundInfo));
            effectsConditions.AddEffectConditions(new AbsoluteDamageReduction(unit, 5, EffectDuration.FullRound),
                extraConditions);
        }
        
        else if (_skillName == "Back at You")
        {
            extraConditions.AddSingleCondition(new UnitStartCombat(rival, _roundInfo));
            effectsConditions.AddEffectConditions(new ExtraDamageEffect(unit, Convert.ToInt32(Math.Floor(0.5 * (
                Convert.ToInt32(unit.CharacterInfo.HP)-unit.Stats.GetHp()))), EffectDuration.FullRound), 
                extraConditions);

        }
        else if (_skillName == "Lunar Brace")
        {
            weapons.AddWeapons(["Sword", "Axe", "Lance", "Bow"]);
            extraConditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            extraConditions.AddSingleCondition(new UnitUseWeaponType(unit, weapons));
            effectsConditions.AddEffectConditions(new ExtraDamageBasedOnStat(unit, rival, "Def", 0.3, EffectDuration.FullRound, 
                    BasedOn.Rival), 
                extraConditions);
        }
        else if (_skillName == "Bravery")
        {
            effectsConditions.AddEffectConditions(new ExtraDamageEffect(unit, 5, EffectDuration.FullRound), extraConditions);
            
        }
        else if (_skillName == "Bushido")
        {
            extraConditions.AddSingleCondition(new StatComparison(unit, rival, "Spd", "Spd", 0, 
            ComparisonType.StrictlyGreater));
            effectsConditions.AddEffectConditions(new ExtraDamageEffect(unit, 7, EffectDuration.FullRound), conditions);
            effectsConditions.AddEffectConditions(new StatDifferenceDamageReduction(unit, rival, "Spd", 
                    EffectDuration.FullRound, 4), extraConditions);
        }
        
        else if (_skillName == "Moon-Twin Wing")
        {
            conditions.AddSingleCondition(new HpRespectPercentage(unit, 0.25, ComparisonType.Greater, _roundInfo));


            extraConditions.AddSingleCondition(new StatComparison(unit, rival, "Spd", 
                "Spd", 0, ComparisonType.StrictlyGreater));
            extraConditions.AddSingleCondition(new HpRespectPercentage(unit, 0.25, ComparisonType.Greater, _roundInfo));
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Atk", 5), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Spd", 5), conditions);
            effectsConditions.AddEffectConditions(new StatDifferenceDamageReduction(unit, rival, "Spd", 
                    EffectDuration.FullRound, 4), extraConditions);

        }
        else if (_skillName == "Blue Skies")
        {
            effectsConditions.AddEffectConditions(new AbsoluteDamageReduction(unit, 5, EffectDuration.FullRound), extraConditions);
            effectsConditions.AddEffectConditions(new ExtraDamageEffect(unit, 5, EffectDuration.FullRound), extraConditions);
            
        }
        else if (_skillName == "Aegis Shield")
        {

            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Def", 6), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Res", 3), conditions);
            effectsConditions.AddEffectConditions(new PercentageDamageReduction(unit, 0.5, EffectDuration.FirstAttack), 
                extraConditions);
            
        }
        else if (_skillName == "Remote Sparrow")
        {
            conditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            extraConditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));

            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 7), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Spd", 7), conditions);
            effectsConditions.AddEffectConditions(new PercentageDamageReduction(unit, 0.3, EffectDuration.FirstAttack), 
                extraConditions);
        }
        else if (_skillName == "Remote Mirror")
        {
            conditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            extraConditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 7), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Res", 10), conditions);
            effectsConditions.AddEffectConditions(new PercentageDamageReduction(unit, 0.3, EffectDuration.FirstAttack), 
                extraConditions);
        }
        else if (_skillName == "Remote Sturdy")
        {
            conditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            extraConditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 7), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Def", 10), conditions);
            effectsConditions.AddEffectConditions(new PercentageDamageReduction(unit, 0.3, EffectDuration.FirstAttack), 
                extraConditions);
            
        }
        else if (_skillName == "Fierce Stance")
        {
            conditions.AddSingleCondition(new UnitStartCombat(rival, _roundInfo));
            extraConditions.AddSingleCondition(new UnitStartCombat(rival, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 8), conditions);
            effectsConditions.AddEffectConditions(new PercentageDamageReduction(unit, 0.1, EffectDuration.FollowUp), 
                extraConditions);
        }
        else if (_skillName == "Darting Stance")
        {
            conditions.AddSingleCondition(new UnitStartCombat(rival, _roundInfo));
            extraConditions.AddSingleCondition(new UnitStartCombat(rival, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Spd", 8), conditions);
            effectsConditions.AddEffectConditions(new PercentageDamageReduction(unit, 0.1, EffectDuration.FollowUp), 
                extraConditions);
        }
        else if (_skillName == "Steady Stance")
        {
            conditions.AddSingleCondition(new UnitStartCombat(rival, _roundInfo));
            extraConditions.AddSingleCondition(new UnitStartCombat(rival, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Def", 8), conditions);
            effectsConditions.AddEffectConditions(new PercentageDamageReduction(unit, 0.1, EffectDuration.FollowUp), 
                extraConditions);
        }
        else if (_skillName == "Warding Stance")
        {
            conditions.AddSingleCondition(new UnitStartCombat(rival, _roundInfo));
            extraConditions.AddSingleCondition(new UnitStartCombat(rival, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Res", 8), conditions);
            effectsConditions.AddEffectConditions(new PercentageDamageReduction(unit, 0.1, EffectDuration.FollowUp), 
                extraConditions);
        }
        else if (_skillName == "Kestrel Stance")
        {
            conditions.AddSingleCondition(new UnitStartCombat(rival, _roundInfo));
            extraConditions.AddSingleCondition(new UnitStartCombat(rival, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 6), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Spd", 6), conditions);
            effectsConditions.AddEffectConditions(new PercentageDamageReduction(unit, 0.1, EffectDuration.FollowUp), 
                extraConditions);
            
        }
        else if (_skillName == "Sturdy Stance")
        {
            conditions.AddSingleCondition(new UnitStartCombat(rival, _roundInfo));
            extraConditions.AddSingleCondition(new UnitStartCombat(rival, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 6), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Def", 6), conditions);
            effectsConditions.AddEffectConditions(new PercentageDamageReduction(unit, 0.1, EffectDuration.FollowUp), 
                extraConditions);
        }
        else if (_skillName == "Mirror Stance")
        {
            conditions.AddSingleCondition(new UnitStartCombat(rival, _roundInfo));
            extraConditions.AddSingleCondition(new UnitStartCombat(rival, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 6), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Res", 6), conditions);
            effectsConditions.AddEffectConditions(new PercentageDamageReduction(unit, 0.1, EffectDuration.FollowUp), 
                extraConditions);
        }
        else if (_skillName == "Steady Posture")
        {
            conditions.AddSingleCondition(new UnitStartCombat(rival, _roundInfo));
            extraConditions.AddSingleCondition(new UnitStartCombat(rival, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Spd", 6), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Def", 6), conditions);
            effectsConditions.AddEffectConditions(new PercentageDamageReduction(unit, 0.1, EffectDuration.FollowUp), 
                extraConditions);
        }
        else if (_skillName == "Swift Stance")
        {
            conditions.AddSingleCondition(new UnitStartCombat(rival, _roundInfo));
            extraConditions.AddSingleCondition(new UnitStartCombat(rival, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Spd", 6), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Res", 6), conditions);
            effectsConditions.AddEffectConditions(new PercentageDamageReduction(unit, 0.1, EffectDuration.FollowUp), 
                extraConditions);
        }
        else if (_skillName == "Bracing Stance")
        {
            conditions.AddSingleCondition(new UnitStartCombat(rival, _roundInfo));
            extraConditions.AddSingleCondition(new UnitStartCombat(rival, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Def", 6), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Res", 6), conditions);
            effectsConditions.AddEffectConditions(new PercentageDamageReduction(unit, 0.1, EffectDuration.FollowUp), 
                extraConditions);
        }
        else if (_skillName == "Poetic Justice")
        {
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Spd", 4), conditions);
            effectsConditions.AddEffectConditions(new ExtraDamageBasedOnStat(unit, rival, "Atk", 0.15, EffectDuration.FullRound, 
                    BasedOn.Rival), 
                extraConditions);
        }
        else if (_skillName == "Laguz Friend")
        {
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(unit, "Def"), conditions);
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(unit, "Res"), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(unit, "Def", Convert.ToInt32
                (Math.Floor(Convert.ToInt32(unit.CharacterInfo.Def) * 0.5))), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(unit, "Res", Convert.ToInt32
                (Math.Floor(Convert.ToInt32(unit.CharacterInfo.Res) * 0.5))), conditions);
            effectsConditions.AddEffectConditions(new PercentageDamageReduction(unit, 0.5, EffectDuration.FullRound), 
                extraConditions);
        }
        else if (_skillName == "Chivalry")
        {
            extraConditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            extraConditions.AddSingleCondition(new FullHp(rival, ComparisonType.FullHp));
            effectsConditions.AddEffectConditions(new ExtraDamageEffect(unit, 2, EffectDuration.FullRound), extraConditions);
            effectsConditions.AddEffectConditions(new AbsoluteDamageReduction(unit, 2, EffectDuration.FullRound), extraConditions);
            
        }
        else if (_skillName == "Dragon's Wrath")
        {
            
            extraConditions.AddSingleCondition(new StatComparison(unit, rival, 
                "Atk", "Res", 0, ComparisonType.StrictlyGreater));
            effectsConditions.AddEffectConditions(new PercentageDamageReduction(unit, 0.25, EffectDuration.FirstAttack), 
                conditions);
            effectsConditions.AddEffectConditions(new DragonWrathEffect(unit, rival, "Atk", "Res", EffectDuration.FirstAttack), 
                extraConditions);
        }
        else if (_skillName == "Prescience")
        {
            weapons.AddWeapons(["Magic", "Bow"]);
            OrConditions orConditions = new OrConditions();
            orConditions.AddCondition(new UnitStartCombat(unit, _roundInfo));
            orConditions.AddCondition(new UnitUseWeaponType(rival, weapons));
            extraConditions.AddOrConditions(orConditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Atk", 5), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Res", 5), conditions);
            effectsConditions.AddEffectConditions(new PercentageDamageReduction(unit, 0.3, EffectDuration.FirstAttack), 
                extraConditions);
            
        }
        else if (_skillName == "Extra Chivalry")
        {
            conditions.AddSingleCondition(new HpRespectPercentage(rival, 0.5, ComparisonType.Greater, _roundInfo));
            double percentageValue = 0.5 * ((double)rival.Stats.GetHp() / Convert.ToInt32(rival.CharacterInfo.HP));
            double truncatedPercentageValue = Math.Truncate(percentageValue * 100) / 100;
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Atk", 5), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Spd", 5), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Def", 5), conditions);
            effectsConditions.AddEffectConditions(new PercentageDamageReduction(unit, 
                truncatedPercentageValue, EffectDuration.FullRound), extraConditions);

        }
        else if (_skillName == "Guard Bearing")
        {
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Spd", 4), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Def", 4), conditions);
            effectsConditions.AddEffectConditions(new GuardBearingEffect(unit, EffectDuration.FullRound, _roundInfo), 
                extraConditions);
            
        }
        else if (_skillName == "Divine Recreation"){
            conditions.AddSingleCondition(new HpRespectPercentage(rival, 0.5, ComparisonType.Greater, _roundInfo));
            extraConditions.AddSingleCondition(new HpRespectPercentage(rival, 0.5, ComparisonType.Greater, _roundInfo));
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Atk", 4), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Spd", 4), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Def", 4), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Res", 4), conditions);
            effectsConditions.AddEffectConditions(new PercentageDamageReduction(unit, 0.3, EffectDuration.FirstAttack), 
                extraConditions);
            effectsConditions.AddEffectConditions(new DivineRecreationEffect(unit, rival, _roundInfo), 
                extraConditions);
        }
        else if (_skillName == "Sol")
        {
            effectsConditions.AddEffectConditions(new HealingEffect(unit, 0.25), conditions);
        }
        else if (_skillName == "Nosferatu")
        {
            weapons.AddWeapons(["Magic"]);
            conditions.AddSingleCondition(new UnitUseWeaponType(unit, weapons));
            effectsConditions.AddEffectConditions(new HealingEffect(unit, 0.5), conditions);
        }
        else if (_skillName == "Solar Brace")
        {
            conditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            effectsConditions.AddEffectConditions(new HealingEffect(unit, 0.5),conditions);
        }
        else if (_skillName == "Windsweep")
        {
            weapons.AddWeapons(["Sword"]);
            conditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            conditions.AddSingleCondition(new UnitUseWeaponType(unit, weapons));
            conditions.AddSingleCondition(new UnitUseWeaponType(rival, weapons));
            effectsConditions.AddEffectConditions(new NegationEffect(rival, AttackType.CounterAttack), conditions);
        }
        else if (_skillName == "Surprise Attack")
        {
            weapons.AddWeapons(["Bow"]);
            conditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            conditions.AddSingleCondition(new UnitUseWeaponType(unit, weapons));
            conditions.AddSingleCondition(new UnitUseWeaponType(rival, weapons));
            effectsConditions.AddEffectConditions(new NegationEffect(rival, AttackType.CounterAttack), conditions);
        }
        else if (_skillName == "Hliðskjálf")
        {
            weapons.AddWeapons(["Magic"]);
            conditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            conditions.AddSingleCondition(new UnitUseWeaponType(unit, weapons));
            conditions.AddSingleCondition(new UnitUseWeaponType(rival, weapons));
            effectsConditions.AddEffectConditions(new NegationEffect(rival, AttackType.CounterAttack), conditions);
        }
        
        else if (_skillName == "Null C-Disrupt")
        {
            effectsConditions.AddEffectConditions(new NegationOfNegationEffect(unit, AttackType.CounterAttack), conditions);
        }
        
        else if (_skillName == "Laws of Sacae")
        {
            weapons.AddWeapons(["Sword", "Axe", "Lance"]);
            conditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            extraConditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            extraConditions.AddSingleCondition(new UnitUseWeaponType(rival, weapons));
            extraConditions.AddSingleCondition(new StatComparison(unit, rival, "Spd", "Spd", 5, ComparisonType.Greater));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 6), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Spd", 6), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Def", 6), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Res", 6), conditions);
            effectsConditions.AddEffectConditions(new NegationEffect(rival, AttackType.CounterAttack), extraConditions);
        }
        else if (_skillName == "Eclipse Brace")
        {
            weapons.AddWeapons(["Sword", "Axe", "Lance", "Bow"]);
            conditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            conditions.AddSingleCondition(new UnitUseWeaponType(unit, weapons));
            extraConditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            effectsConditions.AddEffectConditions(new ExtraDamageBasedOnStat(unit, rival, "Def", 0.3, EffectDuration.FullRound, 
                    BasedOn.Rival),
                conditions);
            effectsConditions.AddEffectConditions(new HealingEffect(unit, 0.5), extraConditions);
        }
        else if (_skillName == "Resonance")
        {
            weapons.AddWeapons(["Magic"]);
            conditions.AddSingleCondition(new UnitUseWeaponType(unit, weapons));
            conditions.AddSingleCondition(new HpRespectNumber(unit, 2, ComparisonType.Greater));
            effectsConditions.AddEffectConditions(new BeforeCombatDamageEffect(unit, -1)
                , conditions);
            effectsConditions.AddEffectConditions(new ExtraDamageEffect(unit, 3, EffectDuration.FullRound), conditions);
        }
        
        else if (_skillName == "Flare")
        {
            weapons.AddWeapons(["Magic"]);
            conditions.AddSingleCondition(new UnitUseWeaponType(unit, weapons));
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Res", Convert.ToInt32(Math.Floor(
                    0.2 * rival.Stats.GetRes()))),
                conditions);
            effectsConditions.AddEffectConditions(new HealingEffect(unit, 0.5), conditions);
        }
        else if (_skillName == "Fury")
        {
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 4), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Def", 4), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Res", 4), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Spd", 4), conditions);
            effectsConditions.AddEffectConditions(new AfterCombatDamageEffect(unit, -8), 
                conditions);
        }
        else if (_skillName == "Mystic Boost")
        {
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Atk", 5), conditions);
            effectsConditions.AddEffectConditions(new AfterCombatDamageEffect(unit, 10), 
                conditions);
        }
        else if (_skillName == "Atk/Spd Push")
        {
            conditions.AddSingleCondition(new HpRespectPercentage(unit, 0.25, ComparisonType.Greater, _roundInfo));
            extraConditions.AddSingleCondition(new HpRespectPercentage(unit, 0.25, ComparisonType.Greater, _roundInfo));
            extraConditions.AddSingleCondition(new UnitHasAttacked(unit, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 7), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Spd", 7), conditions);
            effectsConditions.AddEffectConditions(new AfterCombatDamageEffect(unit, -5),
                extraConditions);
        }
        else if (_skillName == "Atk/Def Push")
        {
            conditions.AddSingleCondition(new HpRespectPercentage(unit, 0.25, ComparisonType.Greater, _roundInfo));
            extraConditions.AddSingleCondition(new HpRespectPercentage(unit, 0.25, ComparisonType.Greater, _roundInfo));
            extraConditions.AddSingleCondition(new UnitHasAttacked(unit, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 7), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Def", 7), conditions);
            effectsConditions.AddEffectConditions(new AfterCombatDamageEffect(unit, -5),
                extraConditions);
        }
        else if (_skillName == "Atk/Res Push")
        {
            conditions.AddSingleCondition(new HpRespectPercentage(unit, 0.25, ComparisonType.Greater, _roundInfo));
            extraConditions.AddSingleCondition(new HpRespectPercentage(unit, 0.25, ComparisonType.Greater, _roundInfo));
            extraConditions.AddSingleCondition(new UnitHasAttacked(unit, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 7), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Res", 7), conditions);
            effectsConditions.AddEffectConditions(new AfterCombatDamageEffect(unit, -5),
                extraConditions);
        }
        else if (_skillName == "Spd/Def Push")
        {
            conditions.AddSingleCondition(new HpRespectPercentage(unit, 0.25, ComparisonType.Greater, _roundInfo));
            extraConditions.AddSingleCondition(new HpRespectPercentage(unit, 0.25, ComparisonType.Greater, _roundInfo));
            extraConditions.AddSingleCondition(new UnitHasAttacked(unit, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Spd", 7), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Def", 7), conditions);
            effectsConditions.AddEffectConditions(new AfterCombatDamageEffect(unit, -5),
                extraConditions);
        }
        else if (_skillName == "Spd/Res Push")
        {
            conditions.AddSingleCondition(new HpRespectPercentage(unit, 0.25, ComparisonType.Greater, _roundInfo));
            extraConditions.AddSingleCondition(new HpRespectPercentage(unit, 0.25, ComparisonType.Greater, _roundInfo));
            extraConditions.AddSingleCondition(new UnitHasAttacked(unit, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Spd", 7), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Res", 7), conditions);
            effectsConditions.AddEffectConditions(new AfterCombatDamageEffect(unit, -5),
                extraConditions);
        }
        else if (_skillName == "Def/Res Push")
        {
            conditions.AddSingleCondition(new HpRespectPercentage(unit, 0.25, ComparisonType.Greater, _roundInfo));
            extraConditions.AddSingleCondition(new HpRespectPercentage(unit, 0.25, ComparisonType.Greater, _roundInfo));
            extraConditions.AddSingleCondition(new UnitHasAttacked(unit, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Def", 7), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Res", 7), conditions);
            effectsConditions.AddEffectConditions(new AfterCombatDamageEffect(unit, -5),
                extraConditions);
        }
        else if (_skillName == "True Dragon Wall")
        {
            weapons.AddWeapons(["Magic"]);
            conditions.AddSingleCondition(new StatComparison(unit, rival, "Res", "Res", 0, 
                ComparisonType.Greater));
            extraConditions.AddSingleCondition(new AllyWithWeaponType(unit, weapons));
            effectsConditions.AddEffectConditions(new StatDifferenceDamageReduction(unit, rival, "Res", 
                    EffectDuration.FirstAttack, 6), conditions);
            effectsConditions.AddEffectConditions(new StatDifferenceDamageReduction(unit, rival, "Res", 
                EffectDuration.FollowUp, 4), conditions);
            effectsConditions.AddEffectConditions(new AfterCombatDamageEffect(unit, 7), extraConditions);
        }
        else if (_skillName == "Scendscale")
        {
            extraConditions.AddSingleCondition(new UnitHasAttacked(unit, _roundInfo));
            effectsConditions.AddEffectConditions(new ExtraDamageBasedOnStat(unit, rival, "Atk", 0.25, 
                EffectDuration.FullRound, BasedOn.Unit), conditions);
            effectsConditions.AddEffectConditions(new AfterCombatDamageEffect(unit, -7), extraConditions);
            
        }
        else if (_skillName == "Mastermind")
        {

            conditions.AddSingleCondition(new HpRespectNumber(unit, 2, ComparisonType.Greater));
            extraConditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            effectsConditions.AddEffectConditions(new BeforeCombatDamageEffect(unit, -1),conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 9), extraConditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Spd", 9), extraConditions);
            effectsConditions.AddEffectConditions(new MasterMindEffect(unit, rival, EffectDuration.FullRound), extraConditions);
        }
        else if (_skillName == "Bewitching Tome")
        {
            weapons.AddWeapons(["Magic", "Bow"]);
            OrConditions orConditions = new OrConditions();
            orConditions.AddCondition(new UnitStartCombat(unit, _roundInfo));
            orConditions.AddCondition(new UnitUseWeaponType(rival, weapons));
            conditions.AddOrConditions(orConditions);
            effectsConditions.AddEffectConditions(new BewitchingTomeEffect(unit, rival, EffectDuration.BeforeCombat),
                conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 5), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Spd", 5), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Def", 5), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Res", 5), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", Convert.ToInt32(
                Math.Floor(0.2 * unit.Stats.GetSpd()))), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Spd", Convert.ToInt32(
                Math.Floor(0.2 * unit.Stats.GetSpd()))), conditions);
            effectsConditions.AddEffectConditions(new PercentageDamageReduction(unit, 0.3, EffectDuration.FirstAttack), 
                conditions);
            effectsConditions.AddEffectConditions(new AfterCombatDamageEffect(unit, 7), conditions);

        }
        else if (_skillName == "Quick Riposte")
        {
            conditions.AddSingleCondition(new HpRespectPercentage(unit, 0.6, ComparisonType.Greater, _roundInfo));
            conditions.AddSingleCondition((new UnitStartCombat(rival, _roundInfo)));
            effectsConditions.AddEffectConditions(new GuaranteeFollowUpEffect(unit), conditions);
        }
        else if (_skillName == "Follow-Up Ring")
        {
            conditions.AddSingleCondition(new HpRespectPercentage(unit, 0.5, ComparisonType.Greater, _roundInfo));
            effectsConditions.AddEffectConditions(new GuaranteeFollowUpEffect(unit), conditions);
        }
        else if (_skillName == "Wary Fighter")
        {
            conditions.AddSingleCondition(new HpRespectPercentage(unit, 0.5, ComparisonType.Greater, _roundInfo));
            effectsConditions.AddEffectConditions(new NegationEffect(unit, AttackType.FollowUpAttack), conditions);
            effectsConditions.AddEffectConditions(new NegationEffect(rival, AttackType.FollowUpAttack), conditions);
        }
        else if (_skillName == "Piercing Tribute")
        {
            effectsConditions.AddEffectConditions(new NegationOfGuaranteeEffect(rival, AttackType.FollowUpAttack), conditions);
        }
        else if (_skillName == "Mjölnir")
        {
            effectsConditions.AddEffectConditions(new NegationOfNegationEffect(unit, AttackType.FollowUpAttack),
                conditions);
        }
        else if (_skillName == "Brash Assaulta")
        {
            OrConditions orConditions = new OrConditions();
            orConditions.AddCondition(new HpRespectPercentage(unit, 0.99, ComparisonType.Less, _roundInfo));
            orConditions.AddCondition(new HpRespectPercentage(rival, 1, ComparisonType.Greater, _roundInfo));
            conditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            conditions.AddOrConditions(orConditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Def", 4), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Res", 4), conditions);
            effectsConditions.AddEffectConditions(new PercentageDamageReduction(unit, 0.3, EffectDuration.FirstAttack),
                conditions);
            effectsConditions.AddEffectConditions(new GuaranteeFollowUpEffect(unit), conditions);
        }
        else if (_skillName == "Melee Breaker")
        {
            weapons.AddWeapons(["Lance", "Sword", "Axe"]);
            conditions.AddSingleCondition(new HpRespectPercentage(unit, 0.5, ComparisonType.Greater, _roundInfo));
            conditions.AddSingleCondition(new UnitUseWeaponType(rival, weapons));
            effectsConditions.AddEffectConditions(new GuaranteeFollowUpEffect(unit), conditions);
            effectsConditions.AddEffectConditions(new NegationEffect(rival, AttackType.FollowUpAttack), conditions);
        }
        else if (_skillName == "Range Breaker")
        {
            weapons.AddWeapons(["Magic", "Bow"]);
            conditions.AddSingleCondition(new HpRespectPercentage(unit, 0.5, ComparisonType.Greater, _roundInfo));
            conditions.AddSingleCondition(new UnitUseWeaponType(rival, weapons));
            effectsConditions.AddEffectConditions(new GuaranteeFollowUpEffect(unit), conditions);
            effectsConditions.AddEffectConditions(new NegationEffect(rival, AttackType.FollowUpAttack), conditions);
        }
        else if (_skillName == "Pegasus Flight")
        {
            int resDifference = unit.Stats.GetRes() - rival.Stats.GetRes();
            int penalty = Math.Max(0, Math.Min(Convert.ToInt32(Math.Floor
                (0.8 * resDifference)), 8));
            ConditionsCollection noConditions = new ConditionsCollection();
            conditions.AddSingleCondition(new StatBaseComparison(unit, rival, "Spd", "Spd", -10
                ,ComparisonType.Greater));
            extraConditions.AddSingleCondition(new StatBaseComparison(unit, rival, "Spd", "Spd", -10
                ,ComparisonType.Greater));
            extraConditions.AddSingleCondition(new SumOfStatsComparison(unit, rival, "Spd", "Res"));
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Atk", 4), noConditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Def", 4), noConditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Atk", penalty), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Def", penalty), conditions);
            effectsConditions.AddEffectConditions(new NegationEffect(rival, AttackType.FollowUpAttack), extraConditions);
            
        }

        else if (_skillName == "Wyvern Flight")
        {
            int defDifference = unit.Stats.GetDef() - rival.Stats.GetDef();
            int penalty = Math.Max(0, Math.Min(Convert.ToInt32(Math.Floor
                (0.8 * defDifference)), 8));
            ConditionsCollection noConditions = new ConditionsCollection();
            conditions.AddSingleCondition(new StatBaseComparison(unit, rival, "Spd", "Spd", -10
                ,ComparisonType.Greater));
            extraConditions.AddSingleCondition(new StatBaseComparison(unit, rival, "Spd", "Spd", -10
                ,ComparisonType.Greater));
            extraConditions.AddSingleCondition(new SumOfStatsComparison(unit, rival, "Spd", "Def"));
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Atk", 4), noConditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Def", 4), noConditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Atk", penalty), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Def", penalty), conditions);
            effectsConditions.AddEffectConditions(new NegationEffect(rival, AttackType.FollowUpAttack), extraConditions);
            
            
        }
        else if (_skillName == "Null Follow-Up")
        {
            effectsConditions.AddEffectConditions(new NegationOfNegationEffect(unit, AttackType.FollowUpAttack), conditions);
            effectsConditions.AddEffectConditions(new NegationOfGuaranteeEffect(unit, AttackType.FollowUpAttack), conditions);
        }
        else if (_skillName == "Sturdy Impact")
        {
            conditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 6), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Def", 10), conditions);
            effectsConditions.AddEffectConditions(new NegationEffect(rival, AttackType.FollowUpAttack), conditions);
        }
        else if (_skillName == "Mirror Impact")
        {
            conditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Atk", 6), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Res", 10), conditions);
            effectsConditions.AddEffectConditions(new NegationEffect(rival, AttackType.FollowUpAttack), conditions);
        }
        else if (_skillName == "Swift Impact")
        {
            conditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Spd", 6), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Res", 10), conditions);
            effectsConditions.AddEffectConditions(new NegationEffect(rival, AttackType.FollowUpAttack), conditions);
        }
        else if (_skillName == "Steady Impact")
        {
            conditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Spd", 6), conditions);
            effectsConditions.AddEffectConditions(new BonusEffect(unit, "Def", 10), conditions);
            effectsConditions.AddEffectConditions(new NegationEffect(rival, AttackType.FollowUpAttack), conditions);
        }
        else if (_skillName == "Slick Fighter")
        {
            conditions.AddSingleCondition(new HpRespectPercentage(unit, 0.25, ComparisonType.Greater, _roundInfo));
            conditions.AddSingleCondition(new UnitStartCombat(rival, _roundInfo));
            effectsConditions.AddEffectConditions(new PenaltyNeutralizationEffect(unit, "Atk"), conditions);
            effectsConditions.AddEffectConditions(new PenaltyNeutralizationEffect(unit, "Spd"), conditions);
            effectsConditions.AddEffectConditions(new PenaltyNeutralizationEffect(unit, "Res"), conditions);
            effectsConditions.AddEffectConditions(new PenaltyNeutralizationEffect(unit, "Def"), conditions);
            effectsConditions.AddEffectConditions(new GuaranteeFollowUpEffect(unit), conditions);
        }
        
        else if (_skillName == "Wily Fighter")
        {
            conditions.AddSingleCondition(new HpRespectPercentage(unit, 0.25, ComparisonType.Greater, _roundInfo));
            conditions.AddSingleCondition(new UnitStartCombat(rival, _roundInfo));
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Atk"), conditions);
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Spd"), conditions);
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Res"), conditions);
            effectsConditions.AddEffectConditions(new BonusNeutralizationEffect(rival, "Def"), conditions);
            effectsConditions.AddEffectConditions(new GuaranteeFollowUpEffect(unit), conditions);
        }
            
        else if (_skillName == "Savvy Fighter")
        {
            
            conditions.AddSingleCondition(new UnitStartCombat(rival, _roundInfo));
            extraConditions.AddSingleCondition(new UnitStartCombat(rival, _roundInfo));
            extraConditions.AddSingleCondition((new StatComparison(unit, rival, "Spd", "Spd", -4, 
                ComparisonType.Greater)));
            effectsConditions.AddEffectConditions(new NegationOfGuaranteeEffect(rival, AttackType.FollowUpAttack), conditions);
            effectsConditions.AddEffectConditions(new NegationOfNegationEffect(unit, AttackType.FollowUpAttack), conditions);
            effectsConditions.AddEffectConditions(new PercentageDamageReduction(unit, 0.3, EffectDuration.FirstAttack), 
                conditions);
        }
        else if (_skillName == "Flow Force")
        {
            conditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            effectsConditions.AddEffectConditions(new NegationOfNegationEffect(unit, AttackType.FollowUpAttack), conditions);
            effectsConditions.AddEffectConditions(new PenaltyNeutralizationEffect(unit, "Atk"), conditions);
            effectsConditions.AddEffectConditions(new PenaltyNeutralizationEffect(unit, "Spd"), conditions);
        }
            
        else if (_skillName == "Flow Refresh")
        {
            conditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            effectsConditions.AddEffectConditions(new NegationOfNegationEffect(unit, AttackType.FollowUpAttack), conditions);
            effectsConditions.AddEffectConditions(new AfterCombatDamageEffect(unit, 10), conditions);
        }
        else if (_skillName == "Flow Feather")
        {
            int resDifference = unit.Stats.GetRes() - rival.Stats.GetRes();
            int damage = Math.Max(0, Math.Min(Convert.ToInt32(Math.Floor
                (0.7 * resDifference)), 7));
            conditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            extraConditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            extraConditions.AddSingleCondition(new StatComparison(unit, rival, "Spd", "Spd", -10,
                ComparisonType.Greater));
            effectsConditions.AddEffectConditions(new NegationOfNegationEffect(unit, AttackType.FollowUpAttack), conditions);
            effectsConditions.AddEffectConditions(new ExtraDamageEffect(unit, damage, EffectDuration.FullRound), extraConditions);
            effectsConditions.AddEffectConditions(new AbsoluteDamageReduction(unit, damage, EffectDuration.FullRound),
                extraConditions);
        }
        else if (_skillName == "Flow Flight")
        {
            int defDifference = unit.Stats.GetDef() - rival.Stats.GetDef();
            int damage = Math.Max(0, Math.Min(Convert.ToInt32(Math.Floor
                (0.7 * defDifference)), 7));
            conditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            extraConditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            extraConditions.AddSingleCondition(new StatComparison(unit, rival, "Spd", "Spd", -10,
                ComparisonType.Greater));
            effectsConditions.AddEffectConditions(new NegationOfNegationEffect(unit, AttackType.FollowUpAttack), conditions);
            effectsConditions.AddEffectConditions(new ExtraDamageEffect(unit, damage, EffectDuration.FullRound), extraConditions);
            effectsConditions.AddEffectConditions(new AbsoluteDamageReduction(unit, damage, EffectDuration.FullRound),
                extraConditions);
        }
        else if (_skillName == "Binding Shield")
        {
            conditions.AddSingleCondition(new StatComparison(unit, rival, "Spd", "Spd", 5, 
                ComparisonType.Greater));
            extraConditions.AddSingleCondition(new StatComparison(unit, rival, "Spd", "Spd", 5, 
                ComparisonType.Greater));
            extraConditions.AddSingleCondition(new UnitStartCombat(unit, _roundInfo));
            effectsConditions.AddEffectConditions(new GuaranteeFollowUpEffect(unit), conditions);
            effectsConditions.AddEffectConditions(new NegationEffect(rival, AttackType.FollowUpAttack), conditions);
            effectsConditions.AddEffectConditions(new NegationEffect(rival, AttackType.CounterAttack), extraConditions);
            
        }
        else if (_skillName == "Sun-Twin Wing")
        {
            conditions.AddSingleCondition(new HpRespectPercentage(unit, 0.25, ComparisonType.Greater, 
                _roundInfo));
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Spd", 5), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Def", 5), conditions);
            effectsConditions.AddEffectConditions(new NegationOfGuaranteeEffect(rival, AttackType.FollowUpAttack), conditions);
            effectsConditions.AddEffectConditions(new NegationOfNegationEffect(unit, AttackType.FollowUpAttack), conditions);
        }
        else if (_skillName == "Dragon's Ire")
        {
            conditions.AddSingleCondition(new HpRespectPercentage(unit, 0.25, ComparisonType.Greater, 
                _roundInfo));
            extraConditions.AddSingleCondition(new HpRespectPercentage(unit, 0.25, ComparisonType.Greater, 
                _roundInfo));
            extraConditions.AddSingleCondition(new UnitStartCombat(rival, _roundInfo));
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Atk", 4), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Res", 4), conditions);
            effectsConditions.AddEffectConditions(new GuaranteeFollowUpEffect(unit), conditions);
            effectsConditions.AddEffectConditions(new NegationOfNegationEffect(unit, AttackType.FollowUpAttack),
                extraConditions);
        }
        else if (_skillName == "Black Eagle Rule")
        {
            conditions.AddSingleCondition(new HpRespectPercentage(unit, 0.25, ComparisonType.Greater, 
                _roundInfo));
            extraConditions.AddSingleCondition(new HpRespectPercentage(unit, 0.25, ComparisonType.Greater, 
                _roundInfo));
            extraConditions.AddSingleCondition(new UnitStartCombat(rival, _roundInfo));
            effectsConditions.AddEffectConditions(new GuaranteeFollowUpEffect(unit), conditions);
            effectsConditions.AddEffectConditions(new PercentageDamageReduction(unit, 0.8, EffectDuration.FollowUp), 
                extraConditions);
        }
        else if (_skillName == "Blue Lion Rule")
        {
            conditions.AddSingleCondition(new StatComparison(unit, rival, "Def", "Def", 0, 
                ComparisonType.StrictlyGreater));
            extraConditions.AddSingleCondition(new UnitStartCombat(rival, _roundInfo));
            effectsConditions.AddEffectConditions(new StatDifferenceDamageReduction(unit, rival, "Def", 
                EffectDuration.FullRound, 4), conditions);
            effectsConditions.AddEffectConditions(new GuaranteeFollowUpEffect(unit), extraConditions);
        }
        else if (_skillName == "New Divinity")
        {
            ConditionsCollection exceptionalConditions = new ConditionsCollection();
            exceptionalConditions.AddSingleCondition(new HpRespectPercentage(unit, 0.4, ComparisonType.Greater,
                _roundInfo));
            conditions.AddSingleCondition(new HpRespectPercentage(unit, 0.25, ComparisonType.Greater, _roundInfo));
            extraConditions.AddSingleCondition(new HpRespectPercentage(unit, 0.25, ComparisonType.Greater, _roundInfo));
            extraConditions.AddSingleCondition(new StatComparison(unit, rival, "Res", "Res", 0,
                ComparisonType.StrictlyGreater));
            effectsConditions.AddEffectConditions(new NegationEffect(rival, AttackType.FollowUpAttack), exceptionalConditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Atk", 5), conditions);
            effectsConditions.AddEffectConditions(new PenaltyEffect(rival, "Res", 5), conditions);
            effectsConditions.AddEffectConditions(new StatDifferenceDamageReduction(unit, rival, "Res", 
                EffectDuration.FullRound, 4), extraConditions);
            
            
        }
        
        else
        {
            throw new NoSkillException();
        }
        
        
        return new Skill(effectsConditions);
    }
}

