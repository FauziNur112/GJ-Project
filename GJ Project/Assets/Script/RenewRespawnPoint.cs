using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenewRespawnPoint : MonoBehaviour
{
   [SerializeField] GameObject managergame;

    private void Awake()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            managergame.GetComponent<HearthSystem>().perbaruiRespawnPoint(transform.position);
            Debug.Log("Titik Respawn diperbarui");
        }
    }
}
