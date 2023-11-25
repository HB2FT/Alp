using UnityEngine;
using UnityEngine.SceneManagement;

public partial class GameController : MonoBehaviour // Oyunu genel hatlarýyla kontrol eder
{
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        //if (bottomBar.Enabled) BottomBarStart();
        HealthBarStart();
    }

    void Update()
    {
        if (bottomBar.Enabled && bottomBar.StartOnce) BottomBarStart();

        if (bottomBar.Enabled) BottomBarUpdate();
        HealthBarUpdate();
        MenuUpdate();


    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadMode)
    {

    }
}