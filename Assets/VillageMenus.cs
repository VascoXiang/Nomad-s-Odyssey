using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VillageMenus : MonoBehaviour
{

    [SerializeField] VillageStatsScriptableObject villageStats;

    [SerializeField] GameObject mainBuildingWindow;
    [SerializeField] GameObject sawmillWindow;
    [SerializeField] GameObject mineWindow;
    [SerializeField] GameObject marketWindow;
    [SerializeField] GameObject wallWindow;

    // texts from MainBuilding
    [SerializeField] TMP_Text mainLevel;
    [SerializeField] TMP_Text mainBuff;
    [SerializeField] TMP_Text mainIronNeeded;
    [SerializeField] TMP_Text mainWoodNeeded;

    // texts from Sawmill
    [SerializeField] TMP_Text sawmillLevel;
    [SerializeField] TMP_Text sawmillBuff;
    [SerializeField] TMP_Text sawmillIronNeeded;
    [SerializeField] TMP_Text sawmillWoodNeeded;

    // texts from Mine
    [SerializeField] TMP_Text mineLevel;
    [SerializeField] TMP_Text mineBuff;
    [SerializeField] TMP_Text mineIronNeeded;
    [SerializeField] TMP_Text mineWoodNeeded;

    // texts from Market
    [SerializeField] TMP_Text marketLevel;
    [SerializeField] TMP_Text marketBuff;
    [SerializeField] TMP_Text marketIronNeeded;
    [SerializeField] TMP_Text marketWoodNeeded;

    // texts from Wall
    [SerializeField] TMP_Text wallLevel;
    [SerializeField] TMP_Text wallBuff;
    [SerializeField] TMP_Text wallIronNeeded;
    [SerializeField] TMP_Text wallWoodNeeded;

    //level up Buttons
    [SerializeField] GameObject mainBuildingLevelUp;
    [SerializeField] GameObject sawmillLevelUp;
    [SerializeField] GameObject mineLevelUp;
    [SerializeField] GameObject marketLevelUp;
    [SerializeField] GameObject wallLevelUp;

    private void Update()
    {
        if (mainBuildingWindow.activeSelf)
        {
            int levelMain = villageStats.getMainBuildingScriptableObject().GetLevel();
            mainLevel.text = levelMain + "";
            mainBuff.text = villageStats.getMainBuildingScriptableObject().GetBuff() + "";
            int ironNeeded = villageStats.getMainBuildingScriptableObject().GetRequirementsLevel(levelMain + 1)[0];
            int woodNeeded = villageStats.getMainBuildingScriptableObject().GetRequirementsLevel(levelMain + 1)[1];
            mainIronNeeded.text = ironNeeded.ToString();
            mainWoodNeeded.text = woodNeeded.ToString();

            if(villageStats.GetIronResources()>=ironNeeded && villageStats.GetWoodResources() >= woodNeeded)
            {
                mainBuildingLevelUp.SetActive(true);
            }
            else mainBuildingLevelUp.SetActive(false);
        }

        if (sawmillWindow.activeSelf)
        {
            int levelSawmill = villageStats.getSawmillScriptableObject().GetLevel();
            sawmillLevel.text = levelSawmill + "";
            sawmillBuff.text = villageStats.getSawmillScriptableObject().GetBuff() + "";
            int ironNeeded = villageStats.getSawmillScriptableObject().GetRequirementsLevel(levelSawmill + 1)[0];
            int woodNeeded = villageStats.getSawmillScriptableObject().GetRequirementsLevel(levelSawmill + 1)[1];
            sawmillIronNeeded.text = ironNeeded.ToString();
            sawmillWoodNeeded.text = woodNeeded.ToString();

            if (villageStats.GetIronResources() >= ironNeeded && villageStats.GetWoodResources() >= woodNeeded)
            {
                sawmillLevelUp.SetActive(true);
            }
            else sawmillLevelUp.SetActive(false);
        }

        if (mineWindow.activeSelf)
        {
            int levelMine = villageStats.getMineScriptableObject().GetLevel();
            mineLevel.text = levelMine + "";
            mineBuff.text = villageStats.getMineScriptableObject().GetBuff() + "";
            int ironNeeded = villageStats.getMineScriptableObject().GetRequirementsLevel(levelMine + 1)[0];
            int woodNeeded = villageStats.getMineScriptableObject().GetRequirementsLevel(levelMine + 1)[1];
            mineIronNeeded.text = ironNeeded.ToString();
            mineWoodNeeded.text = woodNeeded.ToString();

            if (villageStats.GetIronResources() >= ironNeeded && villageStats.GetWoodResources() >= woodNeeded)
            {
                mineLevelUp.SetActive(true);
            }
            else mineLevelUp.SetActive(false);
        }

        if (marketWindow.activeSelf)
        {
            int levelMarket = villageStats.getMarketScriptableObject().GetLevel();
            marketLevel.text = levelMarket + "";
            marketBuff.text = villageStats.getMarketScriptableObject().GetBuff() + "";
            int ironNeeded = villageStats.getMarketScriptableObject().GetRequirementsLevel(levelMarket + 1)[0];
            int woodNeeded = villageStats.getMarketScriptableObject().GetRequirementsLevel(levelMarket + 1)[1];
            marketIronNeeded.text = ironNeeded.ToString();
            marketWoodNeeded.text = woodNeeded.ToString();

            if (villageStats.GetIronResources() >= ironNeeded && villageStats.GetWoodResources() >= woodNeeded)
            {
                marketLevelUp.SetActive(true);
            }
            else marketLevelUp.SetActive(false);
        }

        if (wallWindow.activeSelf)
        {
            int levelWall = villageStats.getWallScriptableObject().GetLevel();
            wallLevel.text = levelWall + "";
            wallBuff.text = villageStats.getWallScriptableObject().GetBuff() + "";
            int ironNeeded = villageStats.getWallScriptableObject().GetRequirementsLevel(levelWall + 1)[0];
            int woodNeeded = villageStats.getWallScriptableObject().GetRequirementsLevel(levelWall + 1)[1];
            wallIronNeeded.text = ironNeeded.ToString();
            wallWoodNeeded.text = woodNeeded.ToString();

            if (villageStats.GetIronResources() >= ironNeeded && villageStats.GetWoodResources() >= woodNeeded)
            {
                wallLevelUp.SetActive(true);
            }
            else wallLevelUp.SetActive(false);
        }

    }

    public void OpenMainBuildingWindow()
    {
        mainBuildingWindow.SetActive(true);
        sawmillWindow.SetActive(false);
        marketWindow.SetActive(false);
        wallWindow.SetActive(false);
        mineWindow.SetActive(false);
    }

    public void CloseMainBuildingWindow()
    {
        mainBuildingWindow.SetActive(false);
    }

    public void OpenSawmillWindow()
    {
        mainBuildingWindow.SetActive(false);
        sawmillWindow.SetActive(true);
        marketWindow.SetActive(false);
        wallWindow.SetActive(false);
        mineWindow.SetActive(false);
    }

    public void CloseSawmillWindow()
    {
        sawmillWindow.SetActive(false);
    }

    public void OpenMarketWindow()
    {
        mainBuildingWindow.SetActive(false);
        sawmillWindow.SetActive(false);
        marketWindow.SetActive(true);
        wallWindow.SetActive(false);
        mineWindow.SetActive(false);
    }

    public void CloseMarketWindow()
    {
        marketWindow.SetActive(false);
    }

    public void OpenWallWindow()
    {
        mainBuildingWindow.SetActive(false);
        sawmillWindow.SetActive(false);
        marketWindow.SetActive(false);
        wallWindow.SetActive(true);
        mineWindow.SetActive(false);
    }

    public void CloseWallWindow()
    {
        wallWindow.SetActive(false);
    }

    public void OpenMineWindow()
    {
        mainBuildingWindow.SetActive(false);
        sawmillWindow.SetActive(false);
        marketWindow.SetActive(false);
        wallWindow.SetActive(false);
        mineWindow.SetActive(true);
    }

    public void CloseMineWindow()
    {
        mineWindow.SetActive(false);
    }

    public void LevelUpMainBuilding()
    {
        int levelMain = villageStats.getMainBuildingScriptableObject().GetLevel();
        villageStats.IncrementStructureLevel("mainBuilding",levelMain+1);
        CloseMainBuildingWindow();
    }

    public void LevelUpMarket()
    {
        int levelMarket = villageStats.getMarketScriptableObject().GetLevel();
        villageStats.IncrementStructureLevel("market", levelMarket+1);
        CloseMarketWindow();
    }

    public void LevelUpMine()
    {
        int levelMine = villageStats.getMineScriptableObject().GetLevel(); 
        villageStats.IncrementStructureLevel("ironMine", levelMine+1);
        CloseMineWindow();
    }

    public void LevelUpSawmill()
    {
        int levelSawmill = villageStats.getSawmillScriptableObject().GetLevel() ;
        villageStats.IncrementStructureLevel("sawmill", levelSawmill+1);
        CloseSawmillWindow();
    }

    public void LevelUpWall()
    {
        int levelWall = villageStats.getWallScriptableObject().GetLevel() ;
        villageStats.IncrementStructureLevel("wall", levelWall+1);
        CloseWallWindow();
    }
}
