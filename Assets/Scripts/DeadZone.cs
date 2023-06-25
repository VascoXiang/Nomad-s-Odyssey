using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class DeadZone it´s the class that deals with the death of the player when it falls 
/// </summary>
public class DeadZone : MonoBehaviour
{
    [SerializeField] private PlayerStatsScriptableObject _ps;

    /// <summary>
    ///  Method that checks if the player collided with the dead zone game object and hits player
    ///  with maxValue so the player dies
    /// </summary>
    /// <param name="collision">Collider with the game object </param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            _ps.GetHit(int.MaxValue);
        }
    }
}
