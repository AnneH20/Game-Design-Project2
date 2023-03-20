using UnityEngine;
using System.Collections;

public class P1Enemy : MonoBehaviour
{
    public Animator P1animator;
    public int P1maxHealth = 100;
    int P1currentHealth;


    public P1Health P1healthBar;
    [SerializeField] private AudioSource P1Punch;
    [SerializeField] private AudioSource P1Death;

    [SerializeField] private int MaxLives;
    private int currentLives;

    // Start is called before the first frame update
    void Start()
    {
        P1currentHealth = P1maxHealth;
        P1healthBar.P1SetMaxHealth(P1maxHealth);

        currentLives = MaxLives;
    }

    public void TakeDamage(int P1damage)
    {
        P1currentHealth -= P1damage;

        P1animator.SetTrigger("Hurt");
        if (P1currentHealth <= 0)
        {
            Die();
        }
        P1Punch.Play();
        P1healthBar.P1SetHeatlh(P1currentHealth);
    }
    void Die()
    {
        Debug.Log("Enemy 1 died!");
        // Die animation
        P1animator.SetBool("IsDead", true);
        P1Death.Play();
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        //decrement current lives if over 0 lives and reset health
        if(currentLives > 0)
        {
            
            currentLives--;
            P1currentHealth = P1maxHealth;
            P1healthBar.P1SetHeatlh(P1currentHealth);
            
            StartCoroutine(Respawn());
        }
        // need to add end scene as else statmenet. 
        else{
            P1animator.SetBool("HasLives",false);
        }
    }

    public void outOfBounds()
    {
        
       if(currentLives > 0)
        {
            
            currentLives--;
            P1currentHealth = P1maxHealth;
            P1healthBar.P1SetHeatlh(P1currentHealth);
            
            StartCoroutine(Respawn());
        }
        // need to add end scene as else statmenet. 
        else{
            P1animator.SetBool("HasLives",false);
        }
        
    }

    IEnumerator Respawn()
    {
        
        yield return new WaitForSeconds(2f);
        transform.position = new Vector2(4, -4);
        P1animator.SetBool("IsDead", false);
        P1animator.SetBool("HasLives",true);
        P1healthBar.P1SetHeatlh(P1currentHealth);
        
       

    }
}

