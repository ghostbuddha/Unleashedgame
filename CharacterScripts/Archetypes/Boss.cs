using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Baddie{

    [SerializeField] protected int bossNo;


    public override void Start()
    {

        base.Start();

        bossNo = int.Parse(Find_id(nameof).bossno);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
