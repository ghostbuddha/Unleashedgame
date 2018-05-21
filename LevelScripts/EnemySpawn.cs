using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public GameObject Robo;
    public Transform roboSpawn;

    void Start()
    {

        Spawn();
    }

    void Spawn()
    {
        int coinFlip = Random.Range(0, 2);
        if (coinFlip < 1)
        {
            Instantiate(Robo, roboSpawn.position, Quaternion.identity);
        }
        
    }
}
