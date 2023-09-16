using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Öcü : Entity   
{
    public float startPosX;
    public float range;
    public float border;

    public Player player; // Accessed for damage

    public AtomicBoolean isDead;

    // Start is called before the first frame update
    void Start()
    {
        startPosX = transform.position.x;
        range = 10;
        border = startPosX + range;

        isDead = new AtomicBoolean(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 0)
        {
            transform.position += transform.right * speed * Time.deltaTime;

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
}
