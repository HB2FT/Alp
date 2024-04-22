using UnityEngine;

public class Arrow2 : MonoBehaviour
{
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private BoxCollider2D boxCollider;

    void Start()
    {
        Debug.Log("Ok fýrlatýldý.");

        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();

        Throw(5);
    }

    void Update()
    {
        
    }

    public static void Create(GameObject prefab, Vector3 position, Vector3 direction)
    {
        Arrow2 arrow = Instantiate(prefab, position, Quaternion.identity).GetComponent<Arrow2>();

         arrow.transform.Rotate(direction);
    }

    public void Throw(float magnitude)
    {
        rigidbody.AddForce(new Vector2 (0, magnitude), ForceMode2D.Force);
    }
}
