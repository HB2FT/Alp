﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

partial class GameController
{
    public GameObject cutCam;

    public PostProcessVolume postProcessVolume_BackgroundBlur;
    public GameObject pauseMenu;

    public Music music;

    private bool IsMenuOpen = false;

    void MenuUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!IsMenuOpen) // Esc basıldığında manü açık değilse (menü açılır)
            {
                ShowMenu();
                Time.timeScale = 0f;

                IsMenuOpen = !IsMenuOpen;
            }

            else // Esc basıldığında menü açıksa (menü kapatılır)
            {
                HideMenu();

                Time.timeScale = 1f;

                IsMenuOpen = !IsMenuOpen;
            }
        }
    }

    private void ShowMenu()
    {
        pauseMenu.SetActive(true);
        postProcessVolume_BackgroundBlur.enabled = true;
        player.isControllable = false;
        music.Pause();
    }

    private void HideMenu()
    {
        pauseMenu.SetActive(false);
        postProcessVolume_BackgroundBlur.enabled = false;
        player.isControllable = true;
        music.Resume();

    }
}

