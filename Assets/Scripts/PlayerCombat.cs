using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    // Assign a Rigidbody component in the inspector to instantiate
    [SerializeField]private GameObject projectile;
    [SerializeField]private Transform startPosition;
    void Update()
    {
        // Ctrl was pressed, launch a projectile
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(projectile, startPosition.position, transform.rotation);
        }
    }

}
