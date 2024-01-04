using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Vector2 movement;
    public Rigidbody2D rb;
    public float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        movement = new Vector2(horizontalInput, verticalInput).normalized;


    }

    void FixedUpdate()
    {
        // Calculate the target position (Player).
        Vector2 targetPosition = rb.position + movement * moveSpeed * Time.fixedDeltaTime;

        // Move the player to the target position.
        rb.MovePosition(targetPosition);

    }
}
