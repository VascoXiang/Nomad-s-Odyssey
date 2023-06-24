using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
   
    // Start is called before the first frame update
    public void EarlyGameStart()
    {
        level = 0;
        buff = 1;
    }

    public int GetLevel()
    {
        return level;
    }

    public int GetBuff() { return buff; }

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

    public void setBuff(int buff)
    {
        this.buff = buff;
    }
}