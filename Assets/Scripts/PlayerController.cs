using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private bool _jumpCommand;
    private bool _isGrounded;
    private bool _leftCommand;
    private bool _rightCommand;
    //private bool _isWallSliding;
    private float _buttonPressedTime;

    [SerializeField] private float _runSpeed = 1.0f;
    [SerializeField] private float _jumpHeight = 3.0f;

    [SerializeField] private float _gravityScale = 10.0f;
    [SerializeField] private float _gravityFallingScale = 50.0f;
    [SerializeField] private float _buttonSpacePressedWindow = 2.0f;

    [SerializeField] private float _wallSlidingSpeed = 3.0f;
    
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform _isGroundedPosition;
    [SerializeField] private Vector2 _isGroundedSize;
    
    [SerializeField] private LayerMask wallMask;
    [SerializeField] private Transform _isWallPosition;
    [SerializeField] private Vector2 _isWallSize;
    
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
            _rb.gravityScale = _gravityScale;
            
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

        wallSlided();
        _isGrounded = isGrounded();
    }

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
                float jumpforce = Mathf.Sqrt(_jumpHeight * (Physics2D.gravity.y * _rb.gravityScale) * -2) * _rb.mass;
                _rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            }

            if (_rb.velocity.y < 0 || !_jumpCommand)
            {
                _rb.gravityScale = _gravityFallingScale;
            }
        }

        if (!isGrounded())
        {
            if (_leftCommand)
            {
                _rb.AddForce(Vector2.left * 10, ForceMode2D.Impulse);
                _leftCommand = false;
                Quaternion rotation = transform.localRotation;
                rotation.y = 180;
                transform.localRotation = rotation;
            }
            else if (_rightCommand)
            {
                _rb.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
                _rightCommand = false;
                Quaternion rotation = transform.localRotation;
                rotation.y = 0;
                transform.localRotation = rotation;
            }
        }
        else
        {
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
            //_isWallSliding = true;
            _rb.velocity = new Vector2(_rb.velocity.x, Mathf.Clamp(_rb.velocity.y, -_wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            //_isWallSliding = false;
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
