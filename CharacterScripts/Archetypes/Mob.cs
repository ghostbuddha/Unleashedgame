using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : Baddie
{
    [SerializeField] protected int mobNo;
    

    public override void Start()
    {

        base.Start();

        mobNo = int.Parse(Find_id(nameof).mobno);

        anim.SetInteger("MobNo", mobNo);


    }

    // Update is called once per frame
    void Update()
    {

    }
}
