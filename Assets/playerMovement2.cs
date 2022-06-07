using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement2 : MonoBehaviour
{
    //CODE FOR PC CONTROL
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;
            transform.position = touchPosition;
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
