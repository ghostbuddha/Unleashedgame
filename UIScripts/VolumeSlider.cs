using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class VolumeSlider : MonoBehaviour {

    float volume = 0.5f; // AudioSource.volume will have a value 0.0f to 1.0f
    void SaveSliderValue()
    {
        PlayerPrefs.SetFloat("SliderVolumeLevel", volume);
    }

}
