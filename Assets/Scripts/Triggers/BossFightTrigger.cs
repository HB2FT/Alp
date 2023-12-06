using Mir.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mir.Triggers
{
    public class BossFightTrigger : MonoBehaviour
    {
        private AtomicBoolean once = new AtomicBoolean(true);

        public Animator animator;

        public BossFightController bossFightController;

        public GameObject cutCam, mainCam;
        public Player player;

        void Start()
        {

        }

        void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.name == "Player")
            {
                if (once.Value)
                {
                    //cutCam.GetComponent<Animator>().SetBool("bossFight", true);
                    //bossFightController.combatStarted = true;
                    //StartCutScene();

                    CutSceneManager.instance.PlayScene(new Objects.BossFightCutScene());
                }
            }
        }

        private void StartCutScene()
        {
            cutCam.SetActive(true);
            mainCam.SetActive(false);
            player.isControllable = false;
            player.Animator.SetBool("IsRunning", false);
            animator.SetBool("bossFight", true);
        }
    }

}