using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.U2D.IK;
using UnityEngine.XR;

public class PlayerMove : MonoBehaviour
{
    Vector2 movement;
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float runSpeed = 5f;
    public float jumpingPower = 16f;
    float horizontalInput;
    private float wallSlidingSpeed = 2f;
    private float wallJumpingDirection;
    private float wallJumpingTime = 0.9f;
    private float wallJumpingCounter;
    private float wallJumpingDuration = 1f;
    private Vector2 wallJumpingPower = new Vector2(10f, 16f);


    public Vector2 arahLompat;
    public int extrajumpsisa;
    
    [SerializeField] Transform groundCheck;
    [SerializeField] Transform nemplekCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask tembokLayer;
    [SerializeField] int ExtraJumpValue = 1;


    bool running;
    public bool facingright = true;
    private bool isWallSliding;
    private bool isWallJumping;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (IsGround())
        {
            extrajumpsisa = ExtraJumpValue;
        }

 /*       if (NempelTembok() && !IsGround())
        {
            rb.gravityScale = 15;
            jatuhnempeltembok = false;
        } else
        {
            rb.gravityScale = 10;
        }*/

        /*        movement = new Vector2(horizontalInput).normalized;*/

        //Cek arah hadap player agar flip sprite karakter
   

        //Lompat
        if (Input.GetKeyDown(KeyCode.Space) && IsGround() && !isWallSliding)
        {   
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            Debug.Log("IsJumping");
        }
/*        else if (Input.GetKeyDown(KeyCode.Space) && extrajumpsisa > 0 && !NempelTembok())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            extrajumpsisa--;
        }*/


/*        else if (Input.GetKeyDown(KeyCode.Space) && NempelTembok())
        {
            rb.velocity = new Vector2(20f, jumpingPower);

            *//*            Vector2 jumpVelocity = new Vector2(20f, jumpingPower);
                        rb.velocity += jumpVelocity;*/
            /*            rb.AddForce(arahLompat * jumpingPower, ForceMode2D.Impulse);*//*
            Debug.Log("lompat dari tembok");
            extrajumpsisa--;
        }*/

/*        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f && !isWallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y* 0.3f); 
        }*/


        //Lari
        if (horizontalInput !=  0 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            running = true;
        } else if (Input.GetKeyUp(KeyCode.LeftShift)) 
        { 
            running = false;
        }

        WallSlide();
        wallJump();
        
        if (!isWallJumping)
        {
            flip();
        }
    }

    //Cek apakah player menyentuh tanah
    public bool IsGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 1.5f, groundLayer);
    }

    public bool NempelTembok()
    {
        return Physics2D.OverlapCircle(nemplekCheck.position, 0.2f, tembokLayer);
    }

    void FixedUpdate()
    {

        // Calculate the target position (Player).
        /*        Vector2 targetPosition = rb.position + movement * moveSpeed * Time.fixedDeltaTime;

                // Move the player to the target position.
                rb.MovePosition(targetPosition);*/
        //Jika benar lari, maka speed lari, jika tidak maka speed berjalan

        if (!isWallJumping)
        {
            
            /*            if (running)
                        {
                            rb.velocity = new Vector2(horizontalInput * runSpeed, rb.velocity.y);
                        }
                        else
                        {*/
            /*}*/
            if (!isWallSliding)
            {
                rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
                
            }


        }

    }

    void move()
    {
       /* rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
*/
    }

    //Fungsi flip sprite karakter player
    void flip()
    {
        if (facingright && horizontalInput < 0f || !facingright && horizontalInput >0f)
        {
            facingright = !facingright;
            Vector3 currentScale = gameObject.transform.localScale;
            currentScale.x *= -1;
            gameObject.transform.localScale = currentScale;
        }     
    }

    private void WallSlide()
    {
        if (NempelTembok() && !IsGround() && horizontalInput != 0f)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        } else
        {
            isWallSliding = false; 
        }
    }

    private void wallJump()
    {
        if (isWallSliding)
        {
          isWallJumping = false;
          wallJumpingDirection = -transform.localScale.x;
          wallJumpingCounter = wallJumpingTime;

         CancelInvoke(nameof(StopWallJumping));
        } else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && wallJumpingCounter > 0f && !IsGround())
        {
         isWallJumping = true;
         rb.velocity = new Vector2(wallJumpingDirection* wallJumpingPower.x, jumpingPower);
        
        Debug.Log(rb.velocity);
         wallJumpingCounter = 0f;

        if (transform.localScale.x != wallJumpingDirection)
            {
                facingright = !facingright;
                Vector3 currentScale = gameObject.transform.localScale;
                currentScale.x *= -1f;
                gameObject.transform.localScale = currentScale;     
            }

            Invoke(nameof(StopWallJumping), wallJumpingDuration);

        }
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
        Debug.Log("Jump ends");
    }
}
