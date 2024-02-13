using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public static class Loader 
    //static class, all their variales and funfactions are static too
{
    private static Action loaderCallbackAction;

    
    public enum Scene // List of all the scenes
    {
        MainMenu,
        AsriaSpeech,
        GAME,
        BlueDoor,
        PinkDoor,
        PurpleDoor,
        YellowDoor,
        EndGame,
        Credits
    }

    private static Scene sceneAux;

    public static void Load(Scene scene)
    {
        // Asignas en loaderCallbackAction una función que no recibe parámetros y ejecuta la línea 25
        loaderCallbackAction = () =>
        {
            SceneManager.LoadScene(scene.ToString());
        };


        // Loading scene before game scene
        SceneManager.LoadScene(Scene.AsriaSpeech.ToString());
    }

}
