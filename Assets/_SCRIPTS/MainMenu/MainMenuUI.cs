using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{

    //Control Panel VARIABLES
    [SerializeField] private Button controlsButton;
    [SerializeField] private Button quitControlsButton;
    [SerializeField] private GameObject controlsPanel;

    private bool isOpenPanel;

    //REFERENCE
    private Animator _animator;

    private void Awake()
    {
        HideControlsPanel();// When the scene starts the panels will be closed
        controlsButton.onClick.AddListener(ShowControlsPanel);
        quitControlsButton.onClick.AddListener(HideControlsPanel);

        _animator = GetComponent<Animator>();
    }

    private void ShowControlsPanel()
    {
        _animator.SetBool("isOpen", true);
        controlsPanel.SetActive(true);
      
    }

    private void HideControlsPanel()
    {
        _animator.SetBool("isOpen", false);
        controlsPanel.SetActive(false);
       
    }




    /*
    private void LateUpdate()
    {
        if(_animator != null)
        {
            isOpenPanel = _animator.GetBool("isOpen");
        }
        else
        {
            _animator.SetBool("isOpen", !isOpenPanel);
        }
    }
    */
}
