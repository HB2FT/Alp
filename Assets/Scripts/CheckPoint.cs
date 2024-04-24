using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using Mir.Controllers;
using Mir.Serialization;
using Mir.Entity;

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

    private void Start()
    {
        if (gameCamera == null) gameCamera = GameCamera.instance;
    }

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
        if (checkpointSetDialog == null)
        {
            Debug.LogWarning("Check point ayarland���nda oynat�lacak diyalog bo�tu!");
            return;
        }
        bottomBarController.PlayScene(checkpointSetDialog);
    }

    private void SetCheckPoint() 
    {
        // Get variables to save
        int cameraYAxisOffset = GameCamera.instance.yOffset;
        float playerX = _Player.instance.transform.position.x;
        float playerY = _Player.instance.transform.position.y;

        SavedGame savedGame = new SavedGame(
            cameraYAxisOffset,
            playerX,
            playerY);

        savedGame.Serialize();

        string str = "Oyun kaydedildi -> " + SAVE_FILE + "\n"
            + "Camera y axis offset: " + cameraYAxisOffset + "\n"
            + "Player X: " + playerX + "\n"
            + "Player Y: " + playerY;

        Debug.Log(str);
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
