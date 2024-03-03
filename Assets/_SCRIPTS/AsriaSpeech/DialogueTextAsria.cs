using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueTextAsria : MonoBehaviour
{
    public TransitionSceneLoader TransitionScene;
    public string startPoint;

    [Header("VARIABLES CANVAS")]
    public TextMeshProUGUI dialogueText;
    public Button nextLineButton;
    public float textSpeed;
    private int index; //array index

    [Header("REFERENCE")]
    public string[] lines;

    [Header("Sounds")]
    [SerializeField] private AudioClip clickSound;

    private void Start()
    {
        dialogueText.text = string.Empty; 
        StartDialogue();

        nextLineButton.onClick.AddListener(ButtonNextLine);
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
        foreach(char c in lines[index].ToCharArray())
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
            //Read from other script, first a transition, then change the scene
            PlayerPrefs.SetString("LastExitPoint", startPoint);
            TransitionScene.LoadNextSceneGame();
        }
    }
    
}
