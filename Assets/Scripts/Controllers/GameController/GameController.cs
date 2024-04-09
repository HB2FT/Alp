using UnityEngine;
using UnityEngine.InputSystem.Users;
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

        InputUser.onChange += InputUser_onChange;


    }

    private void InputUser_onChange(InputUser arg1, InputUserChange arg2, UnityEngine.InputSystem.InputDevice arg3)
    {
        Debug.Log("InputDevice Name:" + arg3.name);
        Debug.Log("InputDevice Display Name:" + arg3.displayName);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadMode)
    {

    }
}