using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;

    public TMP_Text nameText;
    public TMP_Text descriptionText;

    public Image artworkImage;

    public TMP_Text manaText;
    public int rarity = 1;
    public int id;

    void Start()
    {
        nameText.text = card.name;
        descriptionText.text = card.description;
        manaText.text = card.mana.ToString();

        artworkImage.sprite = card.artwork;
    }
}
