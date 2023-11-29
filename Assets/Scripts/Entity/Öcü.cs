using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Öcü : Entity   
{
    public float startPosX;
    public float range;
    public float border;

    public int damage;

    private bool readyToAttac;

    public Player player; // Accessed for damage

    public AtomicBoolean isDead;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        startPosX = transform.position.x;
        range = 10;
        border = startPosX + range;
        readyToAttac = true;

        isDead = new AtomicBoolean(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 0)
        {
            transform.position += transform.right * Speed * Time.deltaTime;

            if (transform.position.x > startPosX + 10 || transform.position.x < startPosX - 10)
            {
                Rotate();
            }
        }

        else
        {
            if (isDead.Value)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null && readyToAttac)
        {
            int direction;

            if (isRight) direction = -1;
            else direction = 1;

            player.health -= damage;
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(3 * direction, 1), ForceMode2D.Impulse);

            readyToAttac = false;
            StartCoroutine(SetReadyToAttack());
        }
    }

    IEnumerator SetReadyToAttack()
    {
        yield return new WaitForSeconds(1f);
        readyToAttac = true;
    }
}
