using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

partial class GameController
{
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
        /// TODO: Create game menu and show it via this method
    }

    private void HideMenu()
    {
        /// TODO: Create game menu and hide it via this method
    }
}

