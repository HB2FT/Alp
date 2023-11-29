using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameController menuController;
    public GameObject loadingScreen;

    private AtomicBoolean once = new AtomicBoolean(true);

    public void btn_Resume()
    {
        menuController.HideMenu();
    }

    public void btn_MainMenu()
    {
        loadingScreen.SetActive(true);

        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);

        //StartCoroutine(Load("MainMenu"));
    }

    IEnumerator Load(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName);
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
    }
}
