using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderTransition : MonoBehaviour
{
    [SerializeField] Animator transition;
    [SerializeField] float transitionTime;

    public void loadSceneWithTransition(int sceneLevel)
    {
        StartCoroutine(sceneTransition(sceneLevel));
    }

    private IEnumerator sceneTransition(int sceneLevel)
    {
        transition.SetTrigger("In");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneLevel);
    }
}
