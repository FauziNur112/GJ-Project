using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HearthSystem : MonoBehaviour
{
    public GameObject[] hearts;
    public int life;
    [SerializeField] private bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int d) 
    { 
        life -= d;
        Destroy(hearts[life].gameObject);
        if (life < 1)
        {
            dead = true;
            SceneManager.LoadScene("DeathScene");
        }
        life = Mathf.Clamp(life, 0, 3);
    }
}
