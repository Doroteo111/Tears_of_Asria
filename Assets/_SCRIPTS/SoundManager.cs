using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [Header(" Volume slider")]
    private Slider _volumeSlider; //save general volume via slider main menu
    public static SoundManager instance { get; private set; }//acess from other script but changed it only in this one
    private AudioSource source;

    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
        _volumeSlider = GetComponent<Slider>();
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            SetVolume();
        }
        else
        {
            SetVolume();
        }
    }
    public void PlaySound(AudioClip _sound)
    {
        source.PlayOneShot(_sound); //for sound effect /plays one time
    }
    public void ChangeVolume()
    {
        AudioListener.volume = _volumeSlider.value;
        GetVolume();
    }

   private void GetVolume() //(save data)
    {
        PlayerPrefs.SetFloat("musicVolume", _volumeSlider.value);

    }
    private void SetVolume() //(load data)
    {
        _volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
}
