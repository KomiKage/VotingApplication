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

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        _input = playerInput.actions["Move"].ReadValue<Vector2>();
        MovePlayer();
    }

    private void MovePlayer()
    {
        
        playerRigidbody.velocity = new Vector2(JoystickMovement.input.x * playerSpeed, JoystickMovement.input.y * playerSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shop"))
        {
            PopupWindow.window.SetActive(true);
            notificationScript.NotificationBlock();
            popupScript.AddToQueue("Local store reached");
            Debug.Log("1 werkt");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Shop"))
        {
            PopupWindow.window.SetActive(false);
            Debug.Log("2werkt");
        }
    }
}