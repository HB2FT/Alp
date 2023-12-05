using FMOD;
using FMOD.Studio;
using Mir.Audio.Oba;
using Mir.Entity.Player;
using Mir.Objects.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class _Player : Entity
{
    public StateMachine stateMachine;
    public ItemSystem ItemSystem;

    [Obsolete] private int itemIndex;
    private int _itemIndex; // Temp variable for InputSystem.currentItemIndex
    [SerializeField] private int criticalHealth;

    // audio
    private EventInstance lowHealth;
    private EventInstance deathSound;

    public override void Start()
    {
        base.Start();

        stateMachine = GetComponent<StateMachine>();

        _itemIndex = 0;

        lowHealth = AudioManager.instance.CreateEventInstance(MusicEvents.instance.playerLowHealth);
        //deathSound = AudioManager.instance.CreateEventInstance(MusicEvents.instance.playerDeath);
    }

    public override void Update()
    {
        base.Update();

        if (!IsDead)
        {
            if (_itemIndex != ItemSystem.currentItemIndex)
            {
                ChangeState();
            }

            _itemIndex = ItemSystem.currentItemIndex;

            HandleLowHealth();
        }
    }

    protected override void OnDeath()
    {
        base.OnDeath();

        GameEventsManager.instance.OnPlayerDeath();

        UnityEngine.Debug.Log("player died");
    }

    private void HandleLowHealth()
    {
        PLAYBACK_STATE playbackstate;
        lowHealth.getPlaybackState(out playbackstate);

        // if health under critical health
        if (health <= criticalHealth)
        {
            // if low health effect does not playing
            if (playbackstate.Equals(PLAYBACK_STATE.STOPPED))
            {
                // play sound effect
                lowHealth.start();
            }
        }
        // otherwise health over citical health
        else
        {
            // stop sound effect
            lowHealth.stop(STOP_MODE.ALLOWFADEOUT);
        }
    }

    [Obsolete]
    public int ItemIndex
    {
        get { return itemIndex; }
        set 
        { 
            itemIndex = value;

            ChangeState();
        }
    }

    private void ChangeState()
    {
        if (ItemSystem.currentItemIndex == 0)
        {
            if (stateMachine.mainStateType.GetType() != typeof(IdleState))
            {
                stateMachine.mainStateType = new IdleState();
            }
        }

        if (ItemSystem.currentItemIndex == 1)
        {
            if (stateMachine.mainStateType.GetType() != typeof(IdleCombatState))
            {
                stateMachine.mainStateType = new IdleCombatState();
            }
        }

        if (ItemSystem.currentItemIndex == 2)
        {
            if (stateMachine.mainStateType.GetType() != typeof(IdleBowState))
            {
                stateMachine.mainStateType = new IdleBowState();
            }
        }

        stateMachine.SetNextStateToMain();
    }
}
