using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add : Baddie
{
    [SerializeField] protected int addNo;


    public override void Start()
    {

        base.Start();

        addNo = int.Parse(Find_id(nameof).addno);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
