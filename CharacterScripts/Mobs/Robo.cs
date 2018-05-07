using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robo : Baddie {

    
    
    public override void Start ()
    {
        nameof = "A2";
        
        base.Start();
    }

    void Update()
    {


        
    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        Patrol();
    }
    
    

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Detect");
            
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("Fire", 0.2f);
            Invoke("Fire", 0.5f);
            Invoke("Fire", 0.8f);
        }
    } 
    void Fire()
    {
        projPos = transform.position;
        sound.PlayOneShot(shoot, 1f);
        if (facingRight)
        {
            projPos += new Vector2(+1.5f, 0.2f);
            Instantiate(projectileRight, projPos, Quaternion.identity);
        }
        else
        {
            projPos += new Vector2(-1.5f, 0.2f);
            Instantiate(projectileLeft, projPos, Quaternion.identity);
        }
    }
    

}
