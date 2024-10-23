using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR;

public class Player : Character, IDropHandler
{
    public int maxMana;
    public int currentMana;

    public List<GameObject> deck;
    public GameObject startingRelic;

    public TMP_Text mana;

    public void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    void Start()
    {
        mana.text = maxMana.ToString();
        currentMana = maxMana;

        health.text = maxHP.ToString();
        currentHP = maxHP;

        shield.text = currentShield.ToString();
    }

    private void Update()
    {
        health.text = currentHP.ToString();
        shield.text = currentShield.ToString();
        mana.text = currentMana.ToString();


        if (currentShield > 0)
        {
            shield.transform.parent.gameObject.SetActive(true);
        }
        else { shield.transform.parent.gameObject.SetActive(false); }
    }
}
