using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
     public TransitionSceneLoader TransitionScene;

    [Header("CONS VARIABLE")]
    private const string IS_OPEN_PARAM = "isOpen"; //Replace paramater animation

    [Header("Play Button")]
    [SerializeField] private Button playButton;

    [Header("Control Panel")]
    [SerializeField] private Button controlsButton;
    [SerializeField] private Button quitControlsButton;
    [SerializeField] private Animator anim_ControlsPanel;
    
    [Header("Option Panel")]
    [SerializeField] private Button optionButton;
    [SerializeField] private Button quitOptionsButton;
    [SerializeField] private Animator anim_OptionsPanel;

    [Header("Quit Button")]
    [SerializeField] private Button quitButton;

    private void Awake()
    {

        //TransitionScene.GetComponent<TransitionSceneLoader>().LoadNextScene();
        //when play button get press first animation and them load scene
        //comunication script

    }
    private void Start()
    {
        //Play Button --> assigned by editor
      
        //Control panel
        HideControlsPanel();// When the scene starts the panels will be closed
        controlsButton.onClick.AddListener(ShowControlsPanel);
        quitControlsButton.onClick.AddListener(HideControlsPanel);

        //Option panel
        HideOptionsPanel(); // When the scene starts the panels will be closed
        optionButton.onClick.AddListener(ShowOptionsPanel);
        quitOptionsButton.onClick.AddListener(HideOptionsPanel);

        //Quit button
        //quitButton.onClick.AddListener(Application.Quit);
    }
    public void PlayButton()
    {
        //Read from other script, first a transition, then change the scene
        TransitionScene.LoadNextSceneSpeech();
    }
    //We show and hide the panels with an animation and disable the buttons to avoid mess
    //in order to obligate the player to close the menu to open another or interact with a button
    private void ShowControlsPanel()
    {
        anim_ControlsPanel.SetBool(IS_OPEN_PARAM, true);
        optionButton.interactable = false;
        quitButton.interactable = false;
        playButton.interactable = false;
    }

    private void HideControlsPanel()
    {
        anim_ControlsPanel.SetBool(IS_OPEN_PARAM, false);
        optionButton.interactable = true;
        quitButton.interactable = true;
        playButton.interactable = true;
    }

    private void ShowOptionsPanel()
    {
        anim_OptionsPanel.SetBool(IS_OPEN_PARAM, true);
        controlsButton.interactable = false;
        quitButton.interactable = false;
        playButton.interactable = false;
    }
    private void HideOptionsPanel()
    {
        anim_OptionsPanel.SetBool(IS_OPEN_PARAM, false);
        controlsButton.interactable = true;
        quitButton.interactable = true;
        playButton.interactable = true;

    }

}
