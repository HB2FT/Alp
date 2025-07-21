using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mir.Managers
{
    public class CutSceneClips : MonoBehaviour
    {
        [field: Header("Cut Scene")]
        [field: SerializeField] public AnimationClip bossFightClip { get; private set; }
        [field: SerializeField] public AnimationClip firstFightClip { get; private set; }

        public static CutSceneClips instance { get; private set; }

        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogError("Found more than one Cut Scene Clips in the scene.");
            }
            instance = this;
        }
    }
}