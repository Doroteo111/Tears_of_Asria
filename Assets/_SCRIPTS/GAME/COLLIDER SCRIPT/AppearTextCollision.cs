using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AppearTextCollision : MonoBehaviour
{
    public DataPersistence _dataPersistence;
    public Player _player;
    public TransitionSceneLoader TransitionScene;
    public bool playerIsClose;

    [Header("UI VARIABLES")]
    [SerializeField] private GameObject textoEjemplo;

    private void Start()
    {
        HideAppearText();
    }

    private void Update()
    {
        // no se como conectar los valores del trigger enter al update
       if (Input.GetKeyDown(KeyCode.E) && playerIsClose == true)
        {
            if (_player.hasBlueKey == true)
            {
                Debug.Log("tienes la llave");
                //
                //Read from other script, first a transition, then change the scene
                TransitionScene.LoadNextSceneBlueDoor();
            }
            else
            {
                Debug.Log("no tienes llave");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShowAppearText();

        playerIsClose = true;

        if(collision.CompareTag("Player") == true )
        {
            _dataPersistence.LoadJson();
            Debug.Log("estoy dentro");

           /* if (_player.hasBlueKey == true)
            {
                Debug.Log("tienes la llave");
                // no quiero un salto directo, quiero usar un input
                Loader.Load(Loader.Scene.BlueDoor);
            }
            else
            {
                Debug.Log("no tienes llave");
            }*/
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("estoy fuera");
        HideAppearText();
    }

    private void ShowAppearText()
    {
      textoEjemplo.SetActive(true);
    }

    private void HideAppearText()
    {
        textoEjemplo.SetActive(false);
    }
}
