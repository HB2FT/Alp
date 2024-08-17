using Mir.Entity;
using UnityEngine;

public class PlayerAttackCollider : MonoBehaviour
{
    public static PlayerAttackCollider instance {  get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Found more than one Player Attack Collider in the scene.");
        }
        instance = this;
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Entity collidedEntity = collision.gameObject.GetComponent<Entity>();

        if (collidedEntity != null)
        {
            collidedEntity.health -= 20;
            collidedEntity.IsDamaged = true;

            // Also check Tepegoz
            Tepegöz tepegöz = collidedEntity.GetComponent<Tepegöz>();
            if (tepegöz != null)
            {
                if (tepegöz.IsDamagable)
                {
                    tepegöz.IsDamagable = false;
                }
            }

            gameObject.SetActive(false);
        }
    }
}
