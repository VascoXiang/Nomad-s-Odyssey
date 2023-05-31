using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "StructureStats ScriptableObject", menuName = "StructureStats ScriptableObject")]


public class StructureScriptableObject : ScriptableObject
{
    private int level;
    [SerializeField] private const int ironRequirementLevel1 = 1;
    [SerializeField] private const int ironRequirementLevel2 = 1;
    [SerializeField] private const int ironRequirementLevel3 = 1;
    [SerializeField] private const int woodRequirementLevel1 = 1;
    [SerializeField] private const int woodRequirementLevel2 = 1;
    [SerializeField] private const int woodRequirementLevel3 = 1;


    // Start is called before the first frame update
    public void EarlyGameStart()
    {
        level = 0;
    }

    public int GetLevel()
    {
        return level;
    }

    public int[] getRequirementsLevel(int level)
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
        }

        return requirements;
    }

    public void incrementLevel()
    {
        level++;
    }
}