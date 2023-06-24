using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VillageStats ScriptableObject", menuName = "VillageStats ScriptableObject")]
public class VillageStatsScriptableObject : ScriptableObject
{
    private int wood;
    private int iron;
    private int nextRaid = 2;
    [SerializeField] private StructureScriptableObject ironMine;
    [SerializeField] private StructureScriptableObject market;
    [SerializeField] private StructureScriptableObject mainBuilding;
    [SerializeField] private StructureScriptableObject sawmill;
    [SerializeField] private StructureScriptableObject wall;


    [SerializeField] GameObject principal1;
    [SerializeField] GameObject principal2;
    [SerializeField] GameObject principal3;
    [SerializeField] GameObject sawmill1;
    [SerializeField] GameObject sawmill2;
    [SerializeField] GameObject market1;
    [SerializeField] GameObject market2;
    [SerializeField] GameObject market3;
    [SerializeField] GameObject mine1;
    [SerializeField] GameObject mine2;
    [SerializeField] GameObject mine3;
    [SerializeField] GameObject startingWall1;
    [SerializeField] GameObject startingWall2;
    [SerializeField] GameObject startingWall3;
    [SerializeField] GameObject startingWall4;
    [SerializeField] GameObject startingWall5;
    [SerializeField] GameObject startingWall6;
    [SerializeField] GameObject startingWall7;
    [SerializeField] GameObject startingWall8;
    [SerializeField] GameObject startingWall9;
    [SerializeField] GameObject startingWall10;
    [SerializeField] GameObject startingWall11;
    [SerializeField] GameObject startingWall12;
    [SerializeField] GameObject wall2;


    public void EarlyGameStart()
    {
        DefaultStart();
    }

    public void IncrementStructureLevel(String structure, int nextLevel)
    {
        int[] requirements = new int[2];
        switch (structure)
        {
            case "ironMine":
                requirements = ironMine.GetRequirementsLevel(nextLevel);
                if (this.iron >= requirements[0] && this.wood >= requirements[1])
                {
                    this.iron -= requirements[0];
                    this.wood -= requirements[1];
                    ironMine.IncrementLevel();
                    if (nextLevel == 1) MineLevel1();
                    else if (nextLevel == 2) MineLevel2();
                    else if (nextLevel == 3) MineLevel3();
                }
                break;
            case "market":
                requirements = market.GetRequirementsLevel(nextLevel);
                if (this.iron >= requirements[0] && this.wood >= requirements[1])
                {
                    this.iron -= requirements[0];
                    this.wood -= requirements[1];
                    market.IncrementLevel();
                    if (nextLevel == 1) MarketLevel1();
                    else if (nextLevel == 2) MarketLevel2();
                    else if (nextLevel == 3) MarketLevel3();
                }
                break;
            case "mainBuilding":
                requirements = mainBuilding.GetRequirementsLevel(nextLevel);
                if (this.iron >= requirements[0] && this.wood >= requirements[1])
                {
                    this.iron -= requirements[0];
                    this.wood -= requirements[1];
                    mainBuilding.IncrementLevel();
                    if (nextLevel == 2) PrincipalLevel2();
                    else if (nextLevel == 3) PrincipalLevel3();
                }
                break;
            case "sawmill":
                requirements = sawmill.GetRequirementsLevel(nextLevel);
                if (this.iron >= requirements[0] && this.wood >= requirements[1])
                {
                    this.iron -= requirements[0];
                    this.wood -= requirements[1];
                    sawmill.IncrementLevel();
                    if (nextLevel == 1) SawmillLevel1();
                    else if (nextLevel == 2) SawmillLevel2();
                }
                break;
            case "wall":
                requirements = wall.GetRequirementsLevel(nextLevel);
                if (this.iron >= requirements[0] && this.wood >= requirements[1])
                {
                    this.iron -= requirements[0];
                    this.wood -= requirements[1];
                    wall.IncrementLevel();
                    if (nextLevel == 1) WallLevel1();
                    else if (nextLevel == 2) WallLevel2();
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

    public void AddWood(int wood)
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


    private void DefaultStart()
    {
        this.iron = 0;
        this.wood = 0;
        Instantiate(principal1, principal1.transform.position, principal1.transform.rotation);
        getMainBuildingScriptableObject().EarlyGameStart();
        getMainBuildingScriptableObject().IncrementLevel();
        getMainBuildingScriptableObject().setBuff(1);
        getMarketScriptableObject().EarlyGameStart();
        getMineScriptableObject().EarlyGameStart();
        getSawmillScriptableObject().EarlyGameStart();
        getWallScriptableObject().EarlyGameStart();
    }

    public void PrincipalLevel2()
    {
        Instantiate(principal2, principal2.transform.position, principal2.transform.rotation);
    }

    public void PrincipalLevel3()
    {
        Instantiate(principal3, principal3.transform.position, principal3.transform.rotation);
    }

    public void SawmillLevel1()
    {
        Instantiate(sawmill1, sawmill1.transform.position, sawmill1.transform.rotation);
    }

    public void SawmillLevel2()
    {
        Instantiate(sawmill2, sawmill2.transform.position, sawmill2.transform.rotation);
    }

    public void MarketLevel1()
    {
        Instantiate(market1, market1.transform.position, market1.transform.rotation);
    }

    public void MarketLevel2()
    {
        Instantiate(market2, market2.transform.position, market2.transform.rotation);
    }

    public void MarketLevel3()
    {
        Instantiate(market3, market3.transform.position, market3.transform.rotation);
    }

    public void MineLevel1()
    {
        Instantiate(mine1, mine1.transform.position, mine1.transform.rotation);
    }

    public void MineLevel2()
    {
        Instantiate(mine2, mine2.transform.position, mine2.transform.rotation);
    }

    public void MineLevel3()
    {
        Instantiate(mine3, mine3.transform.position, mine3.transform.rotation);
    }

    public void WallLevel1()
    {
        Instantiate(startingWall1, startingWall1.transform.position, startingWall1.transform.rotation);
        Instantiate(startingWall2, startingWall2.transform.position, startingWall2.transform.rotation);
        Instantiate(startingWall3, startingWall3.transform.position, startingWall3.transform.rotation);
        Instantiate(startingWall4, startingWall4.transform.position, startingWall4.transform.rotation);
        Instantiate(startingWall5, startingWall5.transform.position, startingWall5.transform.rotation);
        Instantiate(startingWall6, startingWall6.transform.position, startingWall6.transform.rotation);
        Instantiate(startingWall7, startingWall7.transform.position, startingWall7.transform.rotation);
        Instantiate(startingWall8, startingWall8.transform.position, startingWall8.transform.rotation);
        Instantiate(startingWall9, startingWall9.transform.position, startingWall9.transform.rotation);
        Instantiate(startingWall10, startingWall10.transform.position, startingWall10.transform.rotation);
        Instantiate(startingWall11, startingWall11.transform.position, startingWall11.transform.rotation);
        Instantiate(startingWall12, startingWall12.transform.position, startingWall12.transform.rotation);
    }

    public void WallLevel2()
    {
        Instantiate(wall2, wall2.transform.position, wall2.transform.rotation);
    }

    public int getNextRaid()
    {
        return nextRaid;
    }

    public void setNextRaid(int nextRaid)
    {
        this.nextRaid = nextRaid;
    }
}
