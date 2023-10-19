using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour // Player'ın etkileşimlerini, konumlarını kontrol eder
{
    public Player player;
    public StorySceneManager StorySceneManager;

    public GameObject bottomBar;

    public TextMeshProUGUI elixirText;

    public int remainingElixir;

    public const float worldBorderY = -25f;

    private AtomicBoolean atomicBool = new AtomicBoolean(true);

    void Start()
    {
        
    }

    void Update()
    {
        if (player.gameObject.transform.position.y < worldBorderY) player.health = 0;

        player.isControllable = !bottomBar.activeSelf;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (player.health < 100 && remainingElixir > 0)
            {
                player.Animator.SetTrigger("Healing");

                remainingElixir--;
            }

            elixirText.text = "x" + remainingElixir;
        }
    }
}
