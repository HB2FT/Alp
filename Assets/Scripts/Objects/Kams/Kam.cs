using UnityEngine;

public class Kam : MonoBehaviour
{
    [SerializeField] private StoryScene storyScene;

    private AtomicBoolean once;

    private void Start()
    {
        once = new AtomicBoolean(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (once.Value && collision.CompareTag("Player"))
        {
            BottomBarController.Instance.PlayScene(storyScene);
        }

        // Bir kere kam ile etkilestikten sonra yeniden etkilesmek icin ozellik ekle.
        // - Ikinci kere etkilesmek icin kam'in yanina yaklasildiginda ekrana etkilesme isareti cikarilabilir.
        // - Klavye ve kontrolcu icin etkilesim tusu belirlenecek.
    }
}
