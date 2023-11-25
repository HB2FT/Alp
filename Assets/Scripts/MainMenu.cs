using System;
using System.Collections;
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
        //Animator = GetComponent<Animator>();
        Animator.speed = 1.0f;
        Animator.Play("Loop", 0, 1f);

        music.Play(session, false);

        Debug.Log("MainMenu Started");
    }

    void Update()
    {
        Animator.speed = 1.0f;

        if (!music.isPaused && music.isEnded)
        {
            try
            {
                music.PlayNext(false);

            }
            catch (IndexOutOfRangeException)
            {
                Debug.Log("Oynatýlacak müzik kalmadý. Baþa sarýlýyor.");

                music.Play(session, false);
            }
        }
    }

    private void OnDisable()
    {
        
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
