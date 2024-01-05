using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Vector2 movement;
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public bool facingright = true;

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

        if (horizontalInput > 0 && !facingright)
        {
            flip();
        }
        if (horizontalInput < 0 && facingright)
        {
            flip();
        }


    }

    void FixedUpdate()
    {
        // Calculate the target position (Player).
        Vector2 targetPosition = rb.position + movement * moveSpeed * Time.fixedDeltaTime;

        // Move the player to the target position.
        rb.MovePosition(targetPosition);


    }

    void flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *=  -1;
        gameObject.transform.localScale = currentScale;

        facingright = !facingright;
    }
}
