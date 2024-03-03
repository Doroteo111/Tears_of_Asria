using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AsriaCollider : MonoBehaviour
{
    [Header("VARIABLES")]
    public GameObject textTalk;
    public TextMeshProUGUI dialogueText;
    public Button nextLineButton;
    public GameObject panelAsriadialogue;
    private bool playerIsTalkingAsria;

    public float textSpeed;
    private int index;

    [Header("Sounds")]
    [SerializeField] private AudioClip clickSound;

    [Header("REFERENCE")]
    public Player _player;
    public string[] lines;
    private void Start()
    {
        HideAppearText();
        panelAsriadialogue.SetActive(false);

        dialogueText.text = string.Empty;

        nextLineButton.onClick.AddListener(ButtonNextLine);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && playerIsTalkingAsria)
        {
            StartDialogue();
            panelAsriadialogue.SetActive(true);
            HideAppearText();
            playerIsTalkingAsria = true;

            //Now the player can't move during the dialogue
            _player.iCanMove = false;

        }


    }

    //When the player its in the collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShowAppearText();
        playerIsTalkingAsria = true;
        if (collision.CompareTag("Player") == true)
        {
            Debug.Log("estoy con el NPC");
        }
    }
    //When the player its outside the collider
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("estoy fuera");
        panelAsriadialogue.SetActive(false);
        HideAppearText();
    }

    private void ButtonNextLine()
    {
        SoundManager.instance.PlaySound(clickSound);
        //Pass to the next line and if you press again autocomplete the sentence 
        if (dialogueText.text == lines[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            dialogueText.text = lines[index];
        }
    }
    private void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine() //write letter by letter
    {
        // text > the array lines in the curren index > converts string to Chararray
        foreach (char c in lines[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    private void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            //when we ran out of line, change scene
            Loader.Load(Loader.Scene.Credits);

            //Now the player can move
            _player.iCanMove = true;
        }
    }

    // Show and Hide text to let to know the player if 
    // want to talk with Asria (the statue)
    private void ShowAppearText()
    {
        textTalk.SetActive(true);
    }

    private void HideAppearText()
    {
        textTalk.SetActive(false);
    }
}
