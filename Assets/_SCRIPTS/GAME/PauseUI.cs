using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
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
        Time.timeScale = 0f;
    }

    public void Resume() //Unfreeze time and we can continue playing
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void LoadMainMenu() //change to the Main Menu scene
    {
        Time.timeScale = 1f;
        Loader.Load(Loader.Scene.MainMenu);
    }


}
