using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Player player;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider;
    public Rigidbody2D rigidbody;
    public Sprite spr_arrow;

    public int damage = 25;
    public float rotationSpeed = 20f;
    public bool isRight;
    public int Direction = 1;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();

        if (!player.isRight) 
        {
            Rotate();
            Direction *= -1;
        }

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        rigidbody = gameObject.GetComponent<Rigidbody2D>();

        transform.position = transform.position + new Vector3(2f * Direction, 0, 0);
        transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);

        //spriteRenderer.sprite = spr_arrow;
        spriteRenderer.sortingLayerName = "Player";

        boxCollider.offset = new Vector2(-0.006f, -0.007f);
        boxCollider.size = new Vector2(0.17f, 0.05f);

        rigidbody.AddForce(new Vector2(600 * Direction, 50)); //F rlat lma
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * -rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rigidbody.velocity = Vector2.zero;

        Entity collidedEntity = collision.gameObject.GetComponent<Entity>();
        if (collidedEntity != null)
        {
            collidedEntity.health -= damage;
        }

        boxCollider.enabled = false;
        rigidbody.freezeRotation = true;  
        rigidbody.gravityScale = 0f;

        //Destroy(gameObject);
    }

    public void Rotate() 
    {
        isRight = !isRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
