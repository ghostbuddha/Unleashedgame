using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddhaHead : Boss {

    [SerializeField] private Transform laserEyes;
    [SerializeField] private Transform spawnMouth;

    public override void Start () {

        nameof = "BuddhaHead";
        base.Start();

        
    }
	
	// Update is called once per frame
	void Update () {

        
    }

    private void FixedUpdate()
    {
        Patrol();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Fire();
    }
    void Fire()
    {
        

        if (facingRight)
        {
            
            Instantiate(projectileRight, laserEyes.position, Quaternion.identity);
        }
        else
        {
            
            Instantiate(projectileLeft, laserEyes.position, Quaternion.identity);
        }
    }
}
