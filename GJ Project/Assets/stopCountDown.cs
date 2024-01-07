using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopCountDown : MonoBehaviour
{
    [SerializeField] CountDownUI countdownUI;
    public float lastCountdown;
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
            lastCountdown = countdownUI.countdownTime;
            PlayerPrefs.SetFloat("lastCD", lastCountdown);
            countdownUI.SetCountDown(0);
        }
    }
}
