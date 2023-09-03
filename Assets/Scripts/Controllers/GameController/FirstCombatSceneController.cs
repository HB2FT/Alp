using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class FirstCombatSceneController : MonoBehaviour
{
    public List<�c�> �c�ler;
    public Player player;
    public AudioSource sceneMusic;
    
    public AudioClip musicIn, musicMain, musicOut;
    public int clipIndex = 0;

    public int �c�Number;
    private AtomicBoolean atomicBoolean;

    public bool combatStarted = false;

    void Start()
    {
        �c�Number = �c�ler.Count;
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

        sceneMusic.clip = musicOut;
        sceneMusic.loop = false;
        sceneMusic.Play();

        combatStarted = false;
    }
}
