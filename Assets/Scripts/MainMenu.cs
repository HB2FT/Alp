using System;
using System.Collections;
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
        Time.timeScale = 1.0f;

        music.Play(session, false);

        Debug.Log("MainMenu Started");
    }

    void Update()
    {

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

        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);

        //StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        yield return SceneManager.LoadSceneAsync("SampleScene");
        StartCoroutine(UnloadSceneAsync(SceneManager.GetActiveScene().name));
    }

    IEnumerator UnloadSceneAsync(string sceneName)
    {
        yield return SceneManager.UnloadSceneAsync(sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
