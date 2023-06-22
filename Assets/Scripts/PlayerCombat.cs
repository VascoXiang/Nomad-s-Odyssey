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

    private void Start()
    {
        _ps.DefaultLevelStart();
        _animator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        // Ctrl was pressed, launch a projectile
        if (Input.GetButtonDown("Fire1") && _currentAttackCooldown <= 0)
        {
            _currentAttackCooldown = _attackCooldown;
            _animator.SetTrigger("isAttacking");
            StartCoroutine(instantiateArrow());
        }
        
        if(_currentAttackCooldown > 0)
        {
            _currentAttackCooldown -= Time.deltaTime;
        }
    }

    IEnumerator instantiateArrow()
    {
        yield return new WaitForSeconds(0.4f);
        Instantiate(projectile, startPosition.position, transform.rotation);
    }

}
