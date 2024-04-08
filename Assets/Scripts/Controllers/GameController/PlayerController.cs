using Mir.Entity;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour // Player'ın etkileşimlerini, konumlarını kontrol eder
{
    public _Player player;
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

        //player.isControllable = !bottomBar.activeSelf;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (player.health < 100 && remainingElixir > 0)
            {
                player.Animator.SetBool("IsHealing", true);

                remainingElixir--;
            }

            elixirText.text = "x" + remainingElixir;
        }
    }
}
