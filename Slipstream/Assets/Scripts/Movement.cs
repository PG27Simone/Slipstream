using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    //input
    private Vector2 _moveDirection;

    //move
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;
    private float _ySpeed;

    //jump
    private CharacterController _charCont;
    public bool isGrounded;

    public InputActionReference move;
    public InputActionReference jump;

    private void Start()
    {
        _charCont = GetComponent<CharacterController>();
    }

    void Update()
    {

        //input
        _moveDirection = move.action.ReadValue<Vector2>();


        //movement
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        Vector3 playerMove = new Vector3(horizontalMove, 0, verticalMove);
        playerMove.Normalize();

        transform.Translate(playerMove * Time.deltaTime * _speed, Space.World);

        //jump
        
        _ySpeed += Physics.gravity.y * Time.deltaTime;
        if (Input.GetButtonDown("Jump")) 
        {
            _ySpeed = -0.5f;
            isGrounded = false;
        }

        float magnitude = playerMove.magnitude;

        Vector3 velocity = playerMove * magnitude;
        velocity.y = _ySpeed;
        transform.Translate(velocity * Time.deltaTime);

        _charCont.SimpleMove(playerMove * magnitude * _speed);
        _charCont.Move(velocity * Time.deltaTime);

        if(_charCont.isGrounded)
        {
            _ySpeed = -0.5f;
            isGrounded = true;
            if (Input.GetButtonDown("Jump")) 
            {
                _ySpeed = _jumpSpeed;
                isGrounded = false;
            }
        }
    }

    private void OnEnable()
    {
        jump.action.started += Jump;
    }



    private void Jump(InputAction.CallbackContext context)
    {
        _ySpeed = _jumpSpeed;
        isGrounded = false;
    }
}
