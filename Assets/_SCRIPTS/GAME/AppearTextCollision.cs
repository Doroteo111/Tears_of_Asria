using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AppearTextCollision : MonoBehaviour
{
    [Header("UI VARIABLES")]
    //  [SerializeField] private GameObject YellowDoorpanel;
    [SerializeField] private GameObject textoEjemplo;

    private void Start()
    {
        HideYellowDoorPanel();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShowYellowDoorPanel();
        Debug.Log("estoy dentro");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("estoy fuera");
        HideYellowDoorPanel();
    }

    private void ShowYellowDoorPanel()
    {
      //  YellowDoorpanel.SetActive(true);
      textoEjemplo.SetActive(true);
    }

    private void HideYellowDoorPanel()
    {
        // YellowDoorpanel.SetActive(false);
        textoEjemplo.SetActive(false);
    }
}
