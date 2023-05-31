using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileStats ScriptableObject", menuName = "ProjectileStats ScriptableObject")]
public class ProjectileScriptableObject : ScriptableObject
{
    [SerializeField] private int damage;

    public int getDamage()
    {
        return damage;
    }
}
