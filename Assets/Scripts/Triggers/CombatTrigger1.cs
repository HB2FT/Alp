using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTrigger1 : MonoBehaviour
{
    public AudioSource combatSound_Infected;
    private AtomicBoolean Playable;

    public Player player;
    public GameObject cutCam, mainCam;

    // Start is called before the first frame update
    void Start()
    {
        Playable = new AtomicBoolean(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            if (Playable.Value)
            {
                combatSound_Infected.Play();

                StartCombatCutScene();
            }
        }
    }

    private void StartCombatCutScene()
    {
        cutCam.SetActive(true);
        mainCam.SetActive(false);
        player.isControllable = false;
        player.Animator.SetBool("IsRunning", false);


    }

    
}
