using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFol : MonoBehaviour
{
    // Start is called before the first frame update
 
    
        public float FollowSpeed = 2f;
        public float yOffset = 1f;

        /*Deklarasi variable target untuk menyimpan GameObject Player*/
        public Transform target; 


        // Update is called once per frame
        void Update()
        {
            /*Store lokasi variable target (player)*/
            Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
            
            /*Memindahkan kamera ke newPos, yaitu lokasi player.*/
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        }
    
}
