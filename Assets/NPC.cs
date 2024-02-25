using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    private bool playerIsClose;
    public GameObject text;

    public GameObject npcText;

    public SpriteRenderer imageText;

    private void Start()
    {
        HideAppearText();
        imageText.enabled = false;
        npcText.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose == true)
        {
            imageText.enabled = true;
            npcText.SetActive(true);
            HideAppearText();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShowAppearText();
        playerIsClose = true;
        if (collision.CompareTag("Player") == true)
        {
            Debug.Log("estoy dentro puerta asria");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("estoy fuera");
        HideAppearText();
    }
    private void ShowAppearText()
    {
        text.SetActive(true);
    }

    private void HideAppearText()
    {
        text.SetActive(false);
    }
}
