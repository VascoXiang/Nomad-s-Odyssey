using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private PlayerStatsScriptableObject playerStats;
   // [SerializeField] private TMP_Text text_message_highest_score;
    [SerializeField] private GameObject infoBackground;
    private bool infoShown;

    public void Start()
    {
       // int highscore = PlayerPrefs.GetInt("HighScore",0);
       // playerStats.setHighScore(highscore);
       // highScore();
        infoShown = false;
        
    }

    public void playGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }

    public void quitGame()
    {
        Application.Quit();
    }

    /*public void highScore()
    {
        text_message_highest_score.text = "HighScore: " + playerStats.getHighScore() + " points";
    }*/

    public void showInfo()
    {
        if (infoShown)
        {
            infoBackground.SetActive(false);
            infoShown = false;
        }
        else { 
            infoBackground.SetActive(true);
            infoShown= true;
        }
    }
}
