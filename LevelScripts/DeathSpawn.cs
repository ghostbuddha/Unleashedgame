using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSpawn : MonoBehaviour {

    public GameObject deathTrigger;
    public Transform deathSpawn;

	void Start () {

        Spawn();
	}
	
	void Spawn()
    {
        Instantiate(deathTrigger, deathSpawn.position, Quaternion.identity);
    }
}
