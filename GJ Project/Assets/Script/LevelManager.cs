using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public List<int> Levels = new List<int>();
    bool LevelExist = false;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < 10; i++)
        {
            Levels.Add(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectLevel()
    {
        int Select = 0;
        while (!LevelExist)
        {
           Select = Random.Range(1,9);
          if (Levels.Exists(x => x == Select))
            {
                LevelExist = true;
                Debug.Log("Ada Level");
                Levels.Remove(Select);
            }

        }

        if (LevelExist == true)
        {

            SceneManager.LoadScene(Select);
        }
        LevelExist = false;

    }
}
