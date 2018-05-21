using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
 
[RequireComponent(typeof(Player))]

public class PlayerHealth : MonoBehaviour {
 
    private float maxHealth;
    private float currentHealth;
    public float hurtTime;
    

    private bool immortal, alive;

    protected Animator anim;
    protected Rigidbody2D rb2d;
    public AudioSource sound;
    public Player player;

    private SpriteRenderer sprite;

    public float MaxHealth
    {
        get
        {
            return maxHealth;
        }

    }
    public float CurrentHealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth += value;
        }
    }

    void Start() {        

        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        sound = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();

        maxHealth = player.health1;
        currentHealth = maxHealth;

        hurtTime = 3f;
    }
 
    // Update is called once per frame
    void Update() {

        
        
    }
    private void FixedUpdate()
    {
        
            
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            float dmg = other.gameObject.GetComponent<ShootScript>().damage;

            StartCoroutine(Hurt(hurtTime, dmg));

            if (currentHealth <= 0)
            {
                sound.PlayOneShot(player.death, 0.24f);
                Die();
            }
            else
            {
                sound.PlayOneShot(player.hit, 0.24f);
            }
        }
        else if(other.gameObject.CompareTag("Enemy"))
        {
            float dmg = other.gameObject.GetComponent<Baddie>().collisionDamage;

            StartCoroutine(Hurt(hurtTime, dmg));

            if (currentHealth <= 0)
            {
                sound.PlayOneShot(player.death, 0.24f);
                Die();
            }
            else
            {
                if (!immortal)
                sound.PlayOneShot(player.hit, 0.24f);
            }
        }
        else if (other.gameObject.CompareTag("Heart"))
        {
            currentHealth += other.gameObject.GetComponent<HealthPickup>().amount;
        }
    }

    void Die()
    {
        if (player.numLives == 1)
        {
            player.numLives--;
            Lives.numLives = 0;
            SceneManager.LoadScene("Game Over");
        }
        else
        {
            player.numLives--;
            currentHealth = 100;
            Lives.numLives--; ;
        }
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator Hurt(float cd, float dmg)
    {
        if (!immortal)
        {
            currentHealth -= dmg;

            if(currentHealth > 0)
            {
                anim.SetTrigger("Hit");
                immortal = true;
                StartCoroutine(Invincible(hurtTime / 20));
                yield return new WaitForSeconds(cd);
                immortal = false;
            }
            else
            {
                anim.SetTrigger("Die");
            }

        }
    }

    IEnumerator Invincible(float cd)
    {
        while (immortal)
        {
            yield return new WaitForSeconds(cd);

            sprite.enabled = false;

            yield return new WaitForSeconds(cd);

            sprite.enabled = true;
        }

    }

}