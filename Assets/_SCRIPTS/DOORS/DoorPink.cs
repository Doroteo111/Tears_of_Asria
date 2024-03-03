using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DoorPink : MonoBehaviour
{
    [Header("REFERENCE")]
    public DataPersistence _dataPersistence;
    public Player _player;
    public TransitionSceneLoader TransitionScene;

    [Header("UI VARIABLES")]
    [SerializeField] private GameObject infoText;

    public string exitPoint;
    public bool playerIsClose;

    private void Start()
    {
        HideAppearText();
    }
    private void Update()
    {
        // If player is in the collider
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose == true)
        {
            if (_player.hasPinkKey == true)
            {
                Debug.Log("you have the key");


                //Read from other script, first a transition, then change the scene
                //error here, entoria uso TransitionScene.LoadNextScenePinkDoor(); pero me da error, me lleva al amarillo, auqnue yo lo asigne a la escena que toca
                // TransitionScene.LoadNextScenePinkDoor();
                Loader.Load(Loader.Scene.PinkDoor);

            }
            else
            {
                Debug.Log("you dont have the key");
                //add ui text
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShowAppearText();

        playerIsClose = true;

        if (collision.CompareTag("Player") == true)
        {
           // _dataPersistence.LoadJson(); //load to confirm if you have the key
            Debug.Log("estoy dentro");
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
        infoText.SetActive(true);
    }

    private void HideAppearText()
    {
        infoText.SetActive(false);
    }
}
