using Mir.Entity.PlayerUtilities;
using Mir.Input;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Mir.Controllers
{
    public class BottomBarController : MonoBehaviour
    {
        public GameObject BottomBar;

        public TextMeshProUGUI barText;
        public TextMeshProUGUI personNameText;

        private int sentenceIndex = -1;
        public StoryScene currentScene;
        [SerializeField] private State state = State.NONE;

        private AtomicBoolean startOnce = new AtomicBoolean(false);

        public static BottomBarController Instance;
        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("Found more than one Bottom Bar Controller in the scene!");
            }
            Instance = this;
        }

        private void Start()
        {
            GameEventsManager.instance.onGamePause += Pause;
            GameEventsManager.instance.onGameResume += Resume;
        }

        private void Update()
        {
            if (state != State.NONE && InputManager.instance.GetNextPressed())
            {
                StopAllCoroutines();

                if (IsLastSentence())
                {
                    PlayScene(currentScene.nextScene);
                }

                else
                {
                    PlayNextScene();
                }
            }
        }

        public bool StartOnce
        {
            get
            {
                return startOnce.Value;
            }

            set
            {
                startOnce.Value = value;
            }
        }

        public bool Enabled
        {
            get
            {
                return BottomBar.activeSelf;
            }

            set
            {
                BottomBar.SetActive(value);
                PlayerMovement.CanMove = !value;
                if (!value)
                {
                    state = State.NONE;
                }
            }
        }

        private enum State
        {
            COMPLETED, // Sentence is completed
            PLAYING, // Sentence is playing
            PAUSED, // Game is paused
            NONE // No active dialog
        }

        public void PlayScene(StoryScene scene)
        {
            Enabled = true;
            currentScene = scene;
            sentenceIndex = -1;
            PlayNextScene();
        }

        public void PlayNextScene()
        {
            try
            {
                StartCoroutine(TypeText(currentScene.sentences[++sentenceIndex].text));
                personNameText.text = currentScene.sentences[sentenceIndex].speaker.speakerName;
                personNameText.color = currentScene.sentences[sentenceIndex].speaker.textColor;
            }
            catch
            {
                Enabled = false;
            }
        }

        public bool IsCompleted()
        {
            return state == State.COMPLETED;
        }

        public bool IsLastSentence()
        {
            return sentenceIndex + 1 == currentScene.sentences.Count;
        }

        private void Pause()
        {
            if (state == State.PLAYING)
            {
                state = State.PAUSED;
            }
        }

        private void Resume()
        {
            if (state == State.PAUSED)
            {
                state = State.PLAYING;
            }
        }

        private bool IsResumed()
        {
            return state == State.PLAYING;
        }

        private IEnumerator TypeText(string text)
        {
            barText.text = "";
            state = State.PLAYING;
            int wordIndex = 0;

            while (state != State.COMPLETED)
            {
                // Wait if paused
                if (state == State.PAUSED)
                {
                    yield return new WaitUntil(IsResumed);
                }

                barText.text += text[wordIndex];
                yield return new WaitForSeconds(0.05f);

                if (++wordIndex == text.Length)
                {
                    state = State.COMPLETED;
                    break;
                }
            }
        }
    }

}