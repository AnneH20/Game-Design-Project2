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
    [SerializeField] private int MaxLives;
    private int currentLives;

    public P2Health P2healthBar;

    public GameOverScript gameManager;
    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        P2currentHealth = P2maxHealth;
        P2healthBar.P2SetMaxHealth(P2maxHealth);

        currentLives = MaxLives;

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

        //decrement current lives if over 0 lives and reset health
        if(currentLives > 0)
        {
            
            currentLives--;
            P2currentHealth = P2maxHealth;
            P2healthBar.P2SetHeatlh(P2currentHealth);
            
            StartCoroutine(Respawn());
        }
        // need to add end scene as else statmenet. 
        else{
            P2animator.SetBool("HasLives",false);
            GameOver();
        }
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            //Set game over to true
            isGameOver = true;

            //Announce winner
            Debug.Log("Player 1 Wins!");

            //Trigger Game Over Manager
            gameManager.gameOver();

            //Disable Player
            gameObject.SetActive(false);
        }

        else
        {
            //Nothing happens
        }
    }

    public void outOfBounds()
    {
        if(currentLives > 0)
        {
            
            currentLives--;
            P2currentHealth = P2maxHealth;
            P2healthBar.P2SetHeatlh(P2currentHealth);
            
            StartCoroutine(Respawn());
        }
        // need to add end scene as else statmenet. 
        else{
            P2animator.SetBool("HasLives",false);
        }

    }

    IEnumerator Respawn()
    {
        
        yield return new WaitForSeconds(2f);
        transform.position = new Vector2(-4, -4);
        P2animator.SetBool("IsDead", false);
        P2animator.SetBool("HasLives",true);
        P2healthBar.P2SetHeatlh(P2currentHealth);
    }
}
