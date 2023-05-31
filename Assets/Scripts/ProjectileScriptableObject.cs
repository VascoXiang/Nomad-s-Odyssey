using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileStats ScriptableObject", menuName = "ProjectileStats ScriptableObject")]
public class ProjectileScriptableObject : ScriptableObject
{
    [SerializeField] private int damage;
    [SerializeField] private int bulletSpeed;
    public int getDamage()
    {
        return damage;
    }

    public int getBulletSpeed()
    {
        return bulletSpeed;
    }
}
