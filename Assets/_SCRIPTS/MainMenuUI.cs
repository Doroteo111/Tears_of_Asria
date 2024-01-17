using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button controlsButton;
    [SerializeField] private Button quitControlsButton;

    [SerializeField] private GameObject controlsPanel;
    private bool isOpen;

    private Animator _animator;

    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        controlsButton.onClick.AddListener(ShowControlsPanel);
        quitControlsButton.onClick.AddListener(HideControlsPanel);
        HideControlsPanel();
    }
    
    private void ShowControlsPanel()
    {
        controlsPanel.SetActive(true);
        isOpen= _animator.GetBool("Open_ControlP");
    }

    private void HideControlsPanel()
    {
        controlsPanel.SetActive(false);
        _animator.SetBool("Open_ControlP", !isOpen);
    }
    
    /*
    private void Awake()
    {
        controlsButton.onClick.AddListener(OpenControlsPanel);
        controlsPanel.SetActive(false);
    }
    private void OpenControlsPanel()
    {
        _animator = controlsPanel.GetComponent<Animator>();
        if (_animator != null)
        {
            bool isOpen = _animator.GetBool("Open_ControlP");

            _animator.SetBool("Open_ControlP", !isOpen);
        }
    }
    */
}
