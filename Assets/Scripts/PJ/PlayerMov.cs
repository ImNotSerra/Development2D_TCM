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

    private void Update()
    {
        transform.Translate(inputSpeed * Time.deltaTime * movementSpeed);
    }

    public void OnMove(InputValue Value)
    {
        inputSpeed = Value.Get<Vector2>();
    }
}
