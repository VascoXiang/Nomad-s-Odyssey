using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VillageStats ScriptableObject", menuName = "VillageStats ScriptableObject")]
public class VillageStatsScriptableObject : ScriptableObject
{
    private int wood;
    private int iron;
    private StructureScriptableObject ironMine;
    private StructureScriptableObject market;
    private StructureScriptableObject mainBuilding;
    private StructureScriptableObject sawmill;
    private StructureScriptableObject wall;


    // Start is called before the first frame update
    public void EarlyGameStart()
    {
        iron = 0;
        wood = 0;
    }

    public void IncrementStructureLevel(String structure, int nextLevel)
    {
        int[] requirements = new int[2];
        switch (structure)
        {
            case "ironMine":
                requirements = ironMine.getRequirementsLevel(nextLevel);
                if (this.iron >= requirements[0] || this.wood >= requirements[1])
                {
                    this.iron -= requirements[0];
                    this.wood -= requirements[1];
                    ironMine.incrementLevel();
                }
                break;
            case "market":
                requirements = market.getRequirementsLevel(nextLevel);
                if (this.iron >= requirements[0] || this.wood >= requirements[1])
                {
                    this.iron -= requirements[0];
                    this.wood -= requirements[1];
                    market.incrementLevel();
                }
                break;
            case "mainBuilding":
                requirements = mainBuilding.getRequirementsLevel(nextLevel);
                if (this.iron >= requirements[0] || this.wood >= requirements[1])
                {
                    this.iron -= requirements[0];
                    this.wood -= requirements[1];
                    mainBuilding.incrementLevel();
                }
                break;
            case "sawmill":
                requirements = sawmill.getRequirementsLevel(nextLevel);
                if (this.iron >= requirements[0] || this.wood >= requirements[1])
                {
                    this.iron -= requirements[0];
                    this.wood -= requirements[1];
                    sawmill.incrementLevel();
                }
                break;
            case "wall":
                requirements = wall.getRequirementsLevel(nextLevel);
                if (this.iron >= requirements[0] || this.wood >= requirements[1])
                {
                    this.iron -= requirements[0];
                    this.wood -= requirements[1];
                    wall.incrementLevel();
                }
                break;
        }
    }

    public void AddIron(int iron)
    {
        this.iron += iron;
    }

    public int GetIronResources()
    {
        return iron;
    }

    public void AddWoodResources(int wood)
    {
        this.wood += wood;
    }

    public int GetWoodResources()
    {
        return wood;
    }

    public StructureScriptableObject getMineScriptableObject() { return ironMine; }

    public StructureScriptableObject getWallScriptableObject() { return wall; }

    public StructureScriptableObject getMarketScriptableObject() { return market; }

    public StructureScriptableObject getMainBuildingScriptableObject() { return mainBuilding; }

    public StructureScriptableObject getSawmillScriptableObject() { return sawmill; }

}
