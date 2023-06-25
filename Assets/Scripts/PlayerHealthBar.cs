using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class PlayerHealthBar that handles the health bar of the player 
/// </summary>
public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private PlayerStatsScriptableObject _ps;
    private Slider health_bar;

   /// <summary>
   /// Method start that initializes the health bar at the max health of the player 
   /// </summary>
    void Start()
    {
        health_bar = this.gameObject.GetComponent<Slider>();
        health_bar.maxValue = _ps.GetMaxHealth();
        health_bar.value = _ps.GetCurrentHealth();
    }

    /// <summary>
    /// Method update that updates the values on the health bar if the player takes damage or dies 
    /// </summary>
    private void Update()
    {
        health_bar.value = _ps.GetCurrentHealth();
    }
}