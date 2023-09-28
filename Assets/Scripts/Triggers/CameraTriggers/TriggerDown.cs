using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDown : MonoBehaviour
{
    public GameCamera Camera;
    public GameObject TriggerUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Camera.MoveDown();
            TriggerUp.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
