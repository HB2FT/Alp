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

// Bu sýnýfnýn çalýþma mantýðý OnTriggerEnter2D metodu üzerinden aþaðýda anlatýlmýþtýr:
// Metod ilk kez çaðýrýldýðýnda konuþma direk olarak baþlatýlýr ve ikinci kez çaðýrýldýðýnda kullanmasý için eventi subscribe edecek.
// Ýlk durumda event boþ olduðu için herhangi bir anormallik olmayacak. Ýkinci çaðýrýlýþta event devreye girecek.
