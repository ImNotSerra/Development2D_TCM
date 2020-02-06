using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastDetection : MonoBehaviour
{

    public Transform originPoint;
    private Vector3 dir = new Vector3(0,-1,0);
    public float range;
    public float speed;
    

    Rigidbody2D rb2D;


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
      
    }
    void FixedUpdate()
    {
        // Cast a ray straight down.
        RaycastHit2D hit = Physics2D.Raycast(originPoint.position, dir, range);
        Debug.DrawRay(originPoint.position, dir * range);

        //if (hit.collider.CompareTag("Player"))
        //{
        rb2D.AddForce(Vector3.down * speed);
        //}
    }
}