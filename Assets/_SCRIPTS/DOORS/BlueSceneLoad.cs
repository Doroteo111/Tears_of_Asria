using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSceneLoad : MonoBehaviour
{
    public DataPersistence _dataPersistence;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _dataPersistence.LoadJson();
    }

    private void Start()
    {
       
    }
}
