using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : Baddie
{

    // Use this for initialization
    public override void Start()
    {

        base.Start();
        anim.SetInteger("MobNo", mobNo);


    }

    // Update is called once per frame
    void Update()
    {

    }
}
