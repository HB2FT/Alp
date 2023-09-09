using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject LoadingScreen;

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
                Debug.Log("Oynatýlacak müzik kalmadý. Baþa sarýlýyor.");

                music.Play(session, false);
            }
        }
    }

    public void StartGame()
    {
        LoadingScreen.SetActive(true);

        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        yield return SceneManager.LoadSceneAsync("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
