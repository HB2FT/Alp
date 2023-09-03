using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

partial class GameController
{
    public Player player;
    public Slider slider;
    public Gradient gradient;
    public Image Fill;

    void HealthBarStart()
    {
        SetMaxhealth(player.health);
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

