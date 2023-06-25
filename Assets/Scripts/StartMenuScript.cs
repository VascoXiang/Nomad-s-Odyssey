using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour
{
    [SerializeField] private VillageStatsScriptableObject _village;
    [SerializeField] private SceneLoaderTransition _sceneTransition;
    [SerializeField] private GameObject _infoText;
    private bool infoEnabled;

    private void Start()
    {
        infoEnabled = false;
    }

    public void StartGame()
    {
        _village.EarlyGameStart();
        _sceneTransition.loadSceneWithTransition(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

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
            infoEnabled=true;
        }
    }
}
