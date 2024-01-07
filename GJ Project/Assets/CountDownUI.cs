using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountDownUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] float countdownTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (countdownTime > 0)
        {
            countdownTime -= Time.deltaTime;
            countdownText.color = Color.white;
        }
        else if (countdownTime < 0)
        {
            countdownTime = 0;
            countdownText.color = Color.red;
            SceneManager.LoadScene("deathScene");
        }


        int minutes = Mathf.FloorToInt(countdownTime / 60);
        int seconds = Mathf.FloorToInt(countdownTime % 60);
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void SetCountDown(int alokasiCD)
    {
        countdownTime = alokasiCD;
    }

    public void AddCountDown(int tambahCD)
    {
        countdownTime += tambahCD;
    }
}
