using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerUp : MonoBehaviour
{
    public GameCamera Camera;
    public GameObject TriggerDown;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Camera.MoveUp();
            TriggerDown.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
