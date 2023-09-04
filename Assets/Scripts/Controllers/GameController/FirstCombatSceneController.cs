using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class FirstCombatSceneController : MonoBehaviour
{
    public Music music;

    public List<�c�> �c�ler;
    public Player player;
    public AudioSource sceneMusic;
    public MusicSession session;
    
    public AudioClip musicIn, musicMain, musicOut;
    public int clipIndex = 0;

    public int �c�Number;
    private AtomicBoolean atomicBoolean;

    public bool combatStarted = false;
    public AtomicBoolean onceCheck = new AtomicBoolean(true);

    void Start()
    {
        �c�Number = �c�ler.Count;
        atomicBoolean = new AtomicBoolean(true);
        
    }

    void Update()
    {
        if (combatStarted && onceCheck.Value)
        {
            music.audioSource.loop = false;
            music.Play(session, false);

            //music.audioSource.clip = musicIn;
            //music.audioSource.loop = false;
            //music.audioSource.Play();
        }

        if (music.isEnded && combatStarted && !music.isPaused)
        {
            /*
            clipIndex++;

            if (clipIndex == 1)
            {
                music.audioSource.clip = musicMain;
                music.audioSource.loop = true;
                music.audioSource.Play();
            }
            */

            music.PlayNext(true);
        }

        for (int i = 0; i < �c�Number; i++)
        {
            if (�c�ler.Count == 0) break;

            �c� current�c� = �c�ler[i];

            if (current�c�.health <= 0)
            {
                �c�ler.RemoveAt(i);
            }
        }
         
        if (�c�ler.Count == 0 && atomicBoolean.Value) OnEndCombat();
       
    }

    private void OnEndCombat()
    {
        Debug.Log("OnEndCombat1");

        //music.audioSource.clip = musicOut;
        music.audioSource.loop = false;
        //music.audioSource.Play();

        music.PlayNext(false);

        combatStarted = false;
    }
}
