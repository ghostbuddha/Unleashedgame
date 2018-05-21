using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour {

    public static int numLives;
    public int curLives;


	// Use this for initialization
	void Start () {
        //var instruction = GetComponent<Text>();
        curLives = numLives;
        //instruction.text = "x " + curLives;
    }
	
	// Update is called once per frame
	void Update () {
    }
}
