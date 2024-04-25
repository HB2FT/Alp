using Mir.Entity;
using UnityEngine;

public class HortlakAttackCollider : MonoBehaviour
{
    private Hortlak parent;

    private void Start()
    {
        parent = GetComponentInParent<Hortlak>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _Player player = collision.gameObject.GetComponent<_Player>();

        int direction;

        if (player != null)
        {
            if ((player.transform.position.x - transform.position.x) > 0)
            {
                direction = 1;  
            }
            else
            {
                direction = -1;
            }

            player.health -= parent.Damage;
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(5 * direction, 3), ForceMode2D.Impulse);
        }

        gameObject.SetActive(false);
    }
}
