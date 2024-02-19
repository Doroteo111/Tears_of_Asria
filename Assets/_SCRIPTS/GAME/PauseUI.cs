using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
   // [SerializeField] private Button resumeButton;
   // [SerializeField] private Button backMainButton;

    [SerializeField] GameObject pausePanel;

    private void Start()
    {
        pausePanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

   /* private void ShowPausePanel()
    {
      pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    private void HidePausePanel()
    {
        pausePanel.SetActive(false);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        HidePausePanel();
    }*/

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pausePanel.SetActive(false); 
        Time.timeScale = 1f;
    }
}
