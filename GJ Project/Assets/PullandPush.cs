using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PullandPush : MonoBehaviour
{
    public float distance = 1f;
    private bool grabbed;
    public LayerMask boxMask;

    GameObject box;
    bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.right * transform.localScale.x, distance, boxMask);
        grounded = gameObject.GetComponent<PlayerMove>().IsGround();

        if (hit.collider != null && Input.GetKeyDown(KeyCode.E) && grounded)
        {
            box = hit.collider.gameObject;

            /*            box.GetComponent<FixedJoint2D>().enabled = true;
                        box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            */
            box.GetComponent<HingeJoint2D>().enabled = true;
            box.GetComponent<BoxPull>().beingPushed = true;
            box.GetComponent<HingeJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            grabbed = true;
        } else if (Input.GetKeyUp(KeyCode.E) && grabbed)
        {
            /*            box.GetComponent<FixedJoint2D>().enabled = false;*/
            box.GetComponent<HingeJoint2D>().enabled = false;
            box.GetComponent<BoxPull>().beingPushed = false;
            grabbed=false;
        }
    
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }
}
