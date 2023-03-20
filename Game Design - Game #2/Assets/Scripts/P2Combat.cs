using UnityEngine;
using System.Collections;

public class P2Combat : MonoBehaviour
{
    public Animator P2animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            P2Attack();
        }
    }

    void P2Attack()
    {
        // Play attack animation
        P2animator.SetTrigger("Attack");
        // Detect enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        // Apply damage
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<P1Enemy>().TakeDamage(attackDamage);
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

