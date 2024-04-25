using Mir.Input;
using Mir.Managers;
using Mir.Objects;
using TMPro;
using UnityEngine;

public class InterractionButton : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Interactable interactable;
    private new bool enabled;

    private void Start()
    {
        interactable = GetComponentInParent<Interactable>();
        //spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        //text = GetComponentInChildren<TextMeshPro>();

        Enabled = false;

        GameEventsManager.instance.onGamepadConnected += LoadSprite;
        GameEventsManager.instance.onGamepadDisconnected += LoadSprite;

        LoadSprite();
    }

    private void Update()
    {
        HandlePressed();
    }

    public void LoadSprite()
    {
        Debug.Log("Mevcut kontrol birimine göre grafik yükleniyor...");

        Sprite sprite = UISpritesManager.Instance.LoadSprite(UISprite.INTERACTION_BUTTON);
        Sprite = sprite;
    }

    private void HandlePressed()
    {
        if (enabled && InputManager.instance.GetInterractionPressed())
        {
            OnPressed();
        }
    }

    private void OnPressed()
    {
        interactable.OnInteract();
    }

    public bool Enabled
    {
        get
        {
            return enabled;
        }

        set
        {
            enabled = value;
            spriteRenderer.gameObject.SetActive(value);
            text.gameObject.SetActive(value);
        }
    }

    public Sprite Sprite
    {
        set
        {
            spriteRenderer.sprite = value; ;
        }
    }
}
