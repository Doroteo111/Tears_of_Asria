using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BackToGame : MonoBehaviour
{
    public string exitPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Loader.Load(Loader.Scene.GAME);     
        PlayerPrefs.SetString("LastExitPoint", exitPoint);
        Loader.Load(Loader.Scene.GAME);

       
    }
}
