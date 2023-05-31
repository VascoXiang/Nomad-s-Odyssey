using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy ScriptableObject", menuName = "Enemy ScriptableObject")]
public class EnemyScriptableObject : ScriptableObject
{
    [SerializeField] private int MAX_HEALTH = 3;
    private int maxHealth = 3;
    private int currentHealth = 3;
    [SerializeField] private GameObject projectile;

    // Start is called before the first frame update
    public void EarlyGameStart()
    {
        maxHealth = MAX_HEALTH;
        currentHealth = MAX_HEALTH;
    }


    public void DefaultLevelStart()
    {
        maxHealth = MAX_HEALTH;
        currentHealth = MAX_HEALTH;
    }

    public void GetHit(int damage)
    {
        currentHealth -= damage;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public void SetCurrentHealth(int currentHealth)
    {
       this.currentHealth = currentHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }


}
