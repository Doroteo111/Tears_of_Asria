using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header(" UI VARAIABLE")]
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;
    void Start()
    {
        totalhealthBar.fillAmount = _playerHealth.currentHealth / 10;
    }

    void Update()
    {
        currenthealthBar.fillAmount = _playerHealth.currentHealth / 10;
    }
}
