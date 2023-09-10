using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource audioSource;
    public MusicSession session;

    public bool isPaused;
    public bool isEnded;
    public int index;

    public bool started;
    public bool clipEnded;

    private void Update()
    {
        if (started)
        {
            if (audioSource.time == session.clips[index].length)
            {
                isEnded = true;
            }

            if (index == session.clips.Count - 1) // If last clip
            {
                if (audioSource.time == session.clips[index].length) // Last clip ended
                {
                    Stop();
                }
            }

            if (audioSource.time == session.clips[index].length)
            {
                clipEnded = !audioSource.loop;
            }
        }
    }

    public void Play(MusicSession session, bool loop)
    {
        if (session != null)
        {
            this.session = session;
            isEnded = false;
            index = 0;
            started = true;

            audioSource.clip = session.clips[index];
            audioSource.loop = loop;
            audioSource.Play(); 
        }
    }

    public void Stop()
    {
        session = null;
        isPaused = false;
        isEnded = false;
        started = false;
        clipEnded = true;
        index = 0;
        audioSource.Stop();
    }

    public void PlayNext(bool loop)
    {
        isEnded = false;

        audioSource.clip = session.clips[++index];
        audioSource.loop = loop;
        audioSource.Play();
    }

    public void PlayLast(bool loop)
    {
        isEnded = false;

        audioSource.clip = session.clips[session.clips.Count - 1];
        audioSource.loop = loop;
        audioSource.Play();
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
