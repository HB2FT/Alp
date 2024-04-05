using Mir.Input;
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
    }

    private void Update()
    {
        HandlePressed();
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
}
