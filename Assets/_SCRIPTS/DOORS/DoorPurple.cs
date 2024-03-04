using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPurple : MonoBehaviour
{
    [Header("REFERENCE")]
    public DataPersistence _dataPersistence;
    public Player _player;
    public TransitionSceneLoader TransitionScene;

    [Header("UI VARIABLES")]
    [SerializeField] private GameObject infoText;

    [Header("Sounds")]
    [SerializeField] private AudioClip doorSound;
    

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
            if (_player.hasPurpleKey == true)
            {
                Debug.Log("you have the key");


                //Read from other script, first a transition, then change the scene
                //error here, I normally use TransitionScene.LoadNextScenePinkDoor(); but it takes me the wrong scene, although I have assigned it the right scene
                //TransitionScene.LoadNextScenePurpleDoor();
                SoundManager.instance.PlaySound(doorSound);
                Loader.Load(Loader.Scene.PurpleDoor);

            }
            else
            {
                Debug.Log("you dont have the key");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShowAppearText();

        playerIsClose = true;

        if (collision.CompareTag("Player") == true)
        {
            // _dataPersistence.LoadJson(); //load to confirm if you have the key ( I changed what I did because I think it gave me an error. This line is in a game empty )
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
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
