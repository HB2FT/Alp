using Mir.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameController menuController;
    public GameObject loadingScreen;

    [SerializeField] private GameObject menu;

    private void Start()
    {
        GameEventsManager.instance.onGamePause += Show;
        GameEventsManager.instance.onGameResume += Hide;
    }

    private void ToggleMenu()
    {
        // menu ON
        if(menu.gameObject.activeInHierarchy)
        {
            Hide();
        }
        // menu OFF
        else
        {
            Show();
        }
    }

    private void Show()
    {
        VisualEffectsManager.instance.SetCurrentProfile(VisualEffects.instance.pauseMenuVisualEffect);
        VisualEffectsManager.instance.weight = 1;

        menu.gameObject.SetActive(true);
        //Time.timeScale = 0f;
    }

    private void Hide()
    {
        VisualEffectsManager.instance.weight = 0;

        menu.gameObject.SetActive(false);
        //Time.timeScale = 1.0f;
    }

    public void btn_Resume()
    {
        Hide();
    }

    public void btn_MainMenu()
    {
        Hide();

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
