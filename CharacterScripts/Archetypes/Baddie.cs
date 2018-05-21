using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Baddie : Character
{
    [SerializeField] protected Transform edgeCheck;
    [SerializeField] protected bool isEdged;
    public float collisionDamage = 20;

    public override void Start()
    {
        base.Start();
        

    }
    protected void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            
            anim.SetTrigger("Hit");
            health1 -= 34;
            //other.gameObject.GetComponent<Damage>;
            if (health1 <= 0)
            {
                anim.SetTrigger("Die");
                sound.PlayOneShot(death, .5f);                
                Invoke("Pop", .5f);
            } else sound.PlayOneShot(hit, .5f);
        }
        else
        {
            
        }

    }

    protected void Patrol()
    {
        if (isGrounded||!isEdged)
        {
            movingRight = !movingRight;
        }
        if (movingRight)
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(moveSpeed * -1, rb2d.velocity.y);
        }

        if (facingRight && rb2d.velocity.x < 0 || !facingRight && rb2d.velocity.x > 0)
        {
            Flip();
        }
    }


    IEnumerator Levitate()
    {

        yield return null;
    }

    void Pop()
    {
        anim.SetTrigger("Hit");
        Destroy(gameObject);
    }
}