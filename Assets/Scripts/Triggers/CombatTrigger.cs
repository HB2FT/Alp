using Mir;
using Mir.Entity;
using Mir.Entity.PlayerUtilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTrigger : MonoBehaviour
{
    private AtomicBoolean once;

    public AudioSource combatSound_Infected;

    public _Player player;
    public GameObject cutCam, mainCam;
    public FirstCombatSceneController firstCombatSceneController;

    // Start is called before the first frame update
    void Start()
    {
        once = new AtomicBoolean(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name == "Player")
        {
            if (once.Value)
            {
                FirstFightSceneManager.Instance.StartScene();
            }
        }
    }

    private void StartCombatCutScene()
    {
        cutCam.SetActive(true);
        mainCam.SetActive(false);
        //player.isControllable = false;
        PlayerMovement.CanMove = false;
        player.Animator.SetBool("IsRunning", false);


    }

    
}
