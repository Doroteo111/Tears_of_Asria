using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTester : MonoBehaviour
{
    [SerializeField] private Transform destinaton;

    public Transform GetDestination()
    {
        return destinaton;
    }
}
