using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransitionSceneLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    // LOAD MAIN MENU --> ASRIA SPPECH SCENE
    public void LoadNextSceneSpeech()
    {
        StartCoroutine(LoadTransScene());
    }
    IEnumerator LoadTransScene()
    {
        //play animation
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

        Loader.Load(Loader.Scene.AsriaSpeech);
    }

    // LOAD ASRIA SPPECH SCENE --> GAME SCENE
    public void LoadNextSceneGame()
    {
        StartCoroutine(LoadTransGame());
    }
    IEnumerator LoadTransGame()
    {
        //play animation
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

        Loader.Load(Loader.Scene.GAME);
    }

    // LOAD GAME SCENE --> BLUE DOOR SCENE
    public void LoadNextSceneBlueDoor()
    {
        StartCoroutine(LoadTransBlueDoor());
    }
    IEnumerator LoadTransBlueDoor()
    {
        //play animation
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

        Loader.Load(Loader.Scene.BlueDoor);
    }

    // LOAD GAME SCENE --> YELLOW DOOR SCENE
    public void LoadNextSceneYellowDoor()
    {
        StartCoroutine(LoadTransYellowDoor());
    }
    IEnumerator LoadTransYellowDoor()
    {
        //play animation
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

        Loader.Load(Loader.Scene.YellowDoor);
    }

    // LOAD GAME SCENE --> PURPLE DOOR SCENE
    public void LoadNextScenePurpleDoor()
    {
        StartCoroutine(LoadTransPurpleDoor());
    }
    IEnumerator LoadTransPurpleDoor()
    {
        //play animation
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

        Loader.Load(Loader.Scene.PurpleDoor);
    }

    // LOAD GAME SCENE --> PINK DOOR SCENE
    public void LoadNextScenePinkDoor()
    {
        StartCoroutine(LoadTransPinkDoor());
    }
    IEnumerator LoadTransPinkDoor()
    {
        //play animation
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

        Loader.Load(Loader.Scene.PinkDoor);
    }

    // LOAD GAME SCENE --> END GAME SCENE
    public void LoadNextSceneEndGame()
    {
        StartCoroutine(LoadTransEndGame());
    }
    IEnumerator LoadTransEndGame()
    {
        //play animation
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

        Loader.Load(Loader.Scene.EndGame);
    }

    // LOAD END GAME SCENE --> CREDITS SCENE
    public void LoadNextSceneCredits()
    {
        StartCoroutine(LoadTransCredits());
    }
    IEnumerator LoadTransCredits()
    {
        //play animation
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

        Loader.Load(Loader.Scene.Credits);
    }


}
