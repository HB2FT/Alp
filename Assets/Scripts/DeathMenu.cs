using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public void btn_MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void btn_Retry()
    {
        //SceneManager.LoadScene("SampleScene");
        Application.LoadLevel(Application.loadedLevel);
    }
}
