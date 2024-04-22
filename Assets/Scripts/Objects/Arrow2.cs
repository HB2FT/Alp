using Mir.Entity;
using UnityEngine;

public class Arrow2 : MonoBehaviour
{
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private int damage;

    void Start()
    {
        Debug.Log("Ok fýrlatýldý.");

        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();

        Throw(20);
    }

    void Update()
    {
        
    }

    public static void Create(GameObject prefab, Vector3 position, Vector3 direction)
    {
        Arrow2 arrow = Instantiate(prefab, position, Quaternion.identity).GetComponent<Arrow2>();

        if (direction == Vector3.right)
        {
            arrow.transform.Rotate(0f, 180f, 0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
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
        rigidbody.AddForce(new Vector2 (magnitude * -1, 0), ForceMode2D.Impulse);
    }
}
