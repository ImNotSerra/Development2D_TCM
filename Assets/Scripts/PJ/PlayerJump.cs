using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D rb2d;

    [Range(0, 1000)]
    public float jumpForce = 500f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public int maxNumOfJumps = 1;

    private Animator playerAnimator;
    private int numOfJumps = 0;

    [SerializeField]
    private LayerMask whatIsGround;

    [SerializeField]
    private Transform checkGround;

    public bool isGrounded;
    //public bool IsGrounded => isGrounded;

    private float checkRadius = 0.1f;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();

        rb2d = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        CheckGrounded();
    }

    private void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(checkGround.position, checkRadius, whatIsGround);        
    }

    public void OnJump()
    {
        if (isGrounded)
        {
            numOfJumps = 0;
        }

        if (numOfJumps <= maxNumOfJumps)
        {
            if (numOfJumps == maxNumOfJumps) 
            {
                playerAnimator.SetTrigger("DoubleJump");
            }
            else
            {
                playerAnimator.SetTrigger("Jump");
            }
            rb2d.velocity = Vector2.up * jumpForce;

            if (rb2d.velocity.y < 0)
            {
                rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;                
            }
            numOfJumps++;            
        }
        
    }

    public void OnJumpRelease()
    {       
        if (rb2d.velocity.y > 0)
        {
      
            playerAnimator.SetTrigger("OnAir");

            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

    }
}
