using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class EnemyScript : MonoBehaviour
{
    #region ATRIBUTES

    private Rigidbody2D _rb;
    private Animator _animator;
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _checkpoints;
    private int _nextCheckpoint = 0;


    #region ENEMY HEALTH
    [SerializeField] private EnemyScriptableObject _enemy;
    private float _enemyMaxHealth;
    private float _enemyCurrentHealth;
    [SerializeField] private Slider enemy_health_ui;
    #endregion

    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _startPosition;
    private bool isAttacking = false;

    #region ENEMY FIELDVIEW
    [SerializeField] private float _radius;
    [Range(0,360)]
    [SerializeField] private float _angle;

    private GameObject _player;
    [SerializeField] private LayerMask _targetMask;
    [SerializeField] private LayerMask _obstructionMask;

    private bool _canSeePlayer;
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

        _rb = gameObject.GetComponent<Rigidbody2D>();
        _animator = gameObject.GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());

        //enemy_name_ui.text = enemy_name;
    }

    private void Update()
    {
        if (_canSeePlayer)
        {
            _rb.velocity = Vector2.zero;
            _animator.SetBool("isMoving", false);
            if (!isAttacking)
            {
                _animator.SetTrigger("isAttacking");
                isAttacking = true;
                StartCoroutine(Attack());
            }
        }
        else
        {
            movement();
            _animator.SetBool("isMoving", true);
            if(_nextCheckpoint == 0)
            {
                if(Vector2.Distance(transform.position, _checkpoints[0].position) < .2f)
                {
                    gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                    _nextCheckpoint = 1;
                }
            }
            if (_nextCheckpoint == 1)
            {
                if (Vector2.Distance(transform.position, _checkpoints[1].position) < .2f)
                {
                    gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                    _nextCheckpoint = 0;
                }
            }
        }
    }

    private void movement()
    {
        if(gameObject.transform.rotation.eulerAngles.y == 180)
        {
            _rb.velocity = new Vector2(-_speed, 0);
        }
        else if (gameObject.transform.rotation.eulerAngles.y == 0)
        {
            _rb.velocity = new Vector2(_speed, 0);
        }
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

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(_projectile, _startPosition.position, transform.rotation);

        yield return new WaitForSeconds(3f);
        isAttacking = false;
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
