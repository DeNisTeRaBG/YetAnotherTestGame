using System.Collections;
using System.Collections.Generic;
using TJ;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public int cardId;

    public string cardName;
    public string description;
    public string rarity;

    public Sprite artwork;

    public int dmg;
    public int shield;
    public int mana;

    [Header("Status Effects")]
    public Buff vulnerable;
    public Buff weak;
    public Buff strength;
    public Buff ritual;
    public Buff enrage;
}
