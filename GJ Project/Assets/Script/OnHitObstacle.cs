using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitObstacle : MonoBehaviour
{
    [SerializeField] GameObject managergame;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            managergame.GetComponent<HearthSystem>().TakeDamage(1);
        }
    }
}
