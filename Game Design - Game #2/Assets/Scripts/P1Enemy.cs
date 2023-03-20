using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class P1Enemy : MonoBehaviour
{
    public Animator P1animator;
    public int P1maxHealth = 100;
    int P1currentHealth;
    public P1Health P1healthBar;
    [SerializeField] private AudioSource P1Punch;
    [SerializeField] private AudioSource P1Death;
    public Image[] lives;
    //[SerializeField] private int MaxLives;
    public int currentLives;

    public GameOverScript gameManager;
    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        P1currentHealth = P1maxHealth;
        P1healthBar.P1SetMaxHealth(P1maxHealth);

        currentLives = 3;
    }

    public void TakeDamage(int P1damage)
    {
        P1currentHealth -= P1damage;

        P1animator.SetTrigger("Hurt");
        if (P1currentHealth <= 0)
        {
            Die();
            
            //decrement current lives if over 0 lives and reset health
            if (currentLives > 0)
            {
                currentLives--;
                lives[currentLives].enabled = false;
                P1currentHealth = P1maxHealth;
                P1healthBar.P1SetHeatlh(P1currentHealth);

                StartCoroutine(Respawn());
            }
            // need to add end scene as else statmenet. 
            if (currentLives == 0)
            {
                Die();
                P1animator.SetBool("HasLives", false);
                GameOver();
            }
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

 //       GetComponent<Collider2D>().enabled = false;
 //       this.enabled = false;
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            //Set game over to true
            isGameOver = true;

            //Announce winner
            Debug.Log("Player 2 Wins!");

            //Trigger Game Over Manager
            gameManager.gameOver();

            //Disable Player
            gameObject.SetActive(false);
        }

        else
        {
            gameManager.gameOver();
        }
    }

    public void outOfBounds()
    {
        
       if(currentLives > 0)
        {
            Die();
            currentLives--;
            lives[currentLives].enabled = false;
            P1currentHealth = P1maxHealth;
            P1healthBar.P1SetHeatlh(P1currentHealth);
            
            StartCoroutine(Respawn());
        }
        // need to add end scene as else statmenet. 
        if (currentLives == 0)
        {
            P1animator.SetBool("HasLives", false);
            GameOver();
        }
    }

    IEnumerator Respawn()
    {     
        yield return new WaitForSeconds(1f);
        transform.position = new Vector2(-4, -4);
        //P1animator.SetBool("IsDead", false);
        P1animator.SetBool("HasLives",true);
        P1healthBar.P1SetHeatlh(P1currentHealth);
    }
}

