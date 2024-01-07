using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountDownUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countdownText;
    public float countdownTime;
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
            countdownText.color = Color.black;
        }
        else if (countdownTime < 0)
        {
            countdownTime = 0;
            countdownText.color = Color.red;
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("deathScene");
        }


        int minutes = Mathf.FloorToInt(countdownTime / 60);
        int seconds = Mathf.FloorToInt(countdownTime % 60);
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void SetCountDown(float alokasiCD)
    {
        countdownTime = alokasiCD;
    }

    public void AddCountDown(int tambahCD)
    {
        countdownTime += tambahCD;
    }
}
