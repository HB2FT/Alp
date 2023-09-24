using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TepegözAttackCollider : MonoBehaviour
{
    public Tepegöz tepegöz; // For accessing tepegöz's damage
    public bool tmp;
    public AtomicBoolean once = new AtomicBoolean(true);

    private void Start()
    {
        tepegöz = GetComponentInParent<Tepegöz>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedGameObject = collision.gameObject;
        Player collidedPlayer = collidedGameObject.GetComponent<Player>();

        if (collidedPlayer != null)
        {
            Rigidbody2D rbPlayer = collidedGameObject.GetComponent<Rigidbody2D>();
            rbPlayer.AddForce(new Vector2(-10, 5), ForceMode2D.Impulse); Debug.Log("TepegözAttackCollider -> rbPLayer.AddForce");
            collidedPlayer.health -= tepegöz.damage;

            gameObject.SetActive(false);
        }
    }
}
