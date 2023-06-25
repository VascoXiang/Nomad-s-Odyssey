using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class PlayerStatsScriptableObject is the class that stores some important stuff
/// about our main character like maxHealth, currentHealth, current iron and wood in possession
/// and what is the current bonus multiplier for armor/damage/speed
/// </summary>
[CreateAssetMenu(fileName = "PlayerStats ScriptableObject", menuName = "PlayerStats ScriptableObject")]
public class PlayerStatsScriptableObject : ScriptableObject
{
    [SerializeField] VillageStatsScriptableObject villageStats;
    [SerializeField] private int MAX_HEALTH = 3;
    private int maxHealth = 3;
    private int currentHealth = 3;
    private int wood = 0;
    private int iron = 0;
    private int bonusArmor = 1, bonusDamage = 1,bonusSpeed = 1;

    /// <summary>
    /// Defines the start of game stats for our main character (resets all the stats)
    /// </summary>
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

    /// <summary>
    /// Resets the stats that are specific to each raid attempt (like current resources
    /// in possession and health)
    /// </summary>
    public void DefaultLevelStart()
    {
        maxHealth = MAX_HEALTH;
        currentHealth = MAX_HEALTH;
        iron = 0;
        wood = 0;
    }

    /// <summary>
    /// Sets the bonusArmor multiplier value
    /// </summary>
    /// <param name="bonusArmor"> Armor multiplier value</param>
    public void setBonusArmor(int bonusArmor)
    {
        this.bonusArmor =  bonusArmor;
    }

    /// <summary>
    /// Sets the bonusSpeed additive value
    /// </summary>
    /// <param name="bonusSpeed">Speed additive value</param>
    public void setBonusSpeed(int bonusSpeed)
    {
        this.bonusSpeed = bonusSpeed;
    }

    /// <summary>
    /// Sets the bonusDamage multiplier value
    /// </summary>
    /// <param name="bonusDamage"> Damage multiplier value</param>
    public void setBonusDamage(int bonusDamage)
    {
        this.bonusDamage = bonusDamage;
    }

    /// <summary>
    /// Getter of Armor multiplier
    /// </summary>
    /// <returns>Armor multiplier</returns>
    public int getBonusArmor()
    {
        return bonusArmor;
    }
    /// <summary>
    /// Getter of Speed additive value
    /// </summary>
    /// <returns>Speed additive value</returns>
    public int getBonusSpeed()
    {
        return bonusSpeed;
    }
    /// <summary>
    /// Getter of Damage multiplier
    /// </summary>
    /// <returns>Damage multiplier</returns>
    public int getBonusDamage()
    {
        return bonusDamage;
    }


    /// <summary>
    /// Deals damage to character's current health. If character dies, also resets current
    /// resources
    /// </summary>
    /// <param name="damage">Damage to apply to main character</param>
    public void GetHit(int damage)
    {
        currentHealth -= damage / bonusArmor;

        if(currentHealth <= 0)
        {
            wood = 0;
            iron = 0;
        }
    }

    /// <summary>
    /// Adds iron to the main character
    /// </summary>
    /// <param name="iron">Number of Iron resources</param>
    public void AddIron(int iron)
    {
        this.iron += iron;
    }
    /// <summary>
    /// Removes iron from the main character
    /// </summary>
    /// <param name="iron">Number of Iron resources</param>
    public void RemoveIron(int iron)
    {
        this.iron -= iron;
    }

    /// <summary>
    /// Returns value of Iron in character
    /// </summary>
    /// <returns>number of Iron resources</returns>
    public int GetIronResources()
    {
        return iron;
    }
    /// <summary>
    /// Adds wood to the main character
    /// </summary>
    /// <param name="wood">Number of Wood Resources</param>
    public void AddWoodResources(int wood)
    {
        this.wood += wood;
    }
    /// <summary>
    /// Removes wood from the main character
    /// </summary>
    /// <param name="wood">Number of wood resources</param>
    public void RemoveWoodResources(int wood)
    {
        this.wood -= wood;
    }
    /// <summary>
    /// Returns the number of wood rin character
    /// </summary>
    /// <returns>Number of Wood Resources</returns>
    public int GetWoodResources()
    {
        return wood;
    }
    /// <summary>
    /// Returns character's current health
    /// </summary>
    /// <returns>Character's current health</returns>
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
    /// <summary>
    /// Returns character's max health
    /// </summary>
    /// <returns>Character's max health</returns>
    public int GetMaxHealth()
    {
        return maxHealth;
    }


}
