using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    [Header("VARIABLES")]
    public GameObject textTalk;
    public TextMeshProUGUI dialogueText;
    public Button nextLineButton;
    public GameObject panelNPCdialogue;
    private bool playerIsTalkingNPC;

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
        panelNPCdialogue.SetActive(false);

        dialogueText.text = string.Empty;
        
        nextLineButton.onClick.AddListener(ButtonNextLine);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && playerIsTalkingNPC)
        {
            StartDialogue();
            panelNPCdialogue.SetActive(true);
            HideAppearText();
            playerIsTalkingNPC = true;

            //Now the player can't move during the dialogue
            _player.iCanMove = false;

        }

       
    }

    //When the player its in the collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShowAppearText();
        playerIsTalkingNPC = true;
        if (collision.CompareTag("Player") == true)
        {
            Debug.Log("Im with NPC");
        }
    }
    //When the player its outside the collider
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("im out");
       panelNPCdialogue.SetActive(false) ;
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
        if(index < lines.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            //when we ran out of line, the panel will disappear
            panelNPCdialogue.SetActive(false);

            //Now the player can move
            _player.iCanMove = true;
        }
    }

    // Show and Hide text to let to know the player if 
    // want to talk with the NPC
    private void ShowAppearText()
    {
        textTalk.SetActive(true);
    }

    private void HideAppearText()
    {
        textTalk.SetActive(false);
    }
}
