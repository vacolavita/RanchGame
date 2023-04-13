using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField]
    private float _playerSpeed = 5f;

    [SerializeField]
    private float _rotationSpeed = 10f;

    private Vector3 _playerVelocity;
    private bool _groundedPlayer;

    [SerializeField]
    private float _gravityValue = -9.81f;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
 
    }

    private void Update()
    {
        Movement();
    }

    void Movement()
    {
        _groundedPlayer = _controller.isGrounded;
        if (_groundedPlayer && _playerVelocity.y < 0)
        {
            _playerVelocity.y = _gravityValue/2;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementInput = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 movementDirection = movementInput;
        if (Mathf.Sqrt(Mathf.Pow(movementInput.x, 2) + Mathf.Pow(movementInput.z, 2)) > 1)
        movementDirection = movementInput.normalized;
        
        _controller.Move(movementDirection * _playerSpeed * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, _rotationSpeed * Time.deltaTime);
        }

        _playerVelocity.y += _gravityValue * Time.deltaTime;
        _playerVelocity.y = Mathf.Max(_playerVelocity.y, -20);

        _controller.Move(_playerVelocity * Time.deltaTime);
    }
}