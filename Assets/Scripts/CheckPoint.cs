using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

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

            if (_player.latestCheckPoint != transform)
                ShowDialog();

            _player.latestCheckPoint = transform;
        }
    }

    void ShowDialog()
    {
        bottomBarController.PlayScene(checkpointSetDialog);
    }

    private void SetCheckPoint(Player player) 
    {
        bool tutorialCompleted;
        float playerX, playerY;
        int cameraYAxisOffset;

        tutorialCompleted = true;
        playerX = player.transform.position.x;
        playerY = player.transform.position.y;
        cameraYAxisOffset = gameCamera.yOffset;

        Save(new SavedState(tutorialCompleted, playerX, playerY, cameraYAxisOffset));

        string content = LABEL_TUTORIAL + tutorialCompleted + "\n"
                        + LABEL_PLAYERX+ playerX + "\n" + LABEL_PLAYERY + playerY + "\n"
                        + LABEL_CAMERA_Y_AXIS_OFFSET + cameraYAxisOffset + "\n";

        File.WriteAllText("Save.alp", content);
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
