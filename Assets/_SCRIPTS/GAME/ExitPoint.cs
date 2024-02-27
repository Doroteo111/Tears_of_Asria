using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPoint : MonoBehaviour
{
   [Header("UUID")] //unique unsigned identification
    public string uuid; //save a unique and specific exit point 

    [Header("REFERENCE")]
    private Player _player;
    void Start()
    {
        _player = FindAnyObjectByType<Player>();

        if (!_player.nextUuid.Equals(uuid)) //if the player's next uuid doesn't match the current uuid, this place is not
        {
            return;
        }
        //we change the position of the player where this exit point is.
        _player.transform.position = this.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
