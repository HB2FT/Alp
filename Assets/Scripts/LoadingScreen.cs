using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    public GameObject loadingScreen;

    public void LoadScene()
    {
        loadingScreen.SetActive(true);
        Debug.Log("Set active");

        StartCoroutine(Load("MainMenu"));

        
    }

    IEnumerator Load(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName);
    }
}
