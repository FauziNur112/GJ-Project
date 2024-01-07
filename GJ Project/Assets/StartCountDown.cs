using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCountDown : MonoBehaviour
{
    [SerializeField] CountDownUI countdown;
    public float StartCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            float lastCD = PlayerPrefs.GetFloat("lastCD", 3);
            if (lastCD != 3)
            {
                StartCount += lastCD;
            }
            countdown.SetCountDown(StartCount);
            
        }
    }
}
