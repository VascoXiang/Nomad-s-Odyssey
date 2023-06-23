using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats ScriptableObject", menuName = "PlayerStats ScriptableObject")]
public class PlayerStatsScriptableObject : ScriptableObject
{
    [SerializeField] private int MAX_HEALTH = 3;
    private int maxHealth = 3;
    private int currentHealth = 3;
    private int wood = 0;
    private int iron = 0;
    private Boolean bonusArmor, bonusDamage, bonusSpeed;

    // Start is called before the first frame update
    public void EarlyGameStart()
    {
        maxHealth = MAX_HEALTH;
        currentHealth = MAX_HEALTH;
        iron = 0;
        wood = 0;
        bonusArmor = false;
        bonusDamage = false;
        bonusSpeed = false;
    }


    public void DefaultLevelStart()
    {
        maxHealth = MAX_HEALTH;
        currentHealth = MAX_HEALTH;
        iron = 0;
        wood = 0;
    }



    public void SetBonusActive(String bonus)
    {
        switch (bonus)
        {
            case "armor":
                this.bonusArmor = true; break;
            case "damage":
                this.bonusDamage = true; break;
            case "speed":
                this.bonusSpeed = true; break;
        }
    }

    public void GetHit(int damage)
    {
        if (bonusArmor) currentHealth -= damage / 2;

        else currentHealth -= damage;

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
