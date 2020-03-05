using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackDetection : MonoBehaviour
{
    private PlayerHealth health;
    private Animator enemyAnimator;
    private float velocidad;
    
    public GameObject enemigo;
    public int damage;
    

    // Start is called before the first frame update
    void Awake()
    {
        enemyAnimator = enemigo.GetComponent<Animator>();
    }

    private void Start()
    {
        health = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ColisionPlayer"))
        {
            enemyAnimator.SetBool("Atack", true);
            health.health-=damage;
            velocidad = enemigo.GetComponent<EnemyMeleControl>().speed;
            Debug.Log(velocidad);
            enemigo.GetComponent<EnemyMeleControl>().speed = 0;
            Debug.Log("HAHAHAHA te quite vida wey");

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ColisionPlayer"))
        {
            enemyAnimator.SetBool("Atack", false);
            enemigo.GetComponent<EnemyMeleControl>().speed = velocidad;

        }
    }
}
