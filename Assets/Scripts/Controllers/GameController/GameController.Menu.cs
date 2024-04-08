using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

partial class GameController
{
    public GameObject cutCam;

    public PostProcessVolume postProcessVolume;

    public PostProcessProfile pauseMenuProfile;

    public GameObject pauseMenu;

    public Music music;

    private bool IsMenuOpen = false;

    void MenuUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && !player.IsDead)
        {
            if (!IsMenuOpen) // Esc basıldığında manü açık değilse (menü açılır)
            {
                //ShowMenu();
                
            }

            else // Esc basıldığında menü açıksa (menü kapatılır)
            {
                //HideMenu();

                
            }
        }
    }

    public void ShowMenu()
    {
        pauseMenu.SetActive(true);

        VisualEffectsManager.instance.SetCurrentProfile(VisualEffects.instance.pauseMenuVisualEffect);

        Time.timeScale = 0f;

        IsMenuOpen = !IsMenuOpen;
    }

    public void HideMenu()
    {
        pauseMenu.SetActive(false);
        postProcessVolume.enabled = false;
        //player.isControllable = true;
        music.Resume();

        Time.timeScale = 1f;

        IsMenuOpen = !IsMenuOpen;
    }
}

