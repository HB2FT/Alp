using Mir.Entity;
using UnityEngine;

public class KnightAttackCollider : MonoBehaviour
{
    public Knight parent;
    private int Direction = 1;

    private void Start()
    {
        parent = GetComponentInParent<Knight>();
    }

    private void Update()
    {
        if (parent.isRight) Direction = 1; else Direction = -1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Entity collidedEntity = collision.gameObject.GetComponent<Entity>();

        if (collidedEntity != null )
        {
            collidedEntity.health -= 15;
            collidedEntity.Rigidbody.AddForce(new Vector2(6 * Direction, 0), ForceMode2D.Impulse);
        }
    }
}
