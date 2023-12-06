using FMOD.Studio;
using FMODUnity;
using Mir.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mir.Objects
{
    public class CutCam : MonoBehaviour
    {
        public GameObject cutCam, mainCam;
        public Player player;

        public Music music;

        public BottomBarController bottomBarController;
        public StoryScene bossFightStoryScene;

        private Animator animator;

        public static CutCam instance { get; private set; }

        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogError("Found more than one Cut Cam in the scene.");
            }
            instance = this;
        }

        private void Start()
        {
            animator = GetComponent<Animator>();

            gameObject.SetActive(false);
        }

        public void PlayAnimation(AnimationClip cutSceneClip)
        {
            animator.Play(cutSceneClip.name);
        }
    }
}
