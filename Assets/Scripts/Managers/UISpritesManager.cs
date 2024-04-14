using System;
using UnityEngine;

namespace Mir
{
    public class UISpritesManager : MonoBehaviour
    {
        public bool isGamepad;

        public static UISpritesManager Instance;

        private void Awake()
        {
            if (Instance != null) Debug.LogError("Found more than one UI Sprites Manager in the scene.");

            Instance = this;
        }

        private void Start()
        {
            GameEventsManager.instance.onGamepadConnected += GamepadConnected;
            GameEventsManager.instance.onGamepadDisconnected += GamepadDisconnected;

            Sprite sprite = LoadSprite("Sprites/Arrow/ok");
            if (sprite == null)
            {
                Debug.LogError("Sprite boþtu");
            }
        }

        public Sprite LoadSprite(string name)
        {
            return Resources.Load(name) as Sprite;
        }

        private void GamepadConnected()
        {
            if (isGamepad) Debug.LogWarning("Birden fazla kontrolcü algýlandý.");
            isGamepad = true;
        }

        private void GamepadDisconnected()
        {
            if (!isGamepad) Debug.LogError("Bilinmeyen bir hata meydana gelid.");
            isGamepad = false;
        }
    }
}
