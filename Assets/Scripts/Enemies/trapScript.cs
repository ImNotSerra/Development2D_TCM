using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapScript : MonoBehaviour
{
    Animator animator;
    public int damage;
    [SerializeField] public int currentHealth;
    public int maxHealth;
    private PlayerHealth health;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        damage = 1;
        animator = GetComponent<Animator>();
        health = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ColisionPlayer"))
        {
            animator.SetBool("TrapActive", true);

            health.health -= damage;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ColisionPlayer"))
        {
            animator.SetBool("TrapActive", false);
        }
    }
    public void Daño(int damage)
    {
        currentHealth -= damage;
        Debug.Log("daño");
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
