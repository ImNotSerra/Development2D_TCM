using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int maxHealth = 100;

    public Animator animator;
    public GameObject shot;
    public float startTimeBtwShots;
    public float visionRadius;

    private float timeBtwShots;
    private int currentHealth;
    private Vector2 toPlayer;
    private GameObject player;
    private Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb2D = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    private void FixedUpdate()
    {
        toPlayer = player.transform.position - rb2D.transform.position;

        if (toPlayer.magnitude < visionRadius)
        {

            //Shooting
            if (timeBtwShots <= 0)
            {
                Instantiate(shot, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }

        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //Play Hurt animation

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy down");

        //Die animation 
        

        //Disable the enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        Destroy(this.gameObject);
    }
}