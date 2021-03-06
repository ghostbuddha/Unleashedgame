﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollParallax : MonoBehaviour {
    public bool scrolling, parallax;

    public float backgroundSize;
    public float ParallaxSpeed;
    private Transform cameraTransform;
    private Transform[] layers;
    private float viewZone = 10;
    private int leftIndex;
    private int rightIndex;
    private float lastCameraX;
    
	void Start () {
        cameraTransform = Camera.main.transform;
        layers = new Transform[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
            layers[i] = transform.GetChild(i);

        leftIndex = 0;
        rightIndex = layers.Length - 1;
	}
    private void Update()
    {
        if(parallax)
        {
            float deltaX = cameraTransform.position.x - lastCameraX;
            transform.position += Vector3.right * (deltaX * ParallaxSpeed);
            lastCameraX = cameraTransform.position.x;
        }
        

        if (scrolling)
        {
                if (cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone))
                    ScrollLeft();

                if (cameraTransform.position.x > (layers[rightIndex].transform.position.x - viewZone))
                    ScrollRight();
        }
        
    }
    private void ScrollLeft()
    {
        int lastRight = leftIndex;
        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backgroundSize);
        leftIndex = rightIndex;
        rightIndex--;
        if (rightIndex < 0)
            rightIndex = layers.Length - 1;
    }
    private void ScrollRight()
    {
        int lastLeft = rightIndex;
        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + backgroundSize);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == layers.Length)
            leftIndex = 0;
    }

    
    
}
