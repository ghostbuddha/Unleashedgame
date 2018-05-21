using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : Mob {

    


    public override void Start () {
        
        

        nameof = "A1";

        base.Start();


    }


    void Update () {

        
       
       
	}

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        isEdged = Physics2D.OverlapCircle(edgeCheck.position, groundCheckRadius, whatIsGround);
        Patrol();
    }

    


}
