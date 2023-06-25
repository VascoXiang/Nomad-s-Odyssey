using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class EnemyScriptableObject that has the life of the enemy 
/// </summary>
/// 
[CreateAssetMenu(fileName = "Enemy ScriptableObject", menuName = "Enemy ScriptableObject")]

public class EnemyScriptableObject : ScriptableObject
{
    [SerializeField] private float maxHealth = 3;

    /// <summary>
    /// Getter of the enemy max health 
    /// </summary>
    public float MaxHealth
    {
        get => maxHealth;
    }
}
