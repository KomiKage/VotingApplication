using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public float playerSpeed = 5.0f;

    public Rigidbody2D playerRigidbody;
    public PlayerInput playerInput;
    private Vector2 _input;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        if (playerRigidbody == null)
        {
            Debug.LogError("Player is missing a Rigidbody2D component");
        }

        playerInput = GetComponent<PlayerInput>();
    }
    private void Update()
    {
        _input = playerInput.actions["Move"].ReadValue<Vector2>();
        MovePlayer();
    }

    private void MovePlayer()
    {
        //playerRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * playerSpeed, Input.GetAxisRaw("Vertical") * playerSpeed);
        playerRigidbody.velocity = new Vector2(_input.x * playerSpeed, _input.y * playerSpeed);
    }

}