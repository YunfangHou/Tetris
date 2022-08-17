using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioClip sound;

    private AudioSource audioSource;

    public bool shouldPlay;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldPlay)
        {
           audioSource.PlayOneShot(sound,0.7f);
           shouldPlay = false;
        }
    }
}
