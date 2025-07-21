using FMOD.Studio;
using Mir.Audio.Oba;
using Mir.Managers;
using Mir.Objects;
using UnityEngine;

namespace Mir
{
    public class FirstFightSceneManager : MonoBehaviour
    {
        [field: SerializeField] private Hortlak[] hortlakList;
        [field: SerializeField] private GameObject Hortlaks;

        [field: SerializeField] public int totalHortlaks { get; private set; }
        [field: SerializeField] public int killedHortlaks;

        public EventInstance sceneMusic { get; private set; }

        public static FirstFightSceneManager Instance { get; private set; }
        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("Found more than one First Fight Scene Manager in the scene!");
            }
            Instance = this;
        }

        private void Start()
        {
            sceneMusic = AudioManager.instance.CreateEventInstance(MusicEvents.instance.firstFightMusic);

            hortlakList = Hortlaks.GetComponentsInChildren<Hortlak>();
            totalHortlaks = hortlakList.Length;
        }

        public void StartScene()
        {
            CutSceneManager.instance.PlayScene(new FirstFightCutScene());
        }

        public void StopScene()
        {
            sceneMusic.stop(STOP_MODE.ALLOWFADEOUT);
        }
    }
}
