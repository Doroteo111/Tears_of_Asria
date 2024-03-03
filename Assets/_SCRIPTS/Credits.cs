using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    [Header("Sounds")]
    [SerializeField] private AudioClip clickSound;

    public void LoadMainMenu() //change to the Main Menu scene
    {
        
        SoundManager.instance.PlaySound(clickSound);
        Loader.Load(Loader.Scene.MainMenu);
    }
}
