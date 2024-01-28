using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region other option / main camera, works strange
    /*// How fast camera will move to the target
     public float FollowSpeed = 2f;
     public float yOffset = 1f; //change the height
     public Transform target; //give the position of the player

     void Start()
     {

     }

     // Update is called once per frame
     void Update()
     {
         Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);

         //Slerp means --> interpolates between two vectors
         // change camera position same as target position
         transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
     }*/
    #endregion


}
