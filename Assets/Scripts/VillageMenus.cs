using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Class VillageMenus represents a full Controller of the 3D Village Scene.
/// It deals with all the info windows appearing/closing and the resource management and 
/// leveling of the different buildings
/// </summary>
public class VillageMenus : MonoBehaviour
{
    [SerializeField] private VillageStatsScriptableObject villageStats;
    [SerializeField] private PlayerStatsScriptableObject playerStats;
    [SerializeField] private SceneLoaderTransition _sceneTransition;

    [SerializeField] private GameObject mainBuildingWindow;
    [SerializeField] private GameObject sawmillWindow;
    [SerializeField] private GameObject mineWindow;
    [SerializeField] private GameObject marketWindow;
    [SerializeField] private GameObject wallWindow;

    // pause menu
    [SerializeField] private GameObject pauseMenu;
    private Boolean isPauseOpen;

    // resources indicators
    [SerializeField] private TMP_Text woodIndicator;
    [SerializeField] private TMP_Text ironIndicator;

    // texts from MainBuilding
    [SerializeField] private TMP_Text mainLevel;
    [SerializeField] private TMP_Text mainBuff;
    [SerializeField] private TMP_Text mainIronNeeded;
    [SerializeField] private TMP_Text mainWoodNeeded;

    // texts from Sawmill
    [SerializeField] private TMP_Text sawmillLevel;
    [SerializeField] private TMP_Text sawmillBuff;
    [SerializeField] private TMP_Text sawmillIronNeeded;
    [SerializeField] private TMP_Text sawmillWoodNeeded;

    // texts from Mine
    [SerializeField] private TMP_Text mineLevel;
    [SerializeField] private TMP_Text mineBuff;
    [SerializeField] private TMP_Text mineIronNeeded;
    [SerializeField] private TMP_Text mineWoodNeeded;

    // texts from Market
    [SerializeField] private TMP_Text marketLevel;
    [SerializeField] private TMP_Text marketBuff;
    [SerializeField] private TMP_Text marketIronNeeded;
    [SerializeField] private TMP_Text marketWoodNeeded;

    // texts from Wall
    [SerializeField] private TMP_Text wallLevel;
    [SerializeField] private TMP_Text wallBuff;
    [SerializeField] private TMP_Text wallIronNeeded;
    [SerializeField] private TMP_Text wallWoodNeeded;

    //level up Buttons
    [SerializeField] private GameObject mainBuildingLevelUp;
    [SerializeField] private GameObject sawmillLevelUp;
    [SerializeField] private GameObject mineLevelUp;
    [SerializeField] private GameObject marketLevelUp;
    [SerializeField] private GameObject wallLevelUp;

    private Boolean endGameTextShown;
    [SerializeField] private GameObject endGameText;

    /// <summary>
    /// Depending on the current levels of the buildings, it manages their spawns on scene
    /// everytime this scene is loaded
    /// </summary>
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
            case 3:
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
            case 3:
                villageStats.WallLevel2();
                break;
        }
        villageStats.AddIron(playerStats.GetIronResources() * villageStats.getMineScriptableObject().GetBuff());
        villageStats.AddWood(playerStats.GetWoodResources() * villageStats.getSawmillScriptableObject().GetBuff());
    }


    /// <summary>
    /// Update method that keeps the resources indicator updated. Also makes sure the level up buttons
    /// only appear if the village does have the resources to level u the building.
    /// Makes sure pause menu opens on Esc press.
    /// End of the game, when all buildings are lvl 3 -> shows a window telling the player they have beat the game
    /// </summary>
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
    /// <summary>
    /// Closes the EndGameText window
    /// </summary>
    public void CloseEndGameText()
    {
        endGameTextShown = true;
        endGameText.SetActive(false);
    }
    /// <summary>
    /// Open the Main Building info window
    /// </summary>
    public void OpenMainBuildingWindow()
    {
        mainBuildingWindow.SetActive(true);
        sawmillWindow.SetActive(false);
        marketWindow.SetActive(false);
        wallWindow.SetActive(false);
        mineWindow.SetActive(false);
    }
    /// <summary>
    /// Close the Main Building info window
    /// </summary>
    public void CloseMainBuildingWindow()
    {
        mainBuildingWindow.SetActive(false);
    }
    /// <summary>
    /// Open the Sawmill info window
    /// </summary>
    public void OpenSawmillWindow()
    {
        mainBuildingWindow.SetActive(false);
        sawmillWindow.SetActive(true);
        marketWindow.SetActive(false);
        wallWindow.SetActive(false);
        mineWindow.SetActive(false);
    }
    /// <summary>
    /// Close the Sawmill info window
    /// </summary>
    public void CloseSawmillWindow()
    {
        sawmillWindow.SetActive(false);
    }
    /// <summary>
    /// Open the Market info window
    /// </summary>
    public void OpenMarketWindow()
    {
        mainBuildingWindow.SetActive(false);
        sawmillWindow.SetActive(false);
        marketWindow.SetActive(true);
        wallWindow.SetActive(false);
        mineWindow.SetActive(false);
    }
    /// <summary>
    /// Close the Sawmill info window
    /// </summary>
    public void CloseMarketWindow()
    {
        marketWindow.SetActive(false);
    }
    /// <summary>
    /// Open the Wall info window
    /// </summary>
    public void OpenWallWindow()
    {
        mainBuildingWindow.SetActive(false);
        sawmillWindow.SetActive(false);
        marketWindow.SetActive(false);
        wallWindow.SetActive(true);
        mineWindow.SetActive(false);
    }
    /// <summary>
    /// Close the Sawmill info window
    /// </summary>
    public void CloseWallWindow()
    {
        wallWindow.SetActive(false);
    }
    /// <summary>
    /// Open the Mine info window
    /// </summary>
    public void OpenMineWindow()
    {
        mainBuildingWindow.SetActive(false);
        sawmillWindow.SetActive(false);
        marketWindow.SetActive(false);
        wallWindow.SetActive(false);
        mineWindow.SetActive(true);
    }
    /// <summary>
    /// Close the Sawmill info window
    /// </summary>
    public void CloseMineWindow()
    {
        mineWindow.SetActive(false);
    }
    /// <summary>
    /// Levels up the Main Building
    /// </summary>
    public void LevelUpMainBuilding()
    {
        int levelMain = villageStats.getMainBuildingScriptableObject().GetLevel();
        villageStats.IncrementStructureLevel("mainBuilding", levelMain + 1);
        if(levelMain+1 == 2)
        {
            villageStats.getMainBuildingScriptableObject().setBuff(2);
        }
        else if (levelMain+1 == 3)
        {
            villageStats.getMainBuildingScriptableObject().setBuff(3);
        }
        playerStats.setBonusDamage(villageStats.getMainBuildingScriptableObject().GetBuff());
        CloseMainBuildingWindow();
    }
    /// <summary>
    /// Levels up the Market
    /// </summary>
    public void LevelUpMarket()
    {
        int levelMarket = villageStats.getMarketScriptableObject().GetLevel();
        villageStats.IncrementStructureLevel("market", levelMarket + 1);
        CloseMarketWindow();
    }
    /// <summary>
    /// Levels up the Mine
    /// </summary>
    public void LevelUpMine()
    {
        int levelMine = villageStats.getMineScriptableObject().GetLevel();
        villageStats.IncrementStructureLevel("ironMine", levelMine + 1);
        CloseMineWindow();
    }
    /// <summary>
    /// Levels up the Sawmmill
    /// </summary>
    public void LevelUpSawmill()
    {
        int levelSawmill = villageStats.getSawmillScriptableObject().GetLevel();
        villageStats.IncrementStructureLevel("sawmill", levelSawmill + 1);
        CloseSawmillWindow();
    }
    /// <summary>
    /// Levels up the Wall
    /// </summary>
    public void LevelUpWall()
    {
        int levelWall = villageStats.getWallScriptableObject().GetLevel();
        villageStats.IncrementStructureLevel("wall", levelWall + 1);
        CloseWallWindow();
    }
   /// <summary>
   /// Changes Scene to a raid, depending on the value of the next raid
   /// </summary>
    public void GoToRaid()
    {
        int nextRaid = villageStats.getNextRaid();
        if (nextRaid == 2)
        {
            villageStats.setNextRaid(3);
            _sceneTransition.loadSceneWithTransition(2);
        }
        else
        {
            villageStats.setNextRaid(2);
            _sceneTransition.loadSceneWithTransition(3);
        }

    }
    /// <summary>
    /// Toggle show/hide the Pause Menu
    /// </summary>
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
    /// <summary>
    /// Exits to Main Menu
    /// </summary>
    public void ExitToMenu()
    {
        Time.timeScale = 1.0f;
        _sceneTransition.loadSceneWithTransition(0);
    }
}
