using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorsAsria : MonoBehaviour
{
    [Header("REFERENCE")]
    public DataPersistence _dataPersistence;
    public Player _player;
    public TransitionSceneLoader TransitionScene;

    public string exitPoint;

    [Header("UI VARIABLES")]
    [SerializeField] private GameObject infoTextA;
    public bool playerIsClose;

    [Header("Sounds")]
    [SerializeField] private AudioClip doorSound;

    private void Start()
    {
        HideAppearText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose == true)
        {
            if (_player.totalGems >= 5)
            {
                //Read from other script, first a transition, then change the scene
                //error here, I normally use TransitionScene.LoadNextScenePinkDoor(); but it takes me the wrong scene, although I have assigned it the right scene
                //TransitionScene.LoadNextSceneEndGame();
                SoundManager.instance.PlaySound(doorSound);
                Loader.Load(Loader.Scene.EndGame);
            }
            else
            {
                Debug.Log("no tienes todos los fragmentos, no puedes pasar");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShowAppearText();
        playerIsClose = true;

        if (collision.CompareTag("Player") == true)
        {
           // _dataPersistence.LoadJson();
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
        infoTextA.SetActive(true);
    }

    private void HideAppearText()
    {
        infoTextA.SetActive(false);
    }
}
