using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnLevelChange : MonoBehaviour
{
    public GameObject Player;
    public Vector2 RenewRespawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        RenewRespawnPoint = gameObject.transform.position;
        Player.transform.position = RenewRespawnPoint;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
