using System.Collections;
using System.Collections.Generic;
using TJ;
using TMPro;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHP;
    public int currentHP;
    public int currentShield=0;

    public TMP_Text health;
    public TMP_Text shield;

    [Header("Status Effects")]
    public Buff vulnerable;
    public Buff weak;
    public Buff strength;
    public Buff ritual;
    public Buff enrage;
}
