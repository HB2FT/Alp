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
            SavedGame savedGame = SavedGame.Deserialize();

            GameCamera.instance.yOffset = savedGame.GetData().CameraYAxisOffset;

            string msg = "Camera y offset: " + savedGame.GetData().CameraYAxisOffset + "\n" +
                    "Player x: " + savedGame.GetData().PlayerX + "\n" +
                    "Player y: " + savedGame.GetData().PlayerY + "\n";
            Debug.Log(msg);

            Vector3 playerLocation = new Vector3(
                savedGame.GetData().PlayerX,
                savedGame.GetData().PlayerY);

            _Player.instance.transform.position = playerLocation;
        }

        public static void SaveGame()
        {
            int cameraYAxisOffset = GameCamera.instance.yOffset;
            float playerX = _Player.instance.transform.position.x;
            float playerY = _Player.instance.transform.position.y;

            // Create Header section of file
            SavedGame.Header header = new SavedGame.Header(SavedGame.Header.MAGIC_NUMBER);

            // Create Data section of file
            SavedGame.Data data = new SavedGame.Data(cameraYAxisOffset, playerX, playerY);

            // Create file
            SavedGame savedGame = new SavedGame(header, data);

            // Serialize file
            savedGame.Serialize();
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
