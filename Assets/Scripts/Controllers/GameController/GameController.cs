using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public partial class GameController : MonoBehaviour // Oyunu genel hatlarýyla kontrol eder
{
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        //if (bottomBar.Enabled) BottomBarStart();
        HealthBarStart();

        Debug.Log("GameController");
        InputSystem.onDeviceChange += InputUser_onChange;
    }

    void Update()
    {
        if (bottomBar.Enabled && bottomBar.StartOnce) BottomBarStart();

        if (bottomBar.Enabled) BottomBarUpdate();
        HealthBarUpdate();
        MenuUpdate();

       


    }

    private void InputUser_onChange(InputDevice device, InputDeviceChange change)
    {
        Debug.Log("InputDevice Display Name:" + device.displayName);
        
        if (device.displayName.Equals("Wireless Controller"))
        {
            if (change == InputDeviceChange.Reconnected || change == InputDeviceChange.Added)
            {
                Debug.Log("Kontrolcü algýlandý: " + device.displayName);

                GameEventsManager.instance.OnGamepadConnected();
            }
            
            if (change == InputDeviceChange.Disconnected || change == InputDeviceChange.Removed)
            {
                Debug.Log("Kontrolcü çýkarýldý: " + device.displayName);

                GameEventsManager.instance.OnGamepadDisconnected();
            }
        }

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadMode)
    {

    }
}