using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;

    [Header("Sounds")]
    [SerializeField] private AudioClip clickSound;
    private void Start()
    {
        pausePanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // when Esc is pressed, paused the game
        {
            Pause();
        }
    }
    public void Pause() //freeze time
    {
        pausePanel.SetActive(true);
        SoundManager.instance.PlaySound(clickSound);
        Time.timeScale = 0f;
    }

    public void Resume() //Unfreeze time and we can continue playing
    {
        pausePanel.SetActive(false);
        SoundManager.instance.PlaySound(clickSound);
        Time.timeScale = 1f;
    }

    public void LoadMainMenu() //change to the Main Menu scene
    {
        Time.timeScale = 1f;
        SoundManager.instance.PlaySound(clickSound);
        Loader.Load(Loader.Scene.MainMenu);
    }


}
