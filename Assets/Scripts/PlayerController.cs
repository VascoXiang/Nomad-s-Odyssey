using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class PlayerCOntroller delas with the movement and animations of the player 
/// </summary>

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private bool _jumpCommand;
    private bool _isGrounded;
    private bool _leftCommand;
    private bool _rightCommand;
    //private bool _isWallSliding;
    private float _buttonPressedTime;
    private Animator _animator;

    [SerializeField] private PlayerStatsScriptableObject _ps;
    [SerializeField] private float _runSpeed = 1.0f;
    [SerializeField] private float _jumpHeight = 3.0f;

    [SerializeField] private float _gravityMultiplier = 10.0f;
    [SerializeField] private float _buttonSpacePressedWindow = 2.0f;

    [SerializeField] private float _wallSlidingSpeed = 3.0f;

    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _isGroundedPosition;
    [SerializeField] private Vector2 _isGroundedSize;

    [SerializeField] private LayerMask wallMask;
    [SerializeField] private Transform _isWallPosition;
    [SerializeField] private Vector2 _isWallSize;

    /// <summary>
    /// Method that initializes the rigidbody and the animator associated to the player
    /// </summary>
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = gameObject.GetComponent<Animator>();
    }

    /// <summary>
    /// Method that checks if the movement/jump keys are pressed and applys the animations at every frame of movement
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _jumpCommand = true;
            _buttonPressedTime = 0;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _leftCommand = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _rightCommand = true;
        }
        WallSlided();

        //ANIMATIONS//
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            _animator.SetBool("isMoving", true);
        }
        else
        {
            _animator.SetBool("isMoving", false);
        }

        if (!IsGrounded() && !IsFalling())
        {
            _animator.SetInteger("isJumping", 1);
        }
        else if (IsFalling())
        {
            _animator.SetInteger("isJumping", 2);
        }
        else
        {
            _animator.SetInteger("isJumping", 0);
        }
    }

    /// <summary>
    /// Method that adjust the jump force, the side which the player is facing and the speed movement according to the speed buff
    /// </summary>
    private void FixedUpdate()
    {
        if (_jumpCommand)
        {
            _buttonPressedTime += Time.deltaTime;

            if (_buttonPressedTime > _buttonSpacePressedWindow || Input.GetKeyUp(KeyCode.Space))
            {
                _jumpCommand = false;
            }
            else
            {
                float jumpforce = Mathf.Sqrt(_jumpHeight * (Physics2D.gravity.y * _rb.gravityScale) * -2) * _rb.mass / 1.01f;
                _rb.velocity = new Vector2(_rb.velocity.x, jumpforce);
            }

            if (_rb.velocity.y < 0f || !_jumpCommand)
            {
                _rb.velocity -= new Vector2(0, -Physics2D.gravity.y) * _gravityMultiplier * Time.deltaTime;
            }
        }

        if (_leftCommand)
        {
            _rb.velocity = new Vector2(-_runSpeed + _ps.getBonusSpeed(), _rb.velocity.y);
            _leftCommand = false;
            Quaternion rotation = transform.localRotation;
            rotation.y = 180;
            transform.localRotation = rotation;
        }
        else if (_rightCommand)
        {
            _rb.velocity = new Vector2(_runSpeed + _ps.getBonusSpeed(), _rb.velocity.y);
            _rightCommand = false;
            Quaternion rotation = transform.localRotation;
            rotation.y = 0;
            transform.localRotation = rotation;
        }
    }

    /// <summary>
    /// Method to check if the player is on the floor
    /// </summary>
    /// <returns>true if player is on the floor, false otherwise</returns>
    private bool IsGrounded()
    {
        return Physics2D.OverlapBox(_isGroundedPosition.position, _isGroundedSize, 0, _groundMask);
    }

    /// <summary>
    /// Method to check if the player is falling
    /// </summary>
    /// <returns>true if player is falling, false otherwise</returns>
    private bool IsFalling()
    {
        return _rb.velocity.y < -1f;
    }

    /// <summary>
    /// Method to check if the player is on the wall
    /// </summary>
    /// <returns>true if player is on the wall, false otherwise</returns>
    private bool IsWalled()
    {
        return Physics2D.OverlapBox(_isWallPosition.position, _isWallSize, 0, wallMask);
    }

    /// <summary>
    /// Method to see which side the player is on the wall
    /// </summary>
    private void WallSlided()
    {
        if (IsWalled() && !IsGrounded() && (_leftCommand || _rightCommand))
        {
            //_isWallSliding = true;
            _rb.velocity = new Vector2(_rb.velocity.x, Mathf.Clamp(_rb.velocity.y, -_wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            //_isWallSliding = false;
        }
    }
}
