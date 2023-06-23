using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    [SerializeField] VillageStatsScriptableObject villageStatsScriptableObject;


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


    void DefaultStart()
    {
        Instantiate(principal1, principal1.transform.position, principal1.transform.rotation);
        villageStatsScriptableObject.EarlyGameStart();
        villageStatsScriptableObject.getMainBuildingScriptableObject().EarlyGameStart();
        villageStatsScriptableObject.getMainBuildingScriptableObject().incrementLevel();
    }

    void PrincipalLevel2()
    {
        villageStatsScriptableObject.IncrementStructureLevel("mainBuilding", 2);
        Instantiate(principal2, principal2.transform.position, principal2.transform.rotation);
    }

    void PrincipalLevel3()
    {
        villageStatsScriptableObject.IncrementStructureLevel("mainBuilding", 3);
        Instantiate(principal3, principal3.transform.position, principal3.transform.rotation);
    }

    void SawmillLevel1()
    {
        villageStatsScriptableObject.IncrementStructureLevel("sawmill", 1);
        Instantiate(sawmill1, sawmill1.transform.position, sawmill1.transform.rotation);
    }

    void SawmillLevel2()
    {
        villageStatsScriptableObject.IncrementStructureLevel("sawmill", 2);
        Instantiate(sawmill2, sawmill2.transform.position, sawmill2.transform.rotation);
    }

    void MarketLevel1()
    {
        villageStatsScriptableObject.IncrementStructureLevel("market", 1);
        Instantiate(market1, market1.transform.position, market1.transform.rotation);
    }

    void MarketLevel2()
    {
        villageStatsScriptableObject.IncrementStructureLevel("market", 2);
        Instantiate(market2, market2.transform.position, market2.transform.rotation);
    }

    void MarketLevel3()
    {
        villageStatsScriptableObject.IncrementStructureLevel("market", 3);
        Instantiate(market3, market3.transform.position, market3.transform.rotation);
    }

    void MineLevel1()
    {
        villageStatsScriptableObject.IncrementStructureLevel("ironMine", 1);
        Instantiate(mine1, mine1.transform.position, mine1.transform.rotation);
    }

    void MineLevel2()
    {
        villageStatsScriptableObject.IncrementStructureLevel("ironMine", 2);
        Instantiate(mine2, mine2.transform.position, mine2.transform.rotation);
    }

    void MineLevel3()
    {
        villageStatsScriptableObject.IncrementStructureLevel("ironMine", 3);
        Instantiate(mine3, mine3.transform.position, mine3.transform.rotation);
    }

    void WallLevel1()
    {
        villageStatsScriptableObject.IncrementStructureLevel("wall", 1);
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

    void WallLevel2()
    {
        villageStatsScriptableObject.IncrementStructureLevel("wall", 2);
        Instantiate(wall2, wall2.transform.position, wall2.transform.rotation);
    }

    void WallLevel3()
    {
        villageStatsScriptableObject.IncrementStructureLevel("wall", 3);
    }
}
