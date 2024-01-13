using FMOD.Studio;
using Mir.Audio.Oba;
using Mir.Entity.Player;
using System;
using System.IO;
using UnityEngine;

public class _Player : Entity
{
    public StateMachine stateMachine;
    public ItemSystem ItemSystem;

    [Header("Ground Layer")]
    [SerializeField] private LayerMask groundLayers;

    // Components
    [SerializeField] private BoxCollider2D boxCollider;

    [Obsolete] private int itemIndex;
    private int _itemIndex; // Temp variable for InputSystem.currentItemIndex
    [SerializeField] private int criticalHealth;

    // movement
    public bool canMove;

    // audio
    private EventInstance lowHealth;
    private EventInstance deathSound;

    // checkpoints
    public Transform latestCheckPoint;

    [Obsolete]
    public static _Player instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Found more than one player in the scene.");
        }
        instance = this;
    }

    public override void Start()
    {
        base.Start();

        ItemSystem = GetComponentInChildren<ItemSystem>();
        stateMachine = GetComponentInChildren<StateMachine>();
        boxCollider = GetComponent<BoxCollider2D>();

        _itemIndex = 0;


        lowHealth = AudioManager.instance.CreateEventInstance(MusicEvents.instance.playerLowHealth);
        //deathSound = AudioManager.instance.CreateEventInstance(MusicEvents.instance.playerDeath);

        // load saved game
        try
        {
            string[] loadedConstents = File.ReadAllLines("saved.game");

            float x = (float) Convert.ToDouble(loadedConstents[0]);
            float y = (float) Convert.ToDouble(loadedConstents[1]);

            latestCheckPoint.position = new Vector3(x, y, 0);

            transform.position = latestCheckPoint.position;
        }
        catch (Exception e)
        {
            Debug.Log("No saved game found.");
        }
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

            HandleCanMove();

            UpdateIsGrounded();
        }
    }

    protected override void OnDeath()
    {
        base.OnDeath();

        GameEventsManager.instance.OnPlayerDeath();

        Animator.SetTrigger("isDead");

        UnityEngine.Debug.Log("player died");
    }

    private void UpdateIsGrounded()
    {
        Bounds colliderBounds = boxCollider.bounds;
        float colliderRadius = boxCollider.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);
        // Check if player is grounded
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderRadius, groundLayers);
        // Check if any of the overlapping colliders are not player collider, if so, set isGrounded to true
        isGrounded = false;
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != boxCollider)
                {
                    this.isGrounded = true;
                    break;
                }
            }
        }
    }

    private void HandleCanMove()
    {
        // disable move on bow preparing state, otherwise enable move
            //canMove = StateMachine.instance.CurrentState.GetType() != typeof(BowPreparingState);
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
