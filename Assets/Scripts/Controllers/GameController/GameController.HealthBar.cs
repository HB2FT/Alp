using Mir.Entity;
using UnityEngine;
using UnityEngine.UI;

partial class GameController
{
    [SerializeField] private _Player player;
    public Slider slider;
    public Gradient gradient;
    public Image Fill;

    void HealthBarStart()
    {
        SetMaxhealth(player.health);
        slider.maxValue = player.maxHealth;
    }

    void HealthBarUpdate()
    {
        SetHealth(player.health);

        Fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetMaxhealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        SetHealth(maxHealth);
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}

