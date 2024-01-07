using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUI;
    public GameObject SettingMenu; 
    public static bool GameIsPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                resume();
            }
            else
            {
                 pause();
            }
        }
    }

    public void resume()
    {
        PauseMenuUI.SetActive(false);
        SettingMenu.SetActive(false);
        Time.timeScale = 1f; 
        GameIsPaused = false;
    }
    
    public void pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void quit()
    {
        Application.Quit();
    }
}
