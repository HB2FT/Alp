using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CheckPoint : MonoBehaviour
{
    public static string LABEL_TUTORIAL = "tutorialCompleted:";
    public static string LABEL_PLAYERX = "playerX:";
    public static string LABEL_PLAYERY = "playerY:";
    public static string LABEL_CAMERA_Y_AXIS_OFFSET = "cameraYAxisOffset:";

    public GameCamera gameCamera;

    void Update()
    {
        
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            SetCheckPoint(player);
        }
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

        string content = LABEL_TUTORIAL + tutorialCompleted + "\n"
                        + LABEL_PLAYERX+ playerX + "\n" + LABEL_PLAYERY + playerY + "\n"
                        + LABEL_CAMERA_Y_AXIS_OFFSET + cameraYAxisOffset + "\n";

        File.WriteAllText("Save.alp", content);
    }
}
