using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{

    private Rigidbody2D rb2d;

    [SerializeField]
    public Transform checkTop;
    public Transform checkRight;
    public Transform checkLeft;

    public LayerMask whatIsTop;
    public LayerMask whatIsLeft;
    public LayerMask whatIsRight;

    public bool isTop;
    public bool isRight;
    public bool isLeft;

    public float checkRadius = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Checktop();
        CheckRight();
        CheckLeft();
    }

    private void Checktop()
    {
        isTop = Physics2D.OverlapCircle(checkTop.position, checkRadius, whatIsTop);
    }

    private void CheckRight()
    {
        isRight = Physics2D.OverlapCircle(checkRight.position, checkRadius, whatIsRight);
    }

    private void CheckLeft()
    {
        isLeft = Physics2D.OverlapCircle(checkLeft.position, checkRadius, whatIsLeft);
    }
}
