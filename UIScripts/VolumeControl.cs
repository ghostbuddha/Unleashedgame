using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource), typeof(AudioSource))]
public class VolumeControl : MonoBehaviour {

    
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // get the float value of SliderVolumeLevel if it has been saved with PlayerPrefs.SetFloat()
        // else use defult value of audioSource.volume
        audioSource.volume = PlayerPrefs.GetFloat("SliderVolumeLevel", audioSource.volume);
    }
}
