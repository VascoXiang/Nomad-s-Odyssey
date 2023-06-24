using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats ScriptableObject", menuName = "PlayerStats ScriptableObject")]
public class PlayerStatsScriptableObject : ScriptableObject
{
    [SerializeField] VillageStatsScriptableObject villageStats;
    [SerializeField] private int MAX_HEALTH = 3;
    private int maxHealth = 3;
    private int currentHealth = 3;
    private int wood = 0;
    private int iron = 0;
    private int bonusArmor, bonusDamage,bonusSpeed;

    // Start is called before the first frame update
    public void EarlyGameStart()
    {
        maxHealth = MAX_HEALTH;
        currentHealth = MAX_HEALTH;
        iron = 0;
        wood = 0;
        bonusArmor = 1;
        bonusDamage = 1;
        bonusSpeed = 1;
    }


    public void DefaultLevelStart()
    {
        maxHealth = MAX_HEALTH;
        currentHealth = MAX_HEALTH;
        iron = 0;
        wood = 0;
    }

    public void setBonusArmor(int bonusArmor)
    {
        this.bonusArmor =  bonusArmor;
    }

    public void setBonusSpeed(int bonusSpeed)
    {
        this.bonusSpeed = bonusSpeed;
    }

    public void setBonusDamage(int bonusDamage)
    {
        this.bonusDamage = bonusDamage;
    }



    public void GetHit(int damage)
    {
        currentHealth -= damage / bonusArmor;

        if(currentHealth <= 0)
        {
            wood = 0;
            iron = 0;
        }
    }

    public void AddIron(int iron)
    {
        this.iron += iron;
    }

    public void RemoveIron(int iron)
    {
        this.iron -= iron;
    }

    public int GetIronResources()
    {
        return iron;
    }

    public void AddWoodResources(int wood)
    {
        this.wood += wood;
    }

    public void RemoveWoodResources(int wood)
    {
        this.wood -= wood;
    }

    public int GetWoodResources()
    {
        return wood;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }


}
