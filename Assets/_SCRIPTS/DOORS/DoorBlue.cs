using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DoorBlue : MonoBehaviour
{
    public DataPersistence _dataPersistence;
    public Player _player;
    public TransitionSceneLoader TransitionScene;
    public bool playerIsClose;

    [Header("UI VARIABLES")]
    [SerializeField] private GameObject infoText;

   public string exitPoint;

    [Header("Sounds")]
    [SerializeField] private AudioClip doorSound;
 

    private void Start()
    {
        HideAppearText();
    }

    private void Update()
    {
        // If player is in the collider
       if (Input.GetKeyDown(KeyCode.E) && playerIsClose == true)
        {
            if (_player.hasBlueKey == true)
            {
                Debug.Log("you have the key");
                //Read from other script, first a transition, then change the scene
                //error here, I normally use TransitionScene.LoadNextScenePinkDoor(); but it takes me the wrong scene, although I have assigned it the right scene
                // TransitionScene.LoadNextSceneBlueDoor();
                SoundManager.instance.PlaySound(doorSound);
                Loader.Load(Loader.Scene.BlueDoor);

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

        if(collision.CompareTag("Player") == true )
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
