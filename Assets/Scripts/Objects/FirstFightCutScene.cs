
using FMOD.Studio;
using Mir.Entity.PlayerUtilities;
using Mir.Managers;
using UnityEngine;

namespace Mir.Objects
{
    public class FirstFightCutScene : CutScene
    {
        //private EventInstance music;

        float duration = 9.000f;

        public override void OnStart(CutSceneManager cutSceneManager)
        {
            base.OnStart(cutSceneManager);

            GameCamera.instance.gameObject.SetActive(false);
            CutCam.instance.gameObject.SetActive(true);

            CutCam.instance.PlayAnimation(CutSceneClips.instance.firstFightClip);

            //music = Audio.Oba.AudioManager.instance.CreateEventInstance(Audio.Oba.MusicEvents.instance.firstFightMusic);
            //music.start();

            FirstFightSceneManager.Instance.sceneMusic.start();

            PlayerMovement.CanMove = false;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (time >= duration)
            {
                OnExit();
            }
        }

        public override void OnExit()
        {
            base.OnExit();

            GameCamera.instance.gameObject.SetActive(true);
            CutCam.instance.gameObject.SetActive(false);

            PlayerMovement.CanMove = true;

            FirstFightSceneManager.Instance.sceneMusic.setParameterByName("orman-combat", 2);

            Debug.Log("FirstFightCutScene sonu");
        }
    }
}
