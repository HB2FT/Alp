using FMOD.Studio;
using Mir.Audio.Dag;
using Mir.Entity;
using Mir.Managers;
using Mir.Objects;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class BossFightSceneManager : MonoBehaviour
{
    // audio
    private EventInstance sceneMusic;

    // animation
    private AnimationClip sceneCameraAnimation;

    public static BossFightSceneManager instance {  get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Found more than one Boss Fight Scene Manager in the scene.");
        }
        instance = this;
    }

    public void StartScene()
    {
        PlayMusic();

        DisablePlayer();

        PlayCameraAnimation();
    }

    void PlayCameraAnimation()
    {
        CutSceneManager.instance.PlayScene(new BossFightCutScene());
    }

    void DisablePlayer()
    {
        _Player.instance.CanMove = false;
    }

    void PlayMusic()
    {
        // initialize music
        sceneMusic = AudioManager.instance.CreateEventInstance(MusicEvents.instance.bossFight);
        
        // play music
        sceneMusic.start();
    }
}
