using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private PlayerStatsScriptableObject _ps;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            _ps.GetHit(int.MaxValue);
            _ps.RemoveIron(_ps.GetIronResources());
            _ps.RemoveWoodResources(_ps.GetWoodResources());
        }
    }
}
