using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HearthSystem : MonoBehaviour
{
    public GameObject[] hearts;
    public int life;
    [SerializeField] private bool dead = false;

    //Fungsi mengurangi nyawa player
    public void TakeDamage(int d) 
    { 
        life -= d;
        Destroy(hearts[life].gameObject);

        //Jika nyawa = 0, maka akan dibawa ke scene death
        if (life < 1)
        {
            dead = true;
            SceneManager.LoadScene("DeathScene");
        }

        //Membatasi integer nyawa agar tidak lebih dari yang ditentukan
        life = Mathf.Clamp(life, 0, 3);
    }
}
