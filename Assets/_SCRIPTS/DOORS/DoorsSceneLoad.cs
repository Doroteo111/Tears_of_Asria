using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsSceneLoad : MonoBehaviour
{
    private DataPersistence _dataPersistence;

    private void Start()
    {
        _dataPersistence = FindObjectOfType<DataPersistence>();
    }
    private void OnTriggerEnter2D(Collider2D collision) //load
    {
        _dataPersistence.LoadJson();
    }

    
}
