using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy ScriptableObject", menuName = "Enemy ScriptableObject")]
public class EnemyScriptableObject : ScriptableObject
{
    [SerializeField] private float maxHealth = 3;

    public float MaxHealth
    {
        get => maxHealth;
    }
}
