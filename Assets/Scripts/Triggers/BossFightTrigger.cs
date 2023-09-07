using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                bossFightController.combatStarted = true;
                StartCutScene();
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
