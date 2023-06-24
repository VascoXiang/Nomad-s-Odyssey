using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private PlayerStatsScriptableObject _ps;
    [SerializeField] private TypeItem _type;
    [SerializeField] private int _amount;
    [SerializeField] private GameObject sound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            givePoints();
            PlaySound();
            Destroy(this.gameObject);
        }
    }

    private void PlaySound()
    {
        Instantiate(sound,transform.position, Quaternion.identity);
    }

    public void givePoints()
    {
        if(_type == TypeItem.Iron)
        {
            _ps.AddIron(_amount);
        }
        if (_type == TypeItem.Wood)
        {
            _ps.AddWoodResources(_amount);
        }
        if (_type == TypeItem.Chest)
        {
            _ps.AddIron(_amount);
            _ps.AddWoodResources(_amount);
        }
    }

    public enum TypeItem
    {
        Iron,
        Wood,
        Chest
    }
}
