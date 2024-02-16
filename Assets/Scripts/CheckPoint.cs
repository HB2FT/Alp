using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using Mir.Controllers;
using Mir.Serialization;

public class CheckPoint : MonoBehaviour
{
    public const string SAVE_FILE = "game.mir";

    public static string LABEL_TUTORIAL = "tutorialCompleted:";
    public static string LABEL_PLAYERX = "playerX:";
    public static string LABEL_PLAYERY = "playerY:";
    public static string LABEL_CAMERA_Y_AXIS_OFFSET = "cameraYAxisOffset:";

    public GameCamera gameCamera;
    public BottomBarController bottomBarController;
    public StoryScene checkpointSetDialog;

    void Update()
    {
        
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        _Player _player = collision.GetComponent<_Player>();

        if (_player != null)
        {
            //SetCheckPoint(player);

            //if (_player.latestCheckPoint != transform)
                ShowDialog();

            _player.latestCheckPoint = transform;
            SetCheckPoint();
        }
    }

    void ShowDialog()
    {
        bottomBarController.PlayScene(checkpointSetDialog);
    }

    private void SetCheckPoint() 
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

    public static SavedState Load()
    {

        SavedState savedState = null;

        try
        {
            using (FileStream fileStream = new FileStream(SAVE_FILE, FileMode.Open))
            {
                BinaryFormatter binaryFormatter = new();
                savedState = (SavedState)binaryFormatter.Deserialize(fileStream);
            }
        }
        catch (SerializationException e)
        {
            Debug.LogException(e);
        }

        return savedState;
    }

    private void Save(SavedState savedState)
    {
        try
        {
            using (FileStream fileStream = new(SAVE_FILE, FileMode.Create))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, savedState);
            }
        }
        catch (SerializationException e)
        {
            Debug.LogException(e);
        }
    }

    [Serializable]
    public class SavedState
    {
        public bool isTutorialcompleted;
        public float playerX, playerY;
        public int cameraYAxisOffset;

        public SavedState(bool isTutorialcompleted, float playerX, float playerY, int cameraYAxisOffset)
        {
            this.isTutorialcompleted = isTutorialcompleted;
            this.playerX = playerX;
            this.playerY = playerY;
            this.cameraYAxisOffset = cameraYAxisOffset;
        }
    }
}
