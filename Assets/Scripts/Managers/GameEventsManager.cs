using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager instance {  get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Game Event Manager in the scene.");
        }
        instance = this;
    }

    public event Action onPlayerDeath;
    public void OnPlayerDeath()
    {
        if (onPlayerDeath != null)
        {
            onPlayerDeath();
        }
    }

    public event Action onGamePause;
    public void OnGamePause()
    {
        if (onGamePause != null)
        {
            onGamePause();
        }
    }

    public event Action onGameResume;
    public void OnGameResume()
    {
        if (onGameResume != null)
        {
            onGameResume();
        }
    }
}
