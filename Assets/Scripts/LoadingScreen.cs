using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    public GameObject loadingScreen;

    private AtomicBoolean atomicBoolean = new AtomicBoolean(true);

    public void LoadScene()
    {
        loadingScreen.SetActive(true);

        StartCoroutine(Load("MainMenu"));


    }

    IEnumerator Load(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName);
    }

    IEnumerator ChangeTransparency()
    {
        yield return new WaitForSeconds(10);

        StartCoroutine(ChangeTransparency());
    }
}
