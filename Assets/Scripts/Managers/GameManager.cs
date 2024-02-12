using FMOD.Studio;
using Mir.Audio.Oba;
using Mir.Input;
using UnityEngine;

namespace Mir.Managers
{
    public class GameManager : MonoBehaviour
    {
        private bool paused = false;

        void Start()
        {
            //
            // Temporary codes. Usually for testing new features.
            //
        }

        void Update()
        {
            HandleBackPressed();
        }

        private void HandleBackPressed()
        {
            if (InputManager.instance.GetBackPressed())
            {
                paused = !paused;

                HandlePauseAndResume();
            }
        }

        private void HandlePauseAndResume()
        {
            if (paused)
            {
                GameEventsManager.instance.OnGamePause();
            }

            if (!paused)
            {
                GameEventsManager.instance.OnGameResume();
            }
        }
    }
}
