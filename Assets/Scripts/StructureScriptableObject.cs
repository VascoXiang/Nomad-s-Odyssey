using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Structure Scriptable Object that contains each building's info on requirements to improve, level and buffs
/// </summary>
[CreateAssetMenu(fileName = "StructureStats ScriptableObject", menuName = "StructureStats ScriptableObject")]
public class StructureScriptableObject : ScriptableObject
{
    [SerializeField] private int level;
    [SerializeField] private int buff;
    [SerializeField] private int ironRequirementLevel1 = 1;
    [SerializeField] private int ironRequirementLevel2 = 1;
    [SerializeField] private int ironRequirementLevel3 = 1;
    [SerializeField] private int woodRequirementLevel1 = 1;
    [SerializeField] private int woodRequirementLevel2 = 1;
    [SerializeField] private int woodRequirementLevel3 = 1;
   

    /// <summary>
    /// Defines the level 0 for each building
    /// </summary>
    public void EarlyGameStart()
    {
        level = 0;
        buff = 1;
    }
    /// <summary>
    /// Returns the level of the building
    /// </summary>
    /// <returns>Level of the building</returns>
    public int GetLevel()
    {
        return level;
    }
    /// <summary>
    /// Returns the value of the buff
    /// </summary>
    /// <returns>Value of the buff (multiplier or additive value)</returns>
    public int GetBuff() { return buff; }

    /// <summary>
    /// Given the level, returns the iron and wood requirements for that specific level for the building
    /// </summary>
    /// <param name="level">Level whose resources requirements are returned</param>
    /// <returns>int[] with two values: [0] is iron requirement and [1] is wood requirement</returns>
    public int[] GetRequirementsLevel(int level)
    {

        int[] requirements = new int[2];
        switch (level)
        {
            case 1:
                requirements[0] = ironRequirementLevel1;
                requirements[1] = woodRequirementLevel1;
                break;
            case 2:
                requirements[0] = ironRequirementLevel2;
                requirements[1] = woodRequirementLevel2;
                break;
            case 3:
                requirements[0] = ironRequirementLevel3;
                requirements[1] = woodRequirementLevel3;
                break;
            default:
                requirements[0] = 99999;
                requirements[1] = 99999;
                break;
        }

        return requirements;
    }
    /// <summary>
    /// Increments a level to the building
    /// </summary>
    public void IncrementLevel()
    {
        level++;
        if (level == 1)
        {
            setBuff(2);
        }
        if (level == 2)
        {
            setBuff(3);
        }
        if (level == 3)
        {
            setBuff(4);
        }
    }
    /// <summary>
    /// Sets a specific value for the buff multiplier/additive value
    /// </summary>
    /// <param name="buff">Integer number to set to the building's buff value</param>
    public void setBuff(int buff)
    {
        this.buff = buff;
    }
}