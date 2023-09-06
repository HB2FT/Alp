using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameController menuController;

    public void btn_Resume()
    {
        menuController.HideMenu();
    }

    public void btn_MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
