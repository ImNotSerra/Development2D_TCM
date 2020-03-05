using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FisicATK : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public float attackRate = 2f;
    public int attackDamage = 40;
    private Animator playerAnimator;

    public void OnAtaqueFisico()
    {
        Attack();
    }
    private void Start()
    {
        playerAnimator = GetComponent<Animator>();

    }

    void Attack()
    {
        //Debug.Log("FUNCIONA GUCHI");
        //Detect enemies in range
        playerAnimator.SetTrigger("atack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("we hit" + enemy.name);
            if (enemy.name.Equals("LongRange"))
            {
                enemy.GetComponent<EnemyController>().TakeDamage(attackDamage);

            }
            if (enemy.name.Equals("Trap"))
            {
                enemy.GetComponent<trapScript>().Daño(attackDamage);
            }
            if (enemy.name.Equals("PatrolingEnemy"))
            {
                enemy.GetComponent<EnemyMeleControl>().TakeDamage(attackDamage);

            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
