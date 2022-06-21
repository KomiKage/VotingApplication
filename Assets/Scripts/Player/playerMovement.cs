using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public float playerSpeed = 5.0f;

    private Rigidbody2D playerRigidbody;
    private PlayerInput playerInput;
    private Vector2 _input;

    public Joystick joystick;

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

        /*Vector3 moveVector = (Vector3.up * joystick.Vertical - Vector3.left * joystick.Horizontal);
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
        }*/
    }

    private void MovePlayer()
    {
        //playerRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * playerSpeed, Input.GetAxisRaw("Vertical") * playerSpeed);
        playerRigidbody.velocity = new Vector2(_input.x * playerSpeed, _input.y * playerSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "NotifBlock")
        {
            notificationScript.NotificationBlock();
            popupScript.AddToQueue("Block touched");
        }
    }
}