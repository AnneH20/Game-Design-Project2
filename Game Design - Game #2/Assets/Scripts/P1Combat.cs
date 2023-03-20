using UnityEngine;
using System.Collections;

public class P1Combat : MonoBehaviour
{
    [SerializeField] private AudioClip FCyberPunch;
    public Animator P1animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SoundManager.instance.PlaySound(FCyberPunch);
            P1Attack();
        }
    }

    void P1Attack()
    {
        // Play attack animation
        P1animator.SetTrigger("Attack");
        // Detect enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        // Apply damage
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<P2Enemy>().TakeDamage(attackDamage);
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

