using Mir.Objects;
using UnityEngine;

namespace Mir.Managers
{
    public class CutSceneManager : MonoBehaviour
    {
        private CutScene currentScene;

        public static CutSceneManager instance { get; private set; }

        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogError("Found more than one Cut Scene Manager in the scene.");
            }
            instance = this;
        }

        private void Update()
        {
            if (currentScene != null)
                currentScene.OnUpdate();
        }

        public void PlayScene(CutScene scene)
        {

            if (currentScene != null) 
                currentScene.OnExit();

            currentScene = scene;

            if (currentScene != null)
                currentScene.OnStart(this);
        }
    }
}