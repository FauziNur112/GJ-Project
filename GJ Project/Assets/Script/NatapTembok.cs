using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatapTembok : MonoBehaviour
{
    // Start is called before the first frame update

    public LevelManager LevelManager;
    void Start()
    {
        if (LevelManager == null)
        {
            LevelManager = FindObjectOfType<LevelManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Cek apakah player menabrak tembok dan jika benar, maka akan randomize next stage 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LevelManager.SelectLevel();
            Debug.Log("Menabrak");
        }
    }

}
