using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    //Public
    [Header("Stats:")]
    public float speed;
    public int damage;

    //Private
    private Transform playerPos;
    private Vector2 target;

    
    // Use this for initialization
    void Start ()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(playerPos.position.x, playerPos.position.y);
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
            other.GetComponent<PlayerHealth>().health -= damage;
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
