using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Baddie{

	// Use this for initialization
	public override void Start () {

        base.Start();
        anim.SetInteger("BossNo", bossNo);


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
