using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [Header("CONS VARIABLE")]
    private const string IS_OPEN_PARAM = "isOpen"; //Replace paramater

    [Header("Control Panel")]
    [SerializeField] private Button controlsButton;
    [SerializeField] private Button quitControlsButton;
    [SerializeField] private Animator anim_ControlsPanel;
    
    [Header("Option Panel")]
    [SerializeField] private Button optionButton;
    [SerializeField] private Button quitOptionsButton;
    [SerializeField] private Animator anim_OptionsPanel;

    private void Awake()
    {
        //Control panel
        HideControlsPanel();// When the scene starts the panels will be closed
        controlsButton.onClick.AddListener(ShowControlsPanel);
        quitControlsButton.onClick.AddListener(HideControlsPanel);

        //Option panel
        HideOptionsPanel(); // When the scene starts the panels will be closed
        optionButton.onClick.AddListener(ShowOptionsPanel);
        quitOptionsButton.onClick.AddListener(HideOptionsPanel);
    }

    private void ShowControlsPanel()
    {
        anim_ControlsPanel.SetBool(IS_OPEN_PARAM, true);
    }

    private void HideControlsPanel()
    {
        anim_ControlsPanel.SetBool(IS_OPEN_PARAM, false);
    }

    private void ShowOptionsPanel()
    {
        anim_OptionsPanel.SetBool(IS_OPEN_PARAM, true);
    }
    private void HideOptionsPanel()
    {
        anim_OptionsPanel.SetBool(IS_OPEN_PARAM, false);
       
    }

}
