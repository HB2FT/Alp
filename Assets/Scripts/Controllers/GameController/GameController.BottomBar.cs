using Mir.Controllers;
using UnityEngine;

partial class GameController // Bottom Bar etkinliklerini kontrol eder
{
    public StoryScene currentScene;
    public BottomBarController bottomBar;

    void BottomBarStart()
    {
        //bottomBar.PlayScene(currentScene);
        currentScene = bottomBar.currentScene;
    }

    void BottomBarUpdate()
    {
        //if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        //{
        //    if (bottomBar.IsCompleted())
        //    {
        //        if (bottomBar.IsLastSentence())
        //        {
        //            currentScene = bottomBar.currentScene.nextScene;
        //            bottomBar.PlayScene(currentScene);
        //        }
        //        else
        //        {
        //            bottomBar.PlayNextScene();
        //        }
        //    }
        //}
    }
}
