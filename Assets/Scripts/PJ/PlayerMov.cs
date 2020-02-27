using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMov : MonoBehaviour
{
    Vector2 inputSpeed;
    private Rigidbody2D rb2d;
    
    public float movementSpeed = 5f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        ApplyInput();
    }

    public void OnMove(InputValue Value)
    {
        //inputSpeed = Value.Get<Vector2>() * movementSpeed;
    }

    public void ApplyInput()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        float xForce = xInput * movementSpeed * Time.deltaTime;

        Vector2 force = new Vector2(xForce, 0);

        rb2d.AddForce(force);
    }
}
