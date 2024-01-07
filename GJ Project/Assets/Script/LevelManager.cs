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
        //Mengisi List Levels 1 - 10 sesuai stage yang ada (9). Batas atas 10 sebab bug
        for (int i = 1; i < 4; i++)
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

        //Looping akan berhenti jika index level yang diperoleh dari randomize masih tersedia
        //Sebab index stage yang sudah terpilih di dalam list akan di hapus ketika terpilih
        while (!LevelExist)
        {
            //Randomize integer dengan jarak 1 sampai 10
           Select = Random.Range(1,5);

            //Cek apakah list Levels memiliki integer yang didapat dari randomize 
          if (Levels.Exists(x => x == Select))
            {
                //Jika benar ada, maka bool LevelExist menjadi true, dan loop akan berhenti di iterasi ini
                LevelExist = true;
                Levels.Remove(Select);
            }
          
          //Cek apakah List Levels memiliki index level tidak. Agar ketika stage yang 
          //Tersedia sudah terpilih semua, tidak terkena Infinite Loop
          if (Levels.Count == 0)
            {
                LevelExist = true;
            }
        }

        //Jika level benar ada, dan List Levels (index level yang tersedia) masih ada, 
        //Maka akan dibawa ke level tersebut
        if (LevelExist == true && Levels.Count > 0) 
        {
            Debug.Log(Select);
            SceneManager.LoadScene(Select);
        }

        //LevelExist akan dijadikan false setiap eksekusi agar selanjutnya 
        //Loop cari level dapat digunakan lagi
        LevelExist = false;

    }
}
