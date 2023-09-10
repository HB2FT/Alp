using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightController : MonoBehaviour
{
    public bool combatStarted;

    public Tepegöz tepegöz;
    public Player player;

    public MusicSession session;
    public Music music;

    private AtomicBoolean once1 = new AtomicBoolean(true);
    private AtomicBoolean once2 = new AtomicBoolean(true);
    private AtomicBoolean once3 = new AtomicBoolean(true);

    void Start()
    {
        
    }

    void Update()
    {
        if (combatStarted && once1.Value)
        {
            music.Play(session, false);
        }

        if (music.clipEnded && once3.Value)
        {
            music.PlayNext(false);
        }

        if (tepegöz.health <= 0 && once2.Value) OnEndBossFight();
    }

    public void OnEndBossFight()
    {
        music.PlayLast(false);

        combatStarted = false;
    }
}
