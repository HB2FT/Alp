using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceSoundController : MonoBehaviour
{
    public MusicSession session;
    public Music music;

    public float delay;

    public bool started;

    void Start()
    {
        StartCoroutine(PlayFirst(delay));
    }

    void Update()
    {
        if (started && music.clipEnded)
        {
            StartCoroutine(Play(delay));
        }
    }

    IEnumerator PlayFirst(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (music.clipEnded) music.Play(session, false); started = true;
    }

    IEnumerator Play(float delay)
    {
        yield return new WaitForSeconds(delay);

        try
        {
            if (music.clipEnded) music.PlayNext(false);
        }
        catch (Exception)
        {
            Debug.Log("GameController.AmbienceSoundController.cs: Oynatýlacak bir þey kalmadý. Baþa sarýlýyor.");

            music.Play(session, false);
        }
    }
}
