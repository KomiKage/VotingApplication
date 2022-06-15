using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementTestBrom : MonoBehaviour
{

    public float playerSpeed = 5.0f;
    public Rigidbody2D playerRigidbody;
    public PlayerInput playerInput;
    private Vector2 _input;

    public MobileNotificationManager notificationScript;
    public PopupWindow popupScript;

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
        
        playerRigidbody.velocity = new Vector2(JoystickMovement.input.x * playerSpeed, JoystickMovement.input.y * playerSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Shop")
        {
            notificationScript.NotificationBlock();
            popupScript.AddToQueue("Store reached");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Shop")
        {
            PopupWindow.window.gameObject.SetActive(false);
        }
    }






}