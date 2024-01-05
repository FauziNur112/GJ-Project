using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Vector2 movement;
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float runSpeed = 5f;
    bool running;
    public bool facingright = true;
    public float jumpingPower = 16f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        Debug.Log(IsGround());

/*        movement = new Vector2(horizontalInput).normalized;*/

        if (horizontalInput > 0 && !facingright)
        {
            flip();
        }
        if (horizontalInput < 0 && facingright)
        {
            flip();
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGround())
        {
            rb.velocity = new Vector2 (rb.velocity.x, jumpingPower);
            Debug.Log("IsJumping");
        }

        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y* 0.5f);
        }

        if (horizontalInput !=  0 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            running = true;
        } else if (Input.GetKeyUp(KeyCode.LeftShift)) 
        { 
            running = false;
        }

    }

    public bool IsGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 1.5f, groundLayer);
    }

    void FixedUpdate()
    {
        // Calculate the target position (Player).
        /*        Vector2 targetPosition = rb.position + movement * moveSpeed * Time.fixedDeltaTime;

                // Move the player to the target position.
                rb.MovePosition(targetPosition);*/
        if (running)
        {
            rb.velocity = new Vector2(horizontalInput * runSpeed, rb.velocity.y);
        } else
        {
            rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        }
        


    }

    void flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *=  -1;
        gameObject.transform.localScale = currentScale;

        facingright = !facingright;
    }
}
