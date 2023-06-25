using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class ProjectileScriptableObject is responsible for the damage and speed of the players projectile
/// </summary>

[CreateAssetMenu(fileName = "ProjectileStats ScriptableObject", menuName = "ProjectileStats ScriptableObject")]
public class ProjectileScriptableObject : ScriptableObject
{
    [SerializeField] private int damage;
    [SerializeField] private int bulletSpeed;
    /// <summary>
    /// Getter of the damage
    /// </summary>
    /// <returns>damage</returns>
    public int getDamage()
    {
        return damage;
    }
    /// <summary>
    /// Getter of the speed of the bullet
    /// </summary>
    /// <returns>bulletSpeed</returns>
    public int getBulletSpeed()
    {
        return bulletSpeed;
    }
}
