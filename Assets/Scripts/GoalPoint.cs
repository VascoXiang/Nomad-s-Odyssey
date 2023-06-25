using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class GoalPoint it´s the class that deals with the finish line in the raids
/// </summary>
public class GoalPoint : MonoBehaviour
{
    [SerializeField] private PlayerStatsScriptableObject _ps;

    /// <summary>
    ///  Method that checks if the player collided with the dead zone game object
    /// </summary>
    /// <param name="collision">Collider with the game object </param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _ps.AddIron(20);
            _ps.AddWoodResources(20);
            GameObject.Find("Canvas").GetComponent<PanelManager>().EndGame();
        }
    }
}
