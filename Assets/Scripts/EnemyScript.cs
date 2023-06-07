using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class EnemyScript : MonoBehaviour
{
    #region ATRIBUTES
    
    #region ENEMY HEALTH
    [SerializeField] private EnemyScriptableObject _enemy;
    private float _enemyMaxHealth;
    private float _enemyCurrentHealth;
    [SerializeField] private Slider enemy_health_ui;
    #endregion

    #region ENEMY FIELDVIEW
    [SerializeField] private float _radius;
    [Range(0,360)]
    [SerializeField] private float _angle;

    private GameObject _player;
    [SerializeField] private LayerMask _targetMask;
    [SerializeField] private LayerMask _obstructionMask;

    [SerializeField] private bool _canSeePlayer;
    #endregion


    //[SerializeField]private TMP_Text enemy_name_ui;
    //[SerializeField] private string enemy_name = "Enemy";

    #endregion

    public void Start()
    {
        _enemyMaxHealth = _enemy.MaxHealth;
        _enemyCurrentHealth = _enemy.MaxHealth;
        enemy_health_ui.maxValue = _enemyMaxHealth;
        enemy_health_ui.value = _enemyCurrentHealth;

        _player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());

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

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider2D[] rangeChecks = Physics2D.OverlapCircleAll(transform.position, _radius, _targetMask);

        if (rangeChecks.Length > 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector2.Angle(transform.right, directionToTarget) < _angle / 2)
            {
                float distanceToTarget = Vector2.Distance(transform.position, target.position);
                if(!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, _obstructionMask))
                {
                    _canSeePlayer = true;
                }
                else _canSeePlayer = false;

            }
            else _canSeePlayer = false;
        }
        else if (_canSeePlayer)
        {
            _canSeePlayer = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);

        Vector3 viewAngle1 = DirectionFromAngle(-transform.eulerAngles.y, -_angle / 2);
        Vector3 viewAngle2 = DirectionFromAngle(-transform.eulerAngles.y, _angle / 2);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + viewAngle1 * _radius);
        Gizmos.DrawLine(transform.position, transform.position + viewAngle2 * _radius);
    }

    private Vector2 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY + 90;

        return new Vector2(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
