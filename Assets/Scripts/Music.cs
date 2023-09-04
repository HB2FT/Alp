using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource audioSource;
    public bool isPaused;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Pause() 
    { 
        audioSource.Pause();
        isPaused = true;
    }

    public void Resume()
    {
        audioSource.UnPause();
        isPaused = false;
    }
}
