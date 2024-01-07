using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newgame()
    {
        string pernahmain = "savestate";
        if (PlayerPrefs.HasKey(pernahmain))
        {
            int LoadScene = PlayerPrefs.GetInt("currentScene", 0);
            SceneManager.LoadScene(LoadScene);
            Debug.Log("Melanjutkan progress");
        }
        else {
            SceneManager.LoadScene("SampleScene");
            PlayerPrefs.SetString("savestate", "ada");
            Debug.Log("Membuat save state");
        }
}
}
