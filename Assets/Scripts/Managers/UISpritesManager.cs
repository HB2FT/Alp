using Mir.Input;
using System;
using System.Linq;
using UnityEngine;

namespace Mir.Managers
{
    public class UISpritesManager : MonoBehaviour
    {

        public static UISpritesManager Instance;

        private void Awake()
        {
            if (Instance != null) Debug.LogError("Found more than one UI Sprites Manager in the scene.");

            Instance = this;
        }

        [SerializeField] private string path;

        private void Start()
        {
                       
        }

        public Sprite LoadSprite(UISprite sprite)
        {
            UISprite.SpritePath spritePath = sprite.GetSpritePath();
            Sprite[] sprites = Resources.LoadAll(spritePath.Path, typeof(Sprite)).Cast<Sprite>().ToArray();

            foreach (Sprite spr in sprites)
            {
                if (spr.name.Equals(spritePath.Name)) return spr;
            }

            throw new NullReferenceException("Sprite bulunamadý: " + spritePath.Path + ", " + spritePath.Name);
        }

        
    }

    public class UISprite
    {
        public SpritePath ValueKeyboard { get; private set; }
        public SpritePath ValueGamepad { get; private set; }
        private UISprite(SpritePath valueKeyboard, SpritePath valueGamepad)
        {
            this.ValueKeyboard = valueKeyboard;
            this.ValueGamepad = valueGamepad;
        }

        /**
         * Returns sprite path and name related to input type (gamepad or keyboard)
         */
        public SpritePath GetSpritePath()
        {
            if (InputManager.instance.IsGamepad)
            {
                Debug.Log("Loading: " + ValueGamepad.Path);
                return ValueGamepad;
            }

            else
            {
                return ValueKeyboard;
            }
        }

        public static UISprite INTERACTION_BUTTON { get { return new UISprite(new SpritePath("Sprites/UI/keyboard-buttons", "keyboard-buttons_x"), new SpritePath("Sprites/UI/ps4-buttons", "ps4-buttons_x")); } }

        public class SpritePath
        {
            public string Path { get; private set; }
            public string Name { get; private set; }

            public SpritePath(string path, string name)
            {
                this.Path = path;
                this.Name = name;
            }
        }
    }
}
