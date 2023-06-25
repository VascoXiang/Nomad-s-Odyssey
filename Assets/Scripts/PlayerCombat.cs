using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class PlayerCombat provides the control for the player shooting arrows
/// Also allows the player to take damage
/// </summary>
public class PlayerCombat : MonoBehaviour
{
    
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform startPosition;
    [SerializeField] private PlayerStatsScriptableObject _ps;
    private float _attackCooldown = 0.5f;
    private float _currentAttackCooldown = 0;
    private Animator _animator;
    private PlayerController _playerController;
    private bool _isAttacking = false;

    /// <summary>
    /// Start ensures the default level start values are set and initializes some variables
    /// </summary>
    private void Start()
    {
        _ps.DefaultLevelStart();
        _playerController = gameObject.GetComponent<PlayerController>();
        _animator = gameObject.GetComponent<Animator>();
    }
    /// <summary>
    /// Checks if player has pressed Mouse1 to shoot arrows and handles the animations and shooting mechanics
    /// </summary>
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && _currentAttackCooldown <= 0)
        {
            _currentAttackCooldown = _attackCooldown;
            _animator.SetTrigger("isAttacking");
            _isAttacking = true;
            StartCoroutine(instantiateArrow());
        }

        if (_isAttacking)
        {
            _playerController.enabled = false;
        }

        if(_currentAttackCooldown > 0)
        {
            _currentAttackCooldown -= Time.deltaTime;
        }
    }
    /// <summary>
    /// Take Damage
    /// </summary>
    /// <param name="damage">value of damage to be taken</param>
    public void TakeDamage(int damage)
    {
        _ps.GetHit(damage);
    }
    /// <summary>
    /// Instantiate an arrow from the character's bow
    /// </summary>
    /// <returns>Coroutine</returns>
    IEnumerator instantiateArrow()
    {
        yield return new WaitForSeconds(0.3f);
        Instantiate(projectile, startPosition.position, transform.rotation);
        _isAttacking = false;
        _playerController.enabled = true;
    }

}
