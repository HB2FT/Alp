using Mir.Input;
using Mir.Serialization;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Mir.Managers
{
    public class GameManager : MonoBehaviour
    {
        private bool paused = false;

        void Start()
        {
            LoadGame();
        }

        void Update()
        {
            HandleBackPressed();
        }

        public static void LoadGame()
        {
            SavedGame savedGame = new SavedGame();

            // Check save file
            if (!savedGame.Exists) return;

            savedGame.Load();

            GameCamera.instance.yOffset = savedGame.CameraYAxisOffset;

            string msg = "Camera y offset: " + savedGame.CameraYAxisOffset + "\n" +
                    "Player x: " + savedGame.PlayerX + "\n" +
                    "Player y: " + savedGame.PlayerY + "\n";
            Debug.Log(msg);

            Vector3 playerLocation = new Vector3(
                savedGame.PlayerX,
                savedGame.PlayerY);

            _Player.instance.transform.position = playerLocation;
        }

        public static void SaveGame()
        {
            int cameraYAxisOffset = GameCamera.instance.yOffset;
            float playerX = _Player.instance.transform.position.x;
            float playerY = _Player.instance.transform.position.y;


            Debug.Log("Camera offset: " + cameraYAxisOffset);
            Debug.Log("Player X: " + playerX);
            Debug.Log("Player Y: " + playerY);
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
