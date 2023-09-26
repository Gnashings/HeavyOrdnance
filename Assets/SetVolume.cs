using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;

    private void Start()
    {
        if (PlayerProgress.vol == 0)
        {
            PlayerProgress.vol = 1;
        }
        else
            slider.value = PlayerProgress.vol;
    }

    public void SetLevel(float value)
    {
        PlayerProgress.vol = value;
        mixer.SetFloat("TotalVolume", Mathf.Log10(value) * 20 ) ;
    }
}
