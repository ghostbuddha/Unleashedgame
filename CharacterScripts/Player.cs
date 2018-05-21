using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : Character {

    [SerializeField] public int playerNo;

    protected float jumpHeight, nextRoll;

    public bool     isWalled, isSliding, onLadder = false;

    public bool     jumping, crouching, walljumping, wallsliding, rolling, shooting, locked;

    private float   moveVel, climbSpd, climbVel, 
                    gravityStore;

    public int      numLives;

    protected SpriteRenderer sprite;

    public AudioClip spawn;
    [SerializeField] protected Transform wallCheck, slideCheck;
    

    public AudioClip jump, run, slide;

    public override void Start () {
        sound.PlayOneShot(spawn, 0.2f);
        nameof = "Player1";
       
        base.Start();

        playerNo = int.Parse(Find_id(nameof).playerno);
        anim.SetInteger("PlayerNo", playerNo);

        sprite = GetComponent<SpriteRenderer>();

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
        
        HandleStates();

        HandleMovement();

        HandleAttack();
        
    }

    private void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        isWalled = Physics2D.OverlapCircle(wallCheck.position, groundCheckRadius, whatIsGround);
        isSliding = Physics2D.OverlapCircle(slideCheck.position, groundCheckRadius, whatIsGround);
        

        if (jumping)
        {
            sound.PlayOneShot(jump, 0.24f);
            StartCoroutine(Jump(0.1f));
        }
        else if (walljumping)
        {           
            StartCoroutine(WallJump(0.2f));
        }
        else if (crouching)
        {
            
            if (rolling)
            {
                StartCoroutine(Roll(0.333f));
            } else rb2d.velocity = new Vector2(0, rb2d.velocity.y); 
        }
        
        else if (onLadder)
        {
            rb2d.gravityScale = 0f;
            rb2d.velocity = new Vector2(moveVel, climbVel);
        }
        else if (wallsliding)
        {
            locked = true;

            rb2d.velocity = new Vector2(rb2d.velocity.x, moveSpeed / -2);
            if(!isSliding)
            {
                locked = false;
                rb2d.velocity = new Vector2(moveVel, rb2d.velocity.y);
            }
        }
        
        else
        {
            rb2d.velocity = new Vector2(moveVel, rb2d.velocity.y);
            rb2d.gravityScale = gravityStore;
            
        }
                
    }
        
    protected void HandleStates()
    {
        moveVel = moveSpeed * Input.GetAxisRaw("Horizontal");
        climbVel = climbSpd * Input.GetAxisRaw("Vertical");

        anim.SetInteger("Hori", (int)(Input.GetAxisRaw("Horizontal") * 10 + rb2d.velocity.x));
        anim.SetInteger("Vert", (int)Input.GetAxisRaw("Vertical") * 10);
        if (isGrounded)
        {
            anim.SetBool("Grounded", true);
        }
        else
        {
            anim.SetBool("Grounded", false);
        }
        if (isSliding)
        {
            anim.SetBool("Sliding", true);
        }
        else
        {
            anim.SetBool("Sliding", false);
        }

        if (shooting)
        {
            anim.SetBool("Shoot", true);
        }
        else
        {
            anim.SetBool("Shoot", false);
        }
    }

    protected void HandleMovement()
    {
        if (facingRight && Input.GetAxisRaw("Horizontal") < 0 || !facingRight && Input.GetAxisRaw("Horizontal") > 0) 
        {
            if(!locked)
            {
                Flip();
            }     
            if (isSliding)
            {
                
                wallsliding = true;
            }
        }
        if (facingRight && Input.GetAxisRaw("Horizontal") > 0 || !facingRight && Input.GetAxisRaw("Horizontal") < 0)
        {            
            if (isWalled && !isGrounded)
            {
                Flip();
                locked = true;

            } 
        }
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            if (isSliding)
            {
                locked = false;
                wallsliding = false;
            }

        }

        if (Input.GetAxis("Vertical") < 0 && isGrounded)
        {
            crouching = true;

            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                rolling = true;
            }                        
        }
        else
        {
            crouching = false;
        }

        if (Input.GetButtonDown("Jump") && (isGrounded || wallsliding))
        {
            if (wallsliding)
            {
                walljumping = true;
            }
            else
            {
                jumping = true;
            }            
        }
    }

    protected void HandleAttack()
    {
        if (Input.GetButton("Fire1"))
        {
            shooting = true;
            StartCoroutine(Shoot(fireRate1));
        } else
        {
            shooting = false;
        }
        
    }

    IEnumerator Jump(float cd)
    {
        locked = true;
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);
      
        
        yield return new WaitForSecondsRealtime(cd);

        jumping = false;
        locked = false;
        
    }

    IEnumerator Roll(float cd)
    {
        
        

        if (Time.time > nextRoll)
        {
            locked = true;
            nextFire = Time.time + cd;
            if (facingRight)
            {
                rb2d.velocity = new Vector2(moveSpeed * 2, 0);
            }
            if (!facingRight)
            {
                rb2d.velocity = new Vector2(moveSpeed * -2, 0);
            }

            yield return new WaitForSeconds(cd);

            nextRoll = Time.time + (cd/2);

            locked = false;

        } else
        {
            
        }

        rolling = false;
        

    }

    IEnumerator WallJump (float cd)
    {
        locked = true;

        if (facingRight)
        {
            rb2d.velocity = new Vector2(jumpHeight / 2, jumpHeight / 2);
        }
        else
        {
            rb2d.velocity = new Vector2(jumpHeight / -2, jumpHeight / 2);
        }

        yield return new WaitForSeconds(cd);

        wallsliding = false;
        walljumping = false;
        locked = false;
    }

    IEnumerator Shoot (float cd)
    {
        
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate1;

            if (anim.GetInteger("Vert") < 0)
            {
                Fire(aimLow);

            }
            else Fire(aim);
            sound.PlayOneShot(shoot, 0.24f);
        }
        yield return new WaitForSeconds(cd);
        
    }
        
}


