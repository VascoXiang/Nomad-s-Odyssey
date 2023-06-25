using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class Collectable is responsible for all the interactions with the collectibles in the scene
/// </summary>
public class Collectable : MonoBehaviour
{
    [SerializeField] private PlayerStatsScriptableObject _ps;
    [SerializeField] private TypeItem _type;
    [SerializeField] private int _amount;
    [SerializeField] private GameObject sound;

    /// <summary>
    /// Method that checks if it's a player if so it gives points and plays the pick up sound effect after that it destroys itself 
    /// </summary>
    /// <param name="collision">Collider with the game object</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            givePoints();
            PlaySound();
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Method responsible for playing the sound when the player pick's up the collectible
    /// </summary>
    private void PlaySound()
    {
        Instantiate(sound,transform.position, Quaternion.identity);
    }

    /// <summary>
    /// Method that gives points to the player depending if it's iron, wood or the chest 
    /// </summary>
    public void givePoints()
    {
        if(_type == TypeItem.Iron)
        {
            _ps.AddIron(_amount);
        }
        if (_type == TypeItem.Wood)
        {
            _ps.AddWoodResources(_amount);
        }
        if (_type == TypeItem.Chest)
        {
            _ps.AddIron(_amount);
            _ps.AddWoodResources(_amount);
        }
    }

    /// <summary>
    /// Three types of collectibles each one gives different amounts to the player 
    /// </summary>
    public enum TypeItem
    {
        Iron,
        Wood,
        Chest
    }
}
