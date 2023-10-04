using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject LoadingScreen;
    
    public Animator Animator;

    public Music music;
    public MusicSession session;

    private AtomicBoolean playable = new AtomicBoolean(true);

    void Start()
    {
        Animator = GetComponent<Animator>();
        Animator.speed = 1.0f;
        Animator.Play("Loop");

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
