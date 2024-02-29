using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPoint : MonoBehaviour
{
    [Header("REFERENCE")]
    public Player _player;

    public string lastExitPoint;

    void Start()
    {
       // _player = FindAnyObjectByType<Player>();
        if (PlayerPrefs.GetString("LastExitPoint")== lastExitPoint)
        {
            _player.transform.position = this.transform.position;
        }
       


    }
}
