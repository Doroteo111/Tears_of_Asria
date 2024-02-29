using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public static class Loader 
    //static class, all their variales and funfactions are static too
{

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
        Credits,
        Test1,
        Test2
    }

    public static void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

}
