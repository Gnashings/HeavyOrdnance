using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandomizer : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> audioClips;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = audioClips[Random.Range(0, audioClips.Count)];
        audioSource.Play();
    }

}
