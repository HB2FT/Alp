using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TepegözAttackCollider : MonoBehaviour
{
    public Player player;
    public Tepegöz tepegöz;
    BoxCollider2D boxCollider;
    public bool tmp;
    public AtomicBoolean once = new AtomicBoolean(true);

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && (tmp = once.Value))
        {
            
            Rigidbody2D targetRB = player.gameObject.GetComponent<Rigidbody2D>();
            targetRB.AddForce(new Vector2(-10, 5), ForceMode2D.Impulse); Debug.Log("Player add force from tepegöz attack collider");
            player.health -= tepegöz.damage;

            gameObject.SetActive(false);
        }

        //Debug.Log("once: " + tmp);
    }

    
}
