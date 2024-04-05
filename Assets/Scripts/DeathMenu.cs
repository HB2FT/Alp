using Mir.Entity;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public _Player player;
    public GameObject playerPrefab;

    public void btn_MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void btn_Retry()
    {
        if (player.latestCheckPoint != null)
        {
            string[] saveContents =
            {
                player.latestCheckPoint.position.x.ToString(),
                player.latestCheckPoint.position.y.ToString()
            };
            File.WriteAllLines("saved.game", saveContents);
        }

        SceneManager.LoadScene("SampleScene");
    }
}
