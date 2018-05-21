using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour {

    float volume;
    [SerializeField]AudioSource source;

    public void SaveSliderValue()
    {
        volume = source.volume;
        PlayerPrefs.SetFloat("SliderVolumeLevel", volume);
    }

}
