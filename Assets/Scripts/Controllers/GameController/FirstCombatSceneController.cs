using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class FirstCombatSceneController : MonoBehaviour
{
    public List<Öcü> öcüler;
    public Player player;
    public AudioSource sceneMusic;
    
    public AudioClip musicIn, musicMain, musicOut;
    public int clipIndex = 0;

    public int öcüNumber;
    private AtomicBoolean atomicBoolean;

    public bool combatStarted = false;

    void Start()
    {
        öcüNumber = öcüler.Count;
        atomicBoolean = new AtomicBoolean(true);

        
    }

    void Update()
    {
        if (!sceneMusic.isPlaying && combatStarted)
        {
            clipIndex++;

            if (clipIndex == 1)
            {
                sceneMusic.clip = musicMain;
                sceneMusic.loop = true;
                sceneMusic.Play();
            }

           
        }

        for (int i = 0; i < öcüNumber; i++)
        {
            if (öcüler.Count == 0) break;

            Öcü currentÖcü = öcüler[i];

            if (currentÖcü.health <= 0)
            {
                öcüler.RemoveAt(i);
            }
        }
         
        if (öcüler.Count == 0 && atomicBoolean.Value) OnEndCombat();
       
    }

    private void OnEndCombat()
    {
        Debug.Log("OnEndCombat1");

        sceneMusic.clip = musicOut;
        sceneMusic.loop = false;
        sceneMusic.Play();

        combatStarted = false;
    }
}
