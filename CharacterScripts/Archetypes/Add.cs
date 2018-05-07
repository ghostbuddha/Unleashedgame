using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add : Baddie
{

    // Use this for initialization
    public override void Start()
    {

        base.Start();
        anim.SetInteger("AddNo", addNo);


    }

    // Update is called once per frame
    void Update()
    {

    }
}
