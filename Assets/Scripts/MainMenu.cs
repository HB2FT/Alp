using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Music music;
    public MusicSession session;

    private AtomicBoolean playable = new AtomicBoolean(true);

    void Start()
    {
        music.Play(session, false);
    }

    void Update()
    {
        if (!music.isPaused && music.isEnded)
        {
            try
            {
                music.PlayNext(false);
            }

            catch (IndexOutOfRangeException e)
            {
                Debug.Log("Oynat�lacak m�zik kalmad�. Ba�a sar�l�yor.");

                music.Play(session, false);
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
