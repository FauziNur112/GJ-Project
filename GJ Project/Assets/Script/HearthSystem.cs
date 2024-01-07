using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HearthSystem : MonoBehaviour
{
    public GameObject[] hearts;
    Vector3 respawnPoint;
    [SerializeField] GameObject Player;
    public int life;
    [SerializeField] private bool dead = false;

    [SerializeField] private float iframes;
    [SerializeField] private int jumlahkedip;
    public SpriteRenderer spriteplayer;

    private float arahknockback;

    private void Awake()
    {
    
    }

    private void Start()
    {
        int nyawasaatini= PlayerPrefs.GetInt("sisaNyawa", 3);
        Debug.Log(nyawasaatini);
        for (int i = 3; i > nyawasaatini; nyawasaatini++)
        {
            Destroy(hearts[nyawasaatini].gameObject);
        }
    }
    //Fungsi mengurangi nyawa player
    public void TakeDamage(int d) 
    {
        arahknockback = Player.transform.localScale.x;
        Player.GetComponent<Rigidbody2D>().velocity = new Vector2(100, 32);

        life -= d;
        Destroy(hearts[life].gameObject);
        StartCoroutine(Invunerability());

        //Jika nyawa = 0, maka akan dibawa ke scene death
        if (life < 1)
        {
            dead = true;
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("DeathScene");
        }

        //Membatasi integer nyawa agar tidak lebih dari yang ditentukan
        life = Mathf.Clamp(life, 0, 3);
        /*Player.transform.position = respawnPoint;*/
    }

    public void perbaruiRespawnPoint(Vector3 point)
    {
        respawnPoint = point;
    }

    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(10, 9, true);

        for (int i = 0; i < jumlahkedip; i++)
        {
            spriteplayer.color = new Color (1, 1, 1, 0.5f);
            yield return new WaitForSeconds(iframes / (jumlahkedip *2));
            spriteplayer.color = new Color(1, 1, 1, 1f);
            yield return new WaitForSeconds(iframes / (jumlahkedip * 2));
        }

        Physics2D.IgnoreLayerCollision(10, 9, false);
    }
}
