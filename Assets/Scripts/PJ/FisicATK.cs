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

    public void OnAtaqueFisico()
    {
        Attack();
    }

    void Attack()
    {
        Debug.Log("FUNCIONA GUCHI");
        //Detect enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("we hit" + enemy.name);
            enemy.GetComponent<EnemyController>().TakeDamage(attackDamage);
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
