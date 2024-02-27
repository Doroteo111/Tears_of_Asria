using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToGame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       Loader.Load(Loader.Scene.GAME);     
    }
}
