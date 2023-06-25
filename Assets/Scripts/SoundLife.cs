using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class Sound Life that is responsible for the sound when picking up the collectibles
/// </summary>
public class SoundLife : MonoBehaviour
{
    /// <summary>
    /// Method Awake that plays the sound of picking up a collectible 
    /// </summary>
    private void Awake()
    {
        Destroy(gameObject, gameObject.GetComponent<AudioSource>().clip.length);
    }
}
