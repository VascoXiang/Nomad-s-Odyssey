using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private bool _jumpCommand;
    private bool _isWallSliding;
    [SerializeField] private float _jumpPower = 3.0f;
    private bool _leftCommand;
    private bool _rightCommand;
    [SerializeField] private float _runSpeed = 1.0f;
    [SerializeField] private float _wallSlidingSpeed = 3.0f;

    [SerializeField] private Transform _isGroundedPosition;
    [SerializeField] private Vector2 _isGroundedSize;
    [SerializeField] private LayerMask groundMask;

    [SerializeField] private Transform _isWallPosition;
    [SerializeField] private Vector2 _isWallSize;
    [SerializeField] private LayerMask wallMask;

    // Start is called before the first frame update
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
             _jumpCommand = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _leftCommand = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _rightCommand = true;
        }

       wallSlided();
    }

    private void FixedUpdate()
    {
        if (_jumpCommand)
        {
            _rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
            _jumpCommand = false;
        }

        if (_leftCommand)
        {
            _rb.velocity = new Vector2(-_runSpeed, _rb.velocity.y);
            _leftCommand = false;
            Quaternion rotation = transform.localRotation;
            rotation.y = 180;
            transform.localRotation = rotation;
        }
        else if (_rightCommand)
        {
            _rb.velocity = new Vector2(_runSpeed, _rb.velocity.y);
            _rightCommand = false;
            Quaternion rotation = transform.localRotation;
            rotation.y = 0;
            transform.localRotation = rotation;
        }
    }

    private bool isGrounded()
    {
       return Physics2D.OverlapBox(_isGroundedPosition.position, _isGroundedSize,0,groundMask);
    }

    private bool isWalled()
    {
        return Physics2D.OverlapBox(_isWallPosition.position, _isWallSize, 0, wallMask);
    }

    private void wallSlided()
    {
        if(isWalled() && !isGrounded() && (_leftCommand || _rightCommand))
        {
            _isWallSliding = true;
            _rb.velocity = new Vector2(_rb.velocity.x, Mathf.Clamp(_rb.velocity.y, -_wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            _isWallSliding = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(_isGroundedPosition.position, _isGroundedSize);

        Gizmos.color = Color.blue;
        Gizmos.DrawCube(_isWallPosition.position, _isWallSize);
    }
}
