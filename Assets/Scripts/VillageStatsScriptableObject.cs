using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable Object for the whole village, which contains reference to all the buildings
/// scriptable objects, current resources in the settlement and number of the raid to load next
/// </summary>
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

    [SerializeField] private GameObject principal1;
    [SerializeField] private GameObject principal2;
    [SerializeField] private GameObject principal3;
    [SerializeField] private GameObject sawmill1;
    [SerializeField] private GameObject sawmill2;
    [SerializeField] private GameObject market1;
    [SerializeField] private GameObject market2;
    [SerializeField] private GameObject market3;
    [SerializeField] private GameObject mine1;
    [SerializeField] private GameObject mine2;
    [SerializeField] private GameObject mine3;
    [SerializeField] private GameObject startingWall1;
    [SerializeField] private GameObject startingWall2;
    [SerializeField] private GameObject startingWall3;
    [SerializeField] private GameObject startingWall4;
    [SerializeField] private GameObject startingWall5;
    [SerializeField] private GameObject startingWall6;
    [SerializeField] private GameObject startingWall7;
    [SerializeField] private GameObject startingWall8;
    [SerializeField] private GameObject startingWall9;
    [SerializeField] private GameObject startingWall10;
    [SerializeField] private GameObject startingWall11;
    [SerializeField] private GameObject startingWall12;
    [SerializeField] private GameObject wall2;

    /// <summary>
    /// Defines the start of the game for the village, including spawning the main building on level 1
    /// and other assortments
    /// </summary>
    public void EarlyGameStart()
    {
        DefaultStart();
    }
    /// <summary>
    /// Increments the level of a given structure, given it's next level
    /// </summary>
    /// <param name="structure">String name of the structure to level up</param>
    /// <param name="nextLevel">Integer next level of the Structure to level</param>
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
    /// <summary>
    /// Adds iron to the village
    /// </summary>
    /// <param name="iron">Number of iron to add</param>
    public void AddIron(int iron)
    {
        this.iron += iron;
    }
    /// <summary>
    /// Returns the iron in village
    /// </summary>
    /// <returns>Iron in village</returns>
    public int GetIronResources()
    {
        return iron;
    }
    /// <summary>
    /// Adds wood to the village
    /// </summary>
    /// <param name="wood">Number of wood to add</param>
    public void AddWood(int wood)
    {
        this.wood += wood;
    }
    /// <summary>
    /// Returns the wood in village
    /// </summary>
    /// <returns>Wood in village</returns>
    public int GetWoodResources()
    {
        return wood;
    }

    /// <summary>
    /// Getter of the Mine Scriptable Object
    /// </summary>
    /// <returns>Mine Scriptable Object</returns>
    public StructureScriptableObject getMineScriptableObject() { return ironMine; }
    /// <summary>
    /// Getter of the Wall Scriptable Object
    /// </summary>
    /// <returns>Wall Scriptable Object</returns>
    public StructureScriptableObject getWallScriptableObject() { return wall; }
    /// <summary>
    /// Getter of the Market Scriptable Object
    /// </summary>
    /// <returns>Market Scriptable Object</returns>
    public StructureScriptableObject getMarketScriptableObject() { return market; }
    /// <summary>
    /// Getter of the Main Building Scriptable Object
    /// </summary>
    /// <returns>Main Building Scriptable Object</returns>
    public StructureScriptableObject getMainBuildingScriptableObject() { return mainBuilding; }
    /// <summary>
    /// Getter of the Sawmill Scriptable Object
    /// </summary>
    /// <returns>Sawmill Scriptable Object</returns>
    public StructureScriptableObject getSawmillScriptableObject() { return sawmill; }

    /// <summary>
    /// The Default start of the village in early game. 0 resources, only Main Building at level 1 and
    /// resets the remaining buildings to level 0
    /// </summary>
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
    /// <summary>
    /// Spawn Main Building Lvl2 Structure
    /// </summary>
    public void PrincipalLevel2()
    {
        Instantiate(principal2, principal2.transform.position, principal2.transform.rotation);
    }
    /// <summary>
    /// Spawn Main Building Lvl3 Structure
    /// </summary>
    public void PrincipalLevel3()
    {
        Instantiate(principal3, principal3.transform.position, principal3.transform.rotation);
    }
    /// <summary>
    /// Spawn Sawmill Lvl1 Structure
    /// </summary>
    public void SawmillLevel1()
    {
        Instantiate(sawmill1, sawmill1.transform.position, sawmill1.transform.rotation);
    }
    /// <summary>
    /// Spawn Sawmill Lvl2 Structure
    /// </summary>
    public void SawmillLevel2()
    {
        Instantiate(sawmill2, sawmill2.transform.position, sawmill2.transform.rotation);
    }
    /// <summary>
    /// Spawn Market Lvl1 Structure
    /// </summary>
    public void MarketLevel1()
    {
        Instantiate(market1, market1.transform.position, market1.transform.rotation);
    }
    /// <summary>
    /// Spawn Market Lvl2 Structure
    /// </summary>
    public void MarketLevel2()
    {
        Instantiate(market2, market2.transform.position, market2.transform.rotation);
    }
    /// <summary>
    /// Spawn Market Lvl3 Structure
    /// </summary>
    public void MarketLevel3()
    {
        Instantiate(market3, market3.transform.position, market3.transform.rotation);
    }
    /// <summary>
    /// Spawn Mine Lvl1 Structure
    /// </summary>
    public void MineLevel1()
    {
        Instantiate(mine1, mine1.transform.position, mine1.transform.rotation);
    }
    /// <summary>
    /// Spawn Mine Lvl2 Structure
    /// </summary>
    public void MineLevel2()
    {
        Instantiate(mine2, mine2.transform.position, mine2.transform.rotation);
    }
    /// <summary>
    /// Spawn Mine Lvl3 Structure
    /// </summary>
    public void MineLevel3()
    {
        Instantiate(mine3, mine3.transform.position, mine3.transform.rotation);
    }
    /// <summary>
    /// Spawn Wall Lvl1 Structures
    /// </summary>
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

    /// <summary>
    /// Spawn Wall Lvl2 Structure
    /// </summary>
    public void WallLevel2()
    {
        Instantiate(wall2, wall2.transform.position, wall2.transform.rotation);
    }
    /// <summary>
    /// Returns the number of the next raid to load
    /// </summary>
    /// <returns>Number of next raid to load</returns>
    public int getNextRaid()
    {
        return nextRaid;
    }
    /// <summary>
    /// Sets the number of the next raid
    /// </summary>
    /// <param name="nextRaid">Value of the next raid to load</param>
    public void setNextRaid(int nextRaid)
    {
        this.nextRaid = nextRaid;
    }
}
