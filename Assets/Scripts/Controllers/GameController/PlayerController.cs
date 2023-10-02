using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerController : MonoBehaviour // Player'ın etkileşimlerini, konumlarını kontrol eder
{
    public Player player;
    public StorySceneManager StorySceneManager;

    public const float worldBorderY = -25f;

    private AtomicBoolean atomicBool = new AtomicBoolean(true);

    void Start()
    {
        
    }

    void Update()
    {
        if (player.gameObject.transform.position.y < worldBorderY) player.health = 0;
    }
}
