using Mir.Entity;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collidedGameObject = collision.gameObject;
        _Player collidedPlayer = collidedGameObject.GetComponent<_Player>();

        if (collidedPlayer != null)
        {
            Rigidbody2D rbPlayer = collidedPlayer.GetComponent<Rigidbody2D>();
            rbPlayer.AddForce(new Vector2(10 * tepegöz.FacingDirection.x, 5), ForceMode2D.Impulse); 
            collidedPlayer.health -= tepegöz.damage;

            gameObject.SetActive(false);
        }
    }
}
