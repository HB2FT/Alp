using Mir.Entity;
using UnityEngine;

public class Arrow2 : MonoBehaviour
{
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private int damage;
    [SerializeField] private Vector3 direction;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();

        boxCollider.isTrigger = true;
    }

    void Update()
    {
        
    }

    public static void Create(GameObject prefab, Vector3 position, Vector3 direction, float throwingForce)
    {
        Arrow2 arrow = Instantiate(prefab, position, Quaternion.identity).GetComponent<Arrow2>();
        arrow.direction = direction;

        if (direction == Vector3.left)
        {
            arrow.transform.Rotate(0f, 180f, 0f);
        }

        arrow.Throw(throwingForce);
    }

    public static void Create(GameObject prefab, Vector3 position, bool isRight, float throwingForce)
    {
        Arrow2 arrow = Instantiate(prefab, position, Quaternion.identity).GetComponent<Arrow2>();

        if (!isRight)
        {
            arrow.transform.Rotate(0f, 180f, 0f);
            throwingForce *= -1;
        }

        arrow.Throw(throwingForce);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Entity collidedEntity = collision.gameObject.GetComponent<Entity>();

        if (collidedEntity != null)
        {
            collidedEntity.health -= damage;
        }

        Destroy(gameObject);
    }

    public void Throw(float magnitude)
    {
        if (rigidbody == null) rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(new Vector2 (magnitude, 0), ForceMode2D.Impulse);
    }
}
