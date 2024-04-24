using FMOD.Studio;
using Mir.Audio.Oba;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerManager : MonoBehaviour
{
    private EventInstance playerDeathSound;

    [SerializeField] private PostProcessVolume deathVisualEffect;

    [SerializeField] private float increaseAmount;
    [SerializeField] private GameObject deathMenu;

    public bool applyCheckpoint;

    public static PlayerManager instance {  get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Game Event Manager in the scene.");
        }
        instance = this;
    }

    private void Start()
    {
        // subscribe events
        GameEventsManager.instance.onPlayerDeath += OnPlayerDeath;
    }

    private void OnDestroy()
    {
        // unsubscribe events
        GameEventsManager.instance.onPlayerDeath -= OnPlayerDeath;
    }

    private void OnPlayerDeath()
    {
        // stop other sounds
        AudioManager.instance.CleanUp();

        // initialize death sound effects here, because we want to stop all sounds in the game not excluding death sound
        playerDeathSound = AudioManager.instance.CreateEventInstance(MusicEvents.instance.playerDeath);

        // play death sound effect
        playerDeathSound.start();

        StartCoroutine(HandlePlayerDeath());
    }

    private IEnumerator HandlePlayerDeath()
    {
        VisualEffectsManager.instance.SetCurrentProfile(VisualEffects.instance.deathVisualEffect);
        VisualEffectsManager.instance.weight = 0f;

        while (VisualEffectsManager.instance.weight < 1)
        {
            yield return new WaitForSeconds(0.1f);

            VisualEffectsManager.instance.weight += Time.deltaTime * increaseAmount;
        }

        deathMenu.SetActive(true);
    }
}
