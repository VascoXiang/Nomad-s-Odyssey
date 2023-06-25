using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// class StartMenuScript is the class that deals with all the function and buttons
/// on the starting menu screen
/// </summary>
public class StartMenuScript : MonoBehaviour
{
    [SerializeField] private VillageStatsScriptableObject _village;
    [SerializeField] private SceneLoaderTransition _sceneTransition;
    [SerializeField] private GameObject _infoText;
    private bool infoEnabled;

/// <summary>
/// Makes sure the info window is not enabled
/// </summary>
    private void Start()
    {
        infoEnabled = false;
    }


    /// <summary>
    /// Starts the game making sure all the stats are reset and loads the village scene
    /// </summary>
    public void StartGame()
    {
        _village.EarlyGameStart();
        _sceneTransition.loadSceneWithTransition(1);
    }

    /// <summary>
    /// Exits the application.
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Depending on the bool infoEnabled, it allows the info window to be displayed or hidden
    /// </summary>
    public void ShowOrHideInfo()
    {
        if (infoEnabled)
        {
            _infoText.SetActive(false);
            infoEnabled = false;
        }
        else
        {
            _infoText.SetActive(true);
            infoEnabled = true;
        }
    }
}
