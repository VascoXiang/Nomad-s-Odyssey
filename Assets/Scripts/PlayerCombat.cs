using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    // Assign a Rigidbody component in the inspector to instantiate
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform startPosition;
    [SerializeField] private PlayerStatsScriptableObject _ps;
    private float _attackCooldown = 0.5f;
    private float _currentAttackCooldown = 0;
    private Animator _animator;
    private PlayerController _playerController;
    private bool _isAttacking = false;

    private void Start()
    {
        _ps.DefaultLevelStart();
        _playerController = gameObject.GetComponent<PlayerController>();
        _animator = gameObject.GetComponent<Animator>();
    }
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

    public void TakeDamage(int damage)
    {
        _ps.GetHit(damage);
    }

    IEnumerator instantiateArrow()
    {
        yield return new WaitForSeconds(0.3f);
        Instantiate(projectile, startPosition.position, transform.rotation);
        _isAttacking = false;
        _playerController.enabled = true;
    }

}
