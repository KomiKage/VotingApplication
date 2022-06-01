using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float playerSpeed = 5.0f;

    public Rigidbody2D playerRigidbody;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        if (playerRigidbody == null)
        {
            Debug.LogError("Player is missing a Rigidbody2D component");
        }
    }
    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        playerRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * playerSpeed, Input.GetAxisRaw("Vertical") * playerSpeed);
    }

}