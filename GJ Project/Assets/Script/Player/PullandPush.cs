using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PullandPush : MonoBehaviour
{
    public float distance = 1f;
    public float jaraktembok = 1f;
    private bool grabbed;
    public LayerMask boxMask;
    public LayerMask Dinding;

    GameObject box;
    GameObject tembok;
    bool grounded;
    bool nempeltembok;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;

        //Membuat raycast untuk mendeteksi interaksi player dan items
        RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.right * transform.localScale.x, distance, boxMask);


        RaycastHit2D hitswall = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, jaraktembok, Dinding);

        //Mengambil referensi pengecekan player menyentuh tanah atau tidak
        grounded = gameObject.GetComponent<PlayerMove>().IsGround();

        //Jika raycast menyentuh item, player pencet E, dan karakter berada di tanah
        //Maka akan grab items
        if (hit.collider != null && Input.GetKeyDown(KeyCode.E) && grounded)
        {
            box = hit.collider.gameObject;

            box.GetComponent<HingeJoint2D>().enabled = true;
            box.GetComponent<BoxPull>().beingPushed = true;
            box.GetComponent<HingeJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            grabbed = true;
        } 
        //Jika tombol E dilepaskan, maka keluar dari action grab
        else if (Input.GetKeyUp(KeyCode.E) && grabbed)
        {
            /*box.GetComponent<FixedJoint2D>().enabled = false;*/
            box.GetComponent<HingeJoint2D>().enabled = false;
            box.GetComponent<BoxPull>().beingPushed = false;
            grabbed=false;
            Debug.Log("IsLepaskan");
        } 

       /* if (hitswall.collider != null && !grounded)
        {
            tembok = hitswall.collider.gameObject;
            tembok.GetComponent<FixedJoint2D>().enabled = true;
            tembok.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            nempeltembok = true;
        }
        else if (nempeltembok && Input.GetKeyDown(KeyCode.Space))
        {
            tembok.GetComponent<FixedJoint2D>().enabled = false;
            nempeltembok = false;
        }*/

    }

    //Hanya untuk menampilkan wujud raycast yang digunakan untuk deteksi interaksi
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }
}
