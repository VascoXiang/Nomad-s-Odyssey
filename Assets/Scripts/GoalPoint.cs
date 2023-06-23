using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPoint : MonoBehaviour
{
    [SerializeField] private PlayerStatsScriptableObject _ps;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _ps.AddIron(200);
            _ps.AddWoodResources(200);
            GameObject.Find("Canvas").GetComponent<PanelManager>().endGame();
        }
    }
}
