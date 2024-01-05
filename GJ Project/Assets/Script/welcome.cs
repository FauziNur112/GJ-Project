using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class welcome : MonoBehaviour
{
    public Button tombolMulai;

    // Start is called before the first frame update
    void Start()
    {
        // Menambahkan event untuk tombol saat diklik
        tombolMulai.onClick.AddListener(MulaiAksi);
    }

    void MulaiAksi()
    {
        // Tindakan yang akan dijalankan saat tombol ditekan
        // Memuat scene selanjutnya
        SceneManager.LoadScene("Main Menu");
    }
}
