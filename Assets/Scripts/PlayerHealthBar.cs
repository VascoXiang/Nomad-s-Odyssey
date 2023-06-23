using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private PlayerStatsScriptableObject _ps;
    private Slider health_bar;
    // Start is called before the first frame update
    void Start()
    {
        health_bar = this.gameObject.GetComponent<Slider>();
        health_bar.maxValue = _ps.GetMaxHealth();
        health_bar.value = _ps.GetCurrentHealth();
    }

    private void Update()
    {
        health_bar.value = _ps.GetCurrentHealth();
    }
}