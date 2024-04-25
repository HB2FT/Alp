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

    public static PlayerController instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Player CController in the scene.");
        }
        instance = this;
    }

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

                _Player.instance.health = _Player.instance.maxHealth;

                RemainingElixir--;
            }
        }
    }

    public int RemainingElixir
    {
        set
        {
            remainingElixir = value;
            elixirText.text = "x" + remainingElixir;
        }

        get
        {
            return remainingElixir;
        }
    }
}
