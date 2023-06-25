using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class responsible for the scene loading between scenes
/// </summary>

public class SceneLoaderTransition : MonoBehaviour
{
    [SerializeField] Animator transition;
    [SerializeField] float transitionTime;
    
    /// <summary>
    /// Method that uses the coroutine to load the next scene with the transition
    /// </summary>
    /// <param name="sceneLevel"> Level of the next scene</param>
    public void loadSceneWithTransition(int sceneLevel)
    {
        StartCoroutine(sceneTransition(sceneLevel));
    }

    /// <summary>
    /// Method to change to the next scene after 1 second
    /// </summary>
    /// <param name="sceneLevel">Level of the next scene </param>
    /// <returns>the return is only here to wait a second</returns>
    private IEnumerator sceneTransition(int sceneLevel)
    {
        transition.SetTrigger("In");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneLevel);
    }
}
