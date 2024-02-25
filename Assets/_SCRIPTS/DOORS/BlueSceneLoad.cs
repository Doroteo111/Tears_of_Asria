using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSceneLoad : MonoBehaviour
{
    public DataPersistence _dataPersistence;


    private void Start()
    {
        _dataPersistence.LoadJson();
    }
}
