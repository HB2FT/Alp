using FMOD.Studio;
using Mir.Audio.Dag;
using Mir.Managers;

namespace Mir.Objects
{
    public class BossFightCutScene : CutScene
    {
        private EventInstance music;

        float duration = 6.483f;

        public override void OnStart(CutSceneManager cutSceneManager)
        {
            base.OnStart(cutSceneManager);

            GameCamera.instance.gameObject.SetActive(false);
            CutCam.instance.gameObject.SetActive(true);

            CutCam.instance.PlayAnimation(CutSceneClips.instance.bossFightClip);

            music = Audio.Oba.AudioManager.instance.CreateEventInstance(Audio.Oba.MusicEvents.instance.bossFightMusic);
            music.start();

            _Player.instance.CanMove = false;
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

            _Player.instance.CanMove = true;
        }
    }
}
