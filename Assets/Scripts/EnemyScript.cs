using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float _enemyHealth;
    private float _enemyMaxHealth;
    private float _enemyCurrentHealth;
    [SerializeField] private Slider enemy_health_ui;
    //[SerializeField]private TMP_Text enemy_name_ui;
    [SerializeField] private string enemy_name = "Enemy";
    public void Start()
    {
        _enemyMaxHealth = _enemyHealth;
        _enemyCurrentHealth = _enemyHealth;
        enemy_health_ui.maxValue = _enemyMaxHealth;
        enemy_health_ui.value = _enemyCurrentHealth;
        //enemy_name_ui.text = enemy_name;
    }
    public void TakeDamage(int damage)
    {
        _enemyCurrentHealth -= damage;
        enemy_health_ui.value = _enemyCurrentHealth;

        if (_enemyCurrentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
