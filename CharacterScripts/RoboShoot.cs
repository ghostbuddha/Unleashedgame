using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboShoot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D other) { 
            if (other.gameObject.CompareTag("Player"))
            {
                //Application.LoadLevel("death");
            }
        }
}
