using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : Character {    

    protected float jumpHeight;
    public bool isWalled, isSliding, onLadder = false;
    private bool jumping, crouching, walljumping, wallsliding, locked;
    private float moveVel, climbSpd, climbVel, gravityStore, delay = 3;
    private int numLives;

    public AudioClip spawn;
    [SerializeField] protected Transform wallCheck, slideCheck;
    

    public AudioClip jump, run, slide;

    public override void Start () {
        sound.PlayOneShot(spawn, 0.2f);
        nameof = "Player1";
       
        base.Start();
        anim.SetInteger("PlayerNo", playerNo);

        facingRight = true;
        locked = false;
        gravityStore = rb2d.gravityScale;
        

        climbSpd = float.Parse(Find_id(nameof).maxspd);
        jumpHeight = float.Parse(Find_id(nameof).jumpheight);
        numLives = int.Parse(Find_id(nameof).numlives);
        
        aim = new Vector2(+1.5f, 0.2f);
        aimLow = new Vector2(+1.5f, -0.7f);
        Lives.numLives = 3;

    }

	void Update () {
               
            moveVel = moveSpeed * Input.GetAxisRaw("Horizontal");
            climbVel = climbSpd * Input.GetAxisRaw("Vertical");

        if ((facingRight && Input.GetAxisRaw("Horizontal") < 0 || (!facingRight && Input.GetAxisRaw("Horizontal") > 0)) && !locked)             
        {            
            Flip();
        }

        if (facingRight && Input.GetAxisRaw("Horizontal") > 0 || !facingRight && Input.GetAxisRaw("Horizontal") < 0)
        {
            HandleSliding();
        }

        if (moveVel != 0)
        {
            anim.SetBool("Run", true);
            
        } else anim.SetBool("Run", false);

        if (isGrounded || !isSliding)
        {
            anim.SetBool("Cling", false);
            locked = false;

        }


        if (Input.GetAxis("Vertical") < 0 && isGrounded)
        {
            anim.SetBool("Crouch", true);

        } else anim.SetBool("Crouch", false);
        

        if (Input.GetButtonDown("Jump") && (isGrounded || wallsliding))
        {
            sound.PlayOneShot(jump, 0.24f);
            anim.SetTrigger("Jump");

            if (wallsliding)
            {
                walljumping = true;

            } else jumping = true;

        }        
        // if walled and moving into wall flip and start sliding
        // if sliding and moving into wall keep sliding, if not, fall

        if (Input.GetButtonDown("Fire1"))
        {
            sound.PlayOneShot(shoot, 0.24f);

            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate1;

                if(anim.GetBool("Crouch"))
                {
                    Fire(aimLow);

                } else Fire(aim);
            } 
        } 

        if (Input.GetButton("Fire1"))
        {
            anim.SetBool("Shoot", true);

        } else anim.SetBool("Shoot", false);

        

        
        
    }

    private void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        isWalled = Physics2D.OverlapCircle(wallCheck.position, groundCheckRadius, whatIsGround);
        isSliding = Physics2D.OverlapCircle(slideCheck.position, groundCheckRadius, whatIsGround);

        if (jumping)
        {


            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);

            Invoke("MovementRestore", 0.1f);

        }
        else if (walljumping)
        {


            if (facingRight)
            {
                
                rb2d.velocity = new Vector2(jumpHeight / 2, jumpHeight);
                
            }
            else
            {
                
                rb2d.velocity = new Vector2(jumpHeight / -2, jumpHeight);
                
            }
            
            locked = true;

            Invoke("MovementRestore", 0.2f);

        }
        else if (anim.GetBool("Crouch"))
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);

        }
        else if (onLadder)
        {
            rb2d.gravityScale = 0f;

            rb2d.velocity = new Vector2(moveVel, climbVel);

        } else if (wallsliding)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, moveSpeed / -2);
        }
        else
        {
            rb2d.velocity = new Vector2(moveVel, rb2d.velocity.y);
            rb2d.gravityScale = gravityStore;
        }
                
    }
    
    void MovementRestore()
    {
        jumping = false;
        walljumping = false;
        wallsliding = false;
        locked = false;
    }

    void HandleSliding()
    {
        
            if (isWalled && !isGrounded)
            {
                Flip();
                locked = true;

            }
            if (isSliding && !isGrounded)
            {
                anim.SetBool("Cling", true);
                wallsliding = true;
                locked = true;

            }
        
        
        /*if (facingRight && Input.GetAxisRaw("Horizontal") < 0 || !facingRight && Input.GetAxisRaw("Horizontal") > 0)
        {
            
        }*/
        
        else
        {
            anim.SetBool("Cling", false);
            wallsliding = false;
            locked = false;
        }

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            

            if (health1 <= 20)
            {
                sound.PlayOneShot(death, 0.24f);
                anim.SetTrigger("Hit");
                health1 -= 20;
                Die();
            }

            else
            {
                sound.PlayOneShot(hit, 0.24f);
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
            SceneManager.LoadScene("Game Over");

        }
        else
        {
            numLives--;
            health1 = 100;
            Lives.numLives--; ;
        }
    }
}


