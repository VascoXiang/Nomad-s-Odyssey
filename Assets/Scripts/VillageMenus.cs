using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VillageMenus : MonoBehaviour
{
    [SerializeField] VillageStatsScriptableObject villageStats;
    [SerializeField] PlayerStatsScriptableObject playerStats;

    [SerializeField] GameObject mainBuildingWindow;
    [SerializeField] GameObject sawmillWindow;
    [SerializeField] GameObject mineWindow;
    [SerializeField] GameObject marketWindow;
    [SerializeField] GameObject wallWindow;

    // pause menu
    [SerializeField] GameObject pauseMenu;
    private Boolean isPauseOpen;

    // resources indicators
    [SerializeField] TMP_Text woodIndicator;
    [SerializeField] TMP_Text ironIndicator;

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

    private Boolean endGameTextShown;
    [SerializeField] GameObject endGameText;

    private void Start()
    {
        isPauseOpen = false;
        endGameTextShown = false;
        int currentMainBuildingLevel = villageStats.getMainBuildingScriptableObject().GetLevel();
        int currentMineLevel = villageStats.getMineScriptableObject().GetLevel();
        int currentMarketLevel = villageStats.getMarketScriptableObject().GetLevel();
        int currentSawmillLevel = villageStats.getSawmillScriptableObject().GetLevel();
        int currentWallLevel = villageStats.getWallScriptableObject().GetLevel();

        switch (currentMainBuildingLevel)
        {
            case 2:
                villageStats.PrincipalLevel2();
                break;
            case 3:
                villageStats.PrincipalLevel2();
                villageStats.PrincipalLevel3();
                break;
        }
        switch (currentMarketLevel)
        {
            case 1:
                villageStats.MarketLevel1();
                break;
            case 2:
                villageStats.MarketLevel1();
                villageStats.MarketLevel2();
                break;
            case 3:
                villageStats.MarketLevel1();
                villageStats.MarketLevel2();
                villageStats.MarketLevel3();
                break;
        }
        switch (currentMineLevel)
        {
            case 1:
                villageStats.MineLevel1();
                break;
            case 2:
                villageStats.MineLevel1();
                villageStats.MineLevel2();
                break;
            case 3:
                villageStats.MineLevel1();
                villageStats.MineLevel2();
                villageStats.MineLevel3();
                break;
        }
        switch (currentSawmillLevel)
        {
            case 1:
                villageStats.SawmillLevel1();
                break;
            case 2:
                villageStats.SawmillLevel1();
                villageStats.SawmillLevel2();
                break;
        }
        switch (currentWallLevel)
        {
            case 1:
                villageStats.WallLevel1();
                break;
            case 2:
                villageStats.WallLevel2();
                break;
        }
        villageStats.AddIron(playerStats.GetIronResources() * villageStats.getMineScriptableObject().GetBuff());
        villageStats.AddWood(playerStats.GetWoodResources() * villageStats.getSawmillScriptableObject().GetBuff());
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }

        int currentIron = villageStats.GetIronResources();
        int currentWood = villageStats.GetWoodResources();

        int levelMain = villageStats.getMainBuildingScriptableObject().GetLevel();
        int levelWall = villageStats.getWallScriptableObject().GetLevel();
        int levelSawmill = villageStats.getSawmillScriptableObject().GetLevel();
        int levelMine = villageStats.getMineScriptableObject().GetLevel();
        int levelMarket = villageStats.getMarketScriptableObject().GetLevel();

        woodIndicator.text = currentWood.ToString();
        ironIndicator.text = currentIron.ToString();

        if (mainBuildingWindow.activeSelf)
        {
            mainLevel.text = levelMain + "";
            mainBuff.text = villageStats.getMainBuildingScriptableObject().GetBuff() + "x Damage";
            int ironNeeded = villageStats.getMainBuildingScriptableObject().GetRequirementsLevel(levelMain + 1)[0];
            int woodNeeded = villageStats.getMainBuildingScriptableObject().GetRequirementsLevel(levelMain + 1)[1];
            mainIronNeeded.text = ironNeeded.ToString();
            mainWoodNeeded.text = woodNeeded.ToString();

            if (villageStats.GetIronResources() >= ironNeeded && villageStats.GetWoodResources() >= woodNeeded)
            {
                mainBuildingLevelUp.SetActive(true);
            }
            else mainBuildingLevelUp.SetActive(false);
        }

        if (sawmillWindow.activeSelf)
        {
            sawmillLevel.text = levelSawmill + "";
            sawmillBuff.text = villageStats.getSawmillScriptableObject().GetBuff() + "x Wood in Raid";
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
            mineLevel.text = levelMine + "";
            mineBuff.text = villageStats.getMineScriptableObject().GetBuff() + "x Iron in Raid";
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
            marketLevel.text = levelMarket + "";
            marketBuff.text = villageStats.getMarketScriptableObject().GetBuff() + "+ Speed";
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
            wallLevel.text = levelWall + "";
            wallBuff.text = "1/" + villageStats.getWallScriptableObject().GetBuff() + " Damage Taken";
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
        if (levelMain == 3 && levelMarket == 3 && levelMine == 3 && levelSawmill == 3 && levelWall == 3 && !endGameTextShown)
        {
            endGameText.SetActive(true);
        }

    }

    public void CloseEndGameText()
    {
        endGameTextShown = true;
        endGameText.SetActive(false);
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
        villageStats.IncrementStructureLevel("mainBuilding", levelMain + 1);
        CloseMainBuildingWindow();
    }

    public void LevelUpMarket()
    {
        int levelMarket = villageStats.getMarketScriptableObject().GetLevel();
        villageStats.IncrementStructureLevel("market", levelMarket + 1);
        CloseMarketWindow();
    }

    public void LevelUpMine()
    {
        int levelMine = villageStats.getMineScriptableObject().GetLevel();
        villageStats.IncrementStructureLevel("ironMine", levelMine + 1);
        CloseMineWindow();
    }

    public void LevelUpSawmill()
    {
        int levelSawmill = villageStats.getSawmillScriptableObject().GetLevel();
        villageStats.IncrementStructureLevel("sawmill", levelSawmill + 1);
        CloseSawmillWindow();
    }

    public void LevelUpWall()
    {
        int levelWall = villageStats.getWallScriptableObject().GetLevel();
        villageStats.IncrementStructureLevel("wall", levelWall + 1);
        CloseWallWindow();
    }

    public void GoToRaid()
    {
        int nextRaid = villageStats.getNextRaid();
        if (nextRaid == 2)
        {
            villageStats.setNextRaid(3);
            SceneManager.LoadScene(2);
        }
        else
        {
            villageStats.setNextRaid(2);
            SceneManager.LoadScene(3);
        }

    }

    public void TogglePauseMenu()
    {
        if (isPauseOpen)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1.0f;
            isPauseOpen = false;
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            isPauseOpen = true;
        }
    }

    public void ExitToMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
}
