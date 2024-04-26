using Mir.Entity;
using System;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour // Player'ın etkileşimlerini, konumlarını kontrol eder
{
    [Obsolete("Use '_Player.instance' instead.")] public _Player player;
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
        if (_Player.instance.gameObject.transform.position.y < worldBorderY) _Player.instance.health = 0;

        //player.isControllable = !bottomBar.activeSelf;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_Player.instance.health < _Player.instance.maxHealth && remainingElixir > 0)
            {
                _Player.instance.Animator.SetBool("IsHealing", true);

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
