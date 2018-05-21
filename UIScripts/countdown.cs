﻿using UnityEngine;
using System.Collections;
 
public class countdown : MonoBehaviour {
 
    public float countStart;
    public float countCurrent;
 
    // Use this for initialization
    void Start() {
        countCurrent = countStart;
    }
 
    // Update is called once per frame
    void Update() {
        countCurrent -= Time.deltaTime;
    }
}