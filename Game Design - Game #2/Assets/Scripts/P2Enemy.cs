using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Enemy : MonoBehaviour
{
    public Animator P2animator;
    public int P2maxHealth = 100;
    int P2currentHealth;
    [SerializeField] private AudioSource P2Punch;
    [SerializeField] private AudioSource P2Death;

    public P2Health P2healthBar;

    // Start is called before the first frame update
    void Start()
    {
        P2currentHealth = P2maxHealth;
        P2healthBar.P2SetMaxHealth(P2maxHealth);
    }

    public void TakeDamage(int P2damage)
    {
        P2currentHealth -= P2damage;

        P2animator.SetTrigger("Hurt");
        if (P2currentHealth <= 0)
        {
            Die();
        }
        P2Punch.Play();
        P2healthBar.P2SetHeatlh(P2currentHealth);
    }
    void Die()
    {
        Debug.Log("Enemy 2 died!");
        // Die animation
        P2animator.SetBool("IsDead", true);
        P2Death.Play();
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    public void outOfBounds()
    {
        P2currentHealth = 0;
        P2healthBar.P2SetHeatlh(P2currentHealth);
    }
}
