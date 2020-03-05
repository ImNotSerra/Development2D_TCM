using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMov : MonoBehaviour
{
    Vector2 inputSpeed;
    private Rigidbody2D rb2d;
    private Animator playerAnimator;
    bool izq = false;
    
    public float movementSpeed = 5f;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.Translate(inputSpeed * Time.deltaTime * movementSpeed);
        if (inputSpeed.x >= 0.1f || inputSpeed.x <= -0.1f)
        {
            playerAnimator.SetTrigger("Walking");
          
        }
        else
        {
            playerAnimator.SetTrigger("idle");
        }
        if (inputSpeed.x <= -0.1f && !izq)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            izq = true;
        }
        if (inputSpeed.x >= 0.1f && izq)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            izq = false;
        }

    }

    public void OnMove(InputValue Value)
    {
  
        inputSpeed = Value.Get<Vector2>();


    }
}
