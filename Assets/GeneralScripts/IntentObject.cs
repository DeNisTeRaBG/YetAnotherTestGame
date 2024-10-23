using System.Collections;
using System.Collections.Generic;
using TJ;
using UnityEngine;

[CreateAssetMenu(fileName = "New Intent", menuName = "Intent")]
public class IntentObject : ScriptableObject
{
    public Sprite artwork;

    public int dmg;
    public int shield;

    [Header("Status Effects")]
    public Buff vulnerable;
    public Buff weak;
    public Buff strength;
    public Buff ritual;
    public Buff enrage;
    public Buff selfDamage;
}