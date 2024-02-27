using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToGame : MonoBehaviour
{
    [Header("UUID")] //unique unsigned identification
    public string uuid; //save a unique and specific exit point 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //change nextUuid to uuid that has configured this script
        FindObjectOfType<Player>().nextUuid = uuid;
        Loader.Load(Loader.Scene.GAME);     
    }
}
