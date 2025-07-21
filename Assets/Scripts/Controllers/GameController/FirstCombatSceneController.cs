using Mir.Entity;
using System.Collections.Generic;
using UnityEngine;

public class FirstCombatSceneController : MonoBehaviour
{
    public Music music;

    public List<Öcü> öcüler;
    public Player player;
    public AudioSource sceneMusic;
    public MusicSession session;
    
    public AudioClip musicIn, musicMain, musicOut;
    public int clipIndex = 0;

    public int öcüNumber;
    private AtomicBoolean atomicBoolean;

    public bool combatStarted = false;
    public AtomicBoolean onceCheck = new AtomicBoolean(true);

    void Start()
    {
        öcüNumber = öcüler.Count;
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

        for (int i = 0; i < öcüNumber; i++)
        {
            if (öcüler.Count == 0) break;

            Öcü currentöcü = öcüler[i];

            if (currentöcü.health <= 0)
            {
                öcüler.RemoveAt(i);
            }
        }
         
        if (öcüler.Count == 0 && atomicBoolean.Value) OnEndCombat();
       
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
