using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : Character {    
    protected float jumpHeight;
    public bool isWalled;
    public bool onLadder = false;
    private float climbSpd;
    private float climbVel;
    private float gravityStore;
    private float delay = 3;
    private int numLives;

    public AudioClip spawn;
    [SerializeField] protected Transform wallCheck;

    public AudioClip jump, run, slide;

    public override void Start () {
        sound.PlayOneShot(spawn, 1f);
        nameof = "Player1";
       
        base.Start();
        anim.SetInteger("PlayerNo", playerNo);

        facingRight = true;
        gravityStore = rb2d.gravityScale;

        climbSpd = float.Parse(Find_id(nameof).maxspd);
        jumpHeight = float.Parse(Find_id(nameof).jumpheight);
        numLives = int.Parse(Find_id(nameof).numlives);
        
        aim = new Vector2(+1.5f, 0.2f);
        aimLow = new Vector2(+1.5f, -0.7f);
        Lives.numLives = 3;

    }

	void Update () {

        anim.SetInteger("PlayerNo", 1);
        if (facingRight && Input.GetAxis("Horizontal") < 0 || !facingRight && Input.GetAxis("Horizontal") > 0)
        {
            Flip();
        }
        if(Input.GetAxis("Horizontal") < 0)
        {
            anim.SetBool("Run", true);
            rb2d.velocity = new Vector2(moveSpeed * -1, rb2d.velocity.y);
            //StopCoroutine("Running");
            //StartCoroutine("Running", 0.5f);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            anim.SetBool("Run", true);
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
            //StopCoroutine("Running");
            //StartCoroutine("Running", 0.5f);
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            anim.SetBool("Run", false);
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);

        }
        if (Input.GetAxis("Vertical") < 0 && isGrounded)
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            anim.SetBool("Crouch", true);

        } else
        {
            anim.SetBool("Crouch", false);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            sound.PlayOneShot(jump, 1f);
            anim.SetTrigger("Jump");
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);

        }
        if (Input.GetButtonDown("Fire1"))
        {
            sound.PlayOneShot(shoot, 1f);
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate1;
                if(anim.GetBool("Crouch"))
                {
                    Fire(aimLow);
                } else
                Fire(aim);
            } 
        } 
        if (Input.GetButton("Fire1"))
        {
            anim.SetBool("Shoot", true);
        }
        else
        {
            anim.SetBool("Shoot", false);
        }
        if (onLadder)
        {
            rb2d.gravityScale = 0f;

            climbVel = climbSpd * Input.GetAxisRaw("Vertical");
            rb2d.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), climbVel);

        }else rb2d.gravityScale = gravityStore;
        
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        isWalled = Physics2D.OverlapCircle(wallCheck.position, groundCheckRadius, whatIsGround);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            

            if (health1 <= 20)
            {
                sound.PlayOneShot(death, 1f);
                anim.SetTrigger("Hit");
                health1 -= 20;
                Die();
            }

            else
            {
                sound.PlayOneShot(hit, 1f);
                anim.SetTrigger("Hit");
                health1 -= 20;
            }
        }
        else if (other.gameObject.CompareTag("Heart"))
        {
            if (health1 >= 60)
            {
                health1 = 100;
            }
            else
            {
                health1 += 40;
            }
        }
    }

    void Die()
    {
        if (numLives == 1)
        {
            numLives--;
            Lives.numLives = 0;
            //SceneManager.LoadScene("Game Over");

        }
        else
        {
            numLives--;
            health1 = 100;
            Lives.numLives--; ;
        }
    }
}


