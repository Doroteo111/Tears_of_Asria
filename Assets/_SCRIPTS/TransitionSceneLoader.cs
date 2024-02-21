using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransitionSceneLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public void LoadNextScene()
    {
        StartCoroutine(LoadTransScene());
    }
    IEnumerator LoadTransScene()
    {
        //play animation
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        //SceneManager.LoadScene(levelIndex);
        Loader.Load(Loader.Scene.AsriaSpeech);
    }
}
