using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAttackTrigger : MonoBehaviour
{
    public Knight parent;
    public GameObject attackCollider;

    private void Start()
    {
        parent = GetComponentInParent<Knight>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Entity triggeredEntity = collision.GetComponent<Entity>();

        if (triggeredEntity != null)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        parent.Animator.SetBool("isAttacking", true);

        yield return new WaitForSeconds(0.300f);

        attackCollider.gameObject.SetActive(true);
    }
}
