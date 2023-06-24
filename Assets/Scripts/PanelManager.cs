using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    bool gameEnded = false;
    bool gamePaused = false;

    [SerializeField] private GameObject winOrLoseUI;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private TMP_Text text_wood_points;
    [SerializeField] private TMP_Text text_iron_points;
    [SerializeField] private PlayerStatsScriptableObject _ps;
    [SerializeField] private GameObject _player;

    // Update is called once per frame
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
    }
    public void ContinueGame()
    {
        pauseUI.SetActive(false);
        gamePaused = false;
        _player.GetComponent<PlayerController>().enabled = true;
        _player.GetComponent<PlayerCombat>().enabled = true;
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        pauseUI.SetActive(true);
        gamePaused = true;
        _player.GetComponent<PlayerController>().enabled = false;
        _player.GetComponent<PlayerCombat>().enabled = false;
        Time.timeScale = 0;
    }

    public void VillageScene()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

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
