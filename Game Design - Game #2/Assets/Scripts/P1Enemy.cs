using UnityEngine;
using System.Collections;

public class P1Enemy : MonoBehaviour
{
    public Animator P1animator;
    public int P1maxHealth = 100;
    int P1currentHealth;
    public P1Health P1healthBar;
    [SerializeField] private AudioSource P1Audio;

    // Start is called before the first frame update
    void Start()
    {
        P1currentHealth = P1maxHealth;
        P1healthBar.P1SetMaxHealth(P1maxHealth);
    }

    public void TakeDamage(int P1damage)
    {
        P1currentHealth -= P1damage;

        P1animator.SetTrigger("Hurt");
        if (P1currentHealth <= 0)
        {
            Die();
        }
        P1Audio.Play();
        P1healthBar.P1SetHeatlh(P1currentHealth);
    }
    void Die()
    {
        Debug.Log("Enemy 1 died!");
        // Die animation
        P1animator.SetBool("IsDead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}

