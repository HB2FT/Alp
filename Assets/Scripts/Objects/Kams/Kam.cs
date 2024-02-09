using Mir.Controllers;
using Mir.Objects;
using System;
using UnityEngine;

public class Kam : Interactable
{
    [SerializeField] private StoryScene storyScene;
    [SerializeField] private InterractionButton InterractionButton;

    private AtomicBoolean onceEnter;
    private AtomicBoolean onceExit;

    private void Start()
    {
        onceEnter = new AtomicBoolean(true);
        onceExit = new AtomicBoolean(true);
    }

    public override void OnInteract()
    {
        ShowDialog();
    }

    private void ShowDialog()
    {
        BottomBarController.Instance.PlayScene(storyScene);
    }

    private void ShowInterractionButton()
    {
        InterractionButton.Enabled = true;
    }

    private void HideInterractionButton()
    {
        InterractionButton.Enabled = false;
    }

    public event Action onSecondTriggerEnter;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (onSecondTriggerEnter != null) onSecondTriggerEnter();

            // If it's the first time
            if (onceEnter.Value)
            {
                ShowDialog();

                onSecondTriggerEnter += ShowInterractionButton;
            }
        }

        // Bir kere kam ile etkilestikten sonra yeniden etkilesmek icin ozellik ekle.
        // - Ikinci kere etkilesmek icin kam'in yanina yaklasildiginda ekrana etkilesme isareti cikarilabilir.
        // - Klavye ve kontrolcu icin etkilesim tusu belirlenecek.
    }

    public event Action onSecondTriggerExit;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (onSecondTriggerExit != null)
            {
                Debug.Log("Exit");
                onSecondTriggerExit();
            }

            // If it's the first time
            if (onceExit.Value)
            {
                onSecondTriggerExit += HideInterractionButton;
            }
        }
    }
}

// Bu s�n�fn�n �al��ma mant��� OnTriggerEnter2D metodu �zerinden a�a��da anlat�lm��t�r:
// Metod ilk kez �a��r�ld���nda konu�ma direk olarak ba�lat�l�r ve ikinci kez �a��r�ld���nda kullanmas� i�in eventi subscribe edecek.
// �lk durumda event bo� oldu�u i�in herhangi bir anormallik olmayacak. �kinci �a��r�l��ta event devreye girecek.
