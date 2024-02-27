using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DoorsAsria : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose == true)
        {
            //Read from other script, first a transition, then change the scene
            TransitionScene.LoadNextSceneEndGame();

            /* if (_player tiene todas las gemas 5/5)
             {
                 //TransitionScene.LoadNextSceneEndGame();
             }
             else
             {
                 Debug.Log("no tienes todos los fragmentos, no puedes pasar");
             }*/
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShowAppearText();
        playerIsClose = true;

        if (collision.CompareTag("Player") == true)
        {
            _dataPersistence.LoadJson();
            Debug.Log("estoy dentro puerta asria");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("estoy fuera");
        HideAppearText();
    }

    //Visual text that helps the player to know which key press
    private void ShowAppearText()
    { 
        textoEjemplo.SetActive(true);
    }

    private void HideAppearText()
    {
        textoEjemplo.SetActive(false);
    }
}
