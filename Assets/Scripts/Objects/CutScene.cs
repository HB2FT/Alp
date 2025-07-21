using Mir.Managers;
using UnityEngine;

namespace Mir.Objects
{
    public class CutScene
    {
        protected float time { get; set; }

        public CutSceneManager cutSceneManager;

        public virtual void OnStart(CutSceneManager cutSceneManager)
        {
            this.cutSceneManager = cutSceneManager;
        }

        public virtual void OnUpdate()
        {
            time += Time.deltaTime;
        }

        public virtual void OnExit()
        {
            time = 0;

            CutSceneManager.instance.ClearCurrentScene();
        }
    }
}
