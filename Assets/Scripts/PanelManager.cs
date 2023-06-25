using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Class PanelManager that manages the pause and end game menu on each 2D raid
/// </summary>
public class PanelManager : MonoBehaviour
{
    bool gameEnded = false;
    bool gamePaused = false;

    [SerializeField] private GameObject winOrLoseUI;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private TMP_Text text_wood_points;
    [SerializeField] private TMP_Text text_iron_points;
    [SerializeField] private TMP_Text number_wood_points;
    [SerializeField] private TMP_Text number_iron_points;
    [SerializeField] private PlayerStatsScriptableObject _ps;
    [SerializeField] private SceneLoaderTransition _sceneTransition;
    [SerializeField] private GameObject _player;

    /// <summary>
    /// Checks if the player is dead/the raid has ended
    /// Makes sure Pause menu is displayed on Esc press
    /// Updates the wood and iron indicators
    /// </summary>
    void Update()
    {
        if (!gameEnded && _ps.GetCurrentHealth() <= 0)
        {
            EndGame();
        }

        if (!gameEnded && Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gamePaused)
                PauseGame();
            else
                ContinueGame();
        }
        number_wood_points.text = _ps.GetWoodResources() + "";
        number_iron_points.text = _ps.GetIronResources() + "";
    }
    /// <summary>
    /// Enables all the player controllers and unfreezes time to continue the game
    /// Also Hides the pause menu window
    /// </summary>
    public void ContinueGame()
    {
        pauseUI.SetActive(false);
        gamePaused = false;
        _player.GetComponent<PlayerController>().enabled = true;
        _player.GetComponent<PlayerCombat>().enabled = true;
        Time.timeScale = 1;
    }
    /// <summary>
    /// Disables all the player controllers and freezes time to pause the game
    /// Also Displays the pause menu window
    /// </summary>
    public void PauseGame()
    {
        pauseUI.SetActive(true);
        gamePaused = true;
        _player.GetComponent<PlayerController>().enabled = false;
        _player.GetComponent<PlayerCombat>().enabled = false;
        Time.timeScale = 0;
    }
    /// <summary>
    /// Exits the raid and loads the 3D village Scene
    /// </summary>
    public void VillageScene()
    {
        if (!gameEnded)
        {
            _ps.RemoveIron(_ps.GetIronResources());
            _ps.RemoveWoodResources(_ps.GetWoodResources());
        }
        _sceneTransition.loadSceneWithTransition(1);
        Time.timeScale = 1;
    }
    /// <summary>
    /// Ends the 2D raid, disables the player controllers, freezes time
    /// and displays the resources gathered
    /// </summary>
    public void EndGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            winOrLoseUI.SetActive(true);
            text_wood_points.text = "wood: " + _ps.GetWoodResources();
            text_iron_points.text = "iron: " + _ps.GetIronResources();
            _player.GetComponent<PlayerController>().enabled = false;
            _player.GetComponent<PlayerCombat>().enabled = false;
            Time.timeScale = 0;
        }
    }
}
