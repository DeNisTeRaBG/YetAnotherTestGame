using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class Enemy : Character
{
    void Start()
    {
        health.text = maxHP.ToString();
        shield.text = currentShield.ToString();
        currentHP = maxHP;
    }

    private void Update()
    {
        shield.text = currentShield.ToString();
        health.text = currentHP.ToString();

        if (currentShield > 0) {
            shield.transform.parent.gameObject.SetActive(true);
        }
        else { shield.transform.parent.gameObject.SetActive(false); }
    }
}