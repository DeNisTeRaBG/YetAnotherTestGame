using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnBasedBehaviour : MonoBehaviour
{

    private Button yourButton;

    private GameObject[] enemy;

    private GobboAttack attack;

    void Start()
    {
        yourButton = GameObject.FindGameObjectWithTag("EndTurn").GetComponent<Button>();
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(PlayerTurnOver);
    }

    void PlayerTurnOver()
    {
        StartCoroutine(PlayerTurnEnd());
    }

    IEnumerator PlayerTurnEnd()
    {
        Debug.Log("This Works");
        for (int i = 0; i < enemy.Length; i++)
        {
            attack = enemy[i].GetComponent<GobboAttack>();

            Debug.Log("This Works 2");
            attack.UseAttack();
            yield return new WaitForSeconds(0.5f);
        }
        Debug.Log("This Works 3");
    }
}
