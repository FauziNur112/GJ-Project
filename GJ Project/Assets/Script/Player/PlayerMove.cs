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
    [SerializeField] Transform nemplekCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask tembokLayer;
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

        //Cek arah hadap player agar flip sprite karakter
        if (horizontalInput > 0 && !facingright)
        {
            flip();
        }
        if (horizontalInput < 0 && facingright)
        {
            flip();
        }

        //Lompat
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGround() || NempelTembok())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                Debug.Log("IsJumping");
            }

        }

        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y* 0.3f);
        }


        //Lari
        if (horizontalInput !=  0 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            running = true;
        } else if (Input.GetKeyUp(KeyCode.LeftShift)) 
        { 
            running = false;
        }

    }

    //Cek apakah player menyentuh tanah
    public bool IsGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 1.5f, groundLayer);
    }

    public bool NempelTembok()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 1.5f, tembokLayer);
    }

    void FixedUpdate()
    {
        // Calculate the target position (Player).
        /*        Vector2 targetPosition = rb.position + movement * moveSpeed * Time.fixedDeltaTime;

                // Move the player to the target position.
                rb.MovePosition(targetPosition);*/
        //Jika benar lari, maka speed lari, jika tidak maka speed berjalan
        if (running)
        {
            rb.velocity = new Vector2(horizontalInput * runSpeed, rb.velocity.y);
        } else
        {
            rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        }
        


    }

    //Fungsi flip sprite karakter player
    void flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *=  -1;
        gameObject.transform.localScale = currentScale;

        facingright = !facingright;
    }
}
